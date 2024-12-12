using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prueba_tecnica.Dtos;
using prueba_tecnica.Services;

namespace prueba_tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSetController : Controller
    {
        private readonly DataSetService _dataSetService;

        public DataSetController(DataSetService dataSetService)
        {
            _dataSetService = dataSetService;
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetDataSetsByUserId(int userId)
        {
            var dataSets = await _dataSetService.GetDataSetsByUserIdAsync(userId);

            if (dataSets == null || !dataSets.Any())
            {
                return NotFound("No datasets found for the given user.");
            }

            return Ok(dataSets);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateDataSet([FromBody] CreateDataSetDto createDataSetDto)
        {
            try
            {
                var newDataSet = await _dataSetService.CreateDataSetAsync(createDataSetDto);
                return CreatedAtAction(nameof(GetDataSetsByUserId), new { userId = newDataSet.Procedure.CreatedByUserID }, newDataSet);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message); // Si el ProcedureID o FieldID no se encuentran
            }
        }
    }
}
