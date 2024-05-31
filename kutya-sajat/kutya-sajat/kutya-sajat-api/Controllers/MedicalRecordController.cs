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
    [ApiController, Route("api/medicalrecords")]
    public class MedicalRecordController : Controller
    {
        Repository<MedicalRecord> medicalRecords;

        public MedicalRecordController(Repository<MedicalRecord> _medicalRecords)
        {
            medicalRecords = _medicalRecords;
        }

        [HttpGet("page/{pageNum}")]
        public IActionResult GetMedicalRecords(uint pageNum = 0)
        {
            return ResultBuilder<List<MedicalRecord>>.ProtectedCall(() =>
            {
                List<MedicalRecord> result = medicalRecords.GetPage(pageNum).ToList();
                return ResultBuilder<List<MedicalRecord>>.Build(data: result).AsJson();
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetMedicalRecord(int id)
        {
            return ResultBuilder<MedicalRecord>.ProtectedCall(() =>
            {
                MedicalRecord result = medicalRecords.FindId(id, true);
                return ResultBuilder<MedicalRecord>.Build(data: result).AsJson();
            });
        }

        [HttpPost]
        public IActionResult PostMedicalRecord(DTO.MedicalRecordDto medicalRecordDto)
        {
            return ResultBuilder<MedicalRecord>.ProtectedCall(() =>
            {
                MedicalRecord result = medicalRecords.Insert(medicalRecordDto);
                result = medicalRecords.IncludeAll(result);
                return ResultBuilder<MedicalRecord>.Build(data: result, code: 201).AsJson();
            });
        }

        [HttpPut("{id}")]
        public IActionResult EditMedicalRecord(DTO.MedicalRecordDto medicalRecordDto, int id)
        {
            return ResultBuilder<MedicalRecord>.ProtectedCall(() =>
            {
                MedicalRecord result = medicalRecords.Update(id, medicalRecordDto);
                result = medicalRecords.IncludeAll(result);
                return ResultBuilder<MedicalRecord>.Build(data: result, code: 200).AsJson();
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMedicalRecord(int id)
        {
            return ResultBuilder<MedicalRecord>.ProtectedCall(() =>
            {
                medicalRecords.DeleteById(id);
                return ResultBuilder<MedicalRecord>.Build(code: 200, message: "deleted").AsJson();
            });
        }
    }
}
