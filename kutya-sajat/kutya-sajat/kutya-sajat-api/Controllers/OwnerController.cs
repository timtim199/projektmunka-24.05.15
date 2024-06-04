using kutya_sajat_api.Data.Models;
using kutya_sajat_api.Data.Models.DataTransferObjects;
using kutya_sajat_api.Data.Repositories;
using kutya_sajat_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO = kutya_sajat_api.Data.Models.DataTransferObjects;

namespace kutya_sajat_api.Controllers
{
    [ApiController, Route("api/owners")]
    public class OwnerController : Controller
    {
        Repository<Owner> owners;
        public OwnerController(Repository<Owner> _owners)
        {
            owners = _owners;
        }

        [HttpGet("page/{pageNum}")]
        public IActionResult GetOwners(uint pageNum = 0)
        {
            return ResultBuilder<List<Owner>>.ProtectedCall(() =>
            {
                List<Owner> result = owners.GetPage(pageNum).ToList();
                return ResultBuilder<List<Owner>>.Build(data: result).AsJson();
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetOwner(int id)
        {
            return ResultBuilder<Owner>.ProtectedCall(() =>
            {
                Owner result = owners.FindId(id, true);
                return ResultBuilder<Owner>.Build(data: result).AsJson();
            });
        }

        [HttpPost]
        public IActionResult PostOwner(DTO.OwnerDto ownerDto)
        {
            return ResultBuilder<Owner>.ProtectedCall(() =>
            {
                Owner result = owners.Insert(ownerDto);
                result = owners.IncludeAll(result);
                return ResultBuilder<Owner>.Build(data: result, code: 201).AsJson();
            });
        }

        [HttpPatch("search")]
        public IActionResult SearchAnimal(SearchDto dto)
        {
            return ResultBuilder<Animal>.ProtectedCall(() =>
            {
                List<Owner> result = owners.SearchText(dto).ToList();
                return ResultBuilder<List<Owner>>.Build(data: result).AsJson();
            });
        }

        [HttpPut("{id}")]
        public IActionResult EditOwner(DTO.OwnerDto ownerDto, int id)
        {
            return ResultBuilder<Owner>.ProtectedCall(() =>
            {
                Owner result = owners.Update(id, ownerDto);
                result = owners.IncludeAll(result);
                return ResultBuilder<Owner>.Build(data: result, code: 200).AsJson();
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(int id)
        {
            return ResultBuilder<Owner>.ProtectedCall(() =>
            {
                owners.DeleteById(id);
                return ResultBuilder<Owner>.Build(code: 204, message: "deleted").AsJson();
            });
        }
    }
}
