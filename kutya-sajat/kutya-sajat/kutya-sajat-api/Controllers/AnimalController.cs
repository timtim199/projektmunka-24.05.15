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
    [ApiController, Route("api/animals")]
    public class AnimalController : Controller
    {
        Repository<Animal> animals;
        public AnimalController(Repository<Animal> _animals)
        {
            animals = _animals;
        }

        [HttpGet("page/{pageNum}")]
        public IActionResult GetAnimals(uint pageNum = 0)
        {
            return ResultBuilder<List<Animal>>.ProtectedCall(() =>
            {
                List<Animal> result = animals.GetPage(pageNum).ToList();
                return ResultBuilder<List<Animal>>.Build(data: result).AsJson();
            });
        }
        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            return ResultBuilder<Animal>.ProtectedCall(() =>
            {
                Animal result = animals.FindId(id, true);
                return ResultBuilder<Animal>.Build(data: result).AsJson();
            });
        }

        [HttpPatch("search")]
        public IActionResult SearchAnimal(SearchDto dto)
        {
            return ResultBuilder<Animal>.ProtectedCall(() =>
            {
                List<Animal> result = animals.SearchText(dto).ToList();
                return ResultBuilder<List<Animal>>.Build(data: result).AsJson();
            });
        }

        [HttpPost]
        public IActionResult PostAnimal(DTO.AnimalDto animalDto)
        {
            return ResultBuilder<Animal>.ProtectedCall(() =>
            {
                Animal result = animals.Insert(animalDto);
                result = animals.IncludeAll(result);
                return ResultBuilder<Animal>.Build(data: result, code: 201).AsJson();
            });
        }

        [HttpPut("{id}")]
        public IActionResult EditAnimal(DTO.AnimalDto animalDto, int id)
        {
            return ResultBuilder<Animal>.ProtectedCall(() =>
            {
                Animal result = animals.Update(id, animalDto);
                result = animals.IncludeAll(result);
                return ResultBuilder<Animal>.Build(data: result, code: 200).AsJson();
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id) 
        {
            return ResultBuilder<Animal>.ProtectedCall(() =>
            {
                animals.DeleteById(id);
                return ResultBuilder<Animal>.Build(code: 204, message: "deleted").AsJson();
            });
        }


    }
}
