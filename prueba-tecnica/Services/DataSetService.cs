using Microsoft.EntityFrameworkCore;
using prueba_tecnica.Dtos;
using prueba_tecnica.Models;
using prueba_tecnica.Repositories;

namespace prueba_tecnica.Services
{
    public class DataSetService
    {
        private readonly ApplicationDbContext _context;

        public DataSetService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para obtener DataSets por UserId
        public async Task<List<DataSetDTO>> GetDataSetsByUserIdAsync(int userId)
        {
            var dataSets = await _context.DataSets
                .Include(ds => ds.Procedure)
                .Where(ds => ds.Procedure.CreatedByUserID == userId || ds.Procedure.LastModifiedUserID == userId)
                .Select(ds => new DataSetDTO
                {
                    DataSetID = ds.DataSetID,
                    DataSetName = ds.DataSetName,
                    Description = ds.Description,
                    ProcedureID = ds.ProcedureID,
                    FieldID = ds.FieldID
                })
                .ToListAsync();

            return dataSets;
        }

        // Método para crear un nuevo DataSet
        public async Task<DataSet> CreateDataSetAsync(CreateDataSetDto createDataSetDto)
        {
            // Validación de que el ProcedureID existe
            var procedure = await _context.Procedures
                .FirstOrDefaultAsync(p => p.ProcedureID == createDataSetDto.ProcedureID);
            if (procedure == null)
            {
                throw new ArgumentException($"Procedure with ID {createDataSetDto.ProcedureID} not found.");
            }

            // Validación de que el FieldID existe
            var field = await _context.Fields
                .FirstOrDefaultAsync(f => f.FieldID == createDataSetDto.FieldID);
            if (field == null)
            {
                throw new ArgumentException($"Field with ID {createDataSetDto.FieldID} not found.");
            }

            // Crear el nuevo DataSet
            var newDataSet = new DataSet
            {
                DataSetName = createDataSetDto.DataSetName,
                Description = createDataSetDto.Description,
                ProcedureID = createDataSetDto.ProcedureID,
                FieldID = createDataSetDto.FieldID,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow
            };

            // Agregar el nuevo DataSet al contexto y guardar
            _context.DataSets.Add(newDataSet);
            await _context.SaveChangesAsync();

            return newDataSet;
        }
    }
}
