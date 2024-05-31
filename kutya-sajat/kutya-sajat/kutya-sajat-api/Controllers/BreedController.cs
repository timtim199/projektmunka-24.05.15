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
    [ApiController, Route("api/breeds")]
    public class BreedController : Controller
    {
        Repository<Breed> breeds;
        public BreedController(Repository<Breed> _breeds)
        {
            breeds = _breeds;
        }

        [HttpGet("page/{pageNum}")]
        public IActionResult GetBreeds(uint pageNum = 0)
        {
            return ResultBuilder<List<Breed>>.ProtectedCall(() =>
            {
                List<Breed> result = breeds.GetPage(pageNum).ToList();
                return ResultBuilder<List<Breed>>.Build(data: result).AsJson();
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetBreed(int id)
        {
            return ResultBuilder<Breed>.ProtectedCall(() =>
            {
                Breed result = breeds.FindId(id, true);
                return ResultBuilder<Breed>.Build(data: result).AsJson();
            });
        }

        [HttpPost]
        public IActionResult PostBreed(DTO.BreedDto breedDto)
        {
            return ResultBuilder<Breed>.ProtectedCall(() =>
            {
                Breed result = breeds.Insert(breedDto);
                result = breeds.IncludeAll(result);
                return ResultBuilder<Breed>.Build(data: result, code: 201).AsJson();
            });
        }

        [HttpPut("{id}")]
        public IActionResult EditBreed(DTO.BreedDto breedDto, int id)
        {
            return ResultBuilder<Breed>.ProtectedCall(() =>
            {
                Breed result = breeds.Update(id, breedDto);
                result = breeds.IncludeAll(result);
                return ResultBuilder<Breed>.Build(data: result, code: 200).AsJson();
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBreed(int id)
        {
            return ResultBuilder<Breed>.ProtectedCall(() =>
            {
                breeds.DeleteById(id);
                return ResultBuilder<Breed>.Build(code: 204, message: "deleted").AsJson();
            });
        }
    }
}
