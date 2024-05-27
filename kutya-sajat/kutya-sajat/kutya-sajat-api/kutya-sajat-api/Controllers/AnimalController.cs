using kutya_sajat_api.Data.Models;
using kutya_sajat_api.Data.Repositories;
using kutya_sajat_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
                Animal result = animals.FindId(id);
                return ResultBuilder<Animal>.Build(data: result).AsJson();
            });
        }
    }
}
