namespace prueba_tecnica.Models
{
    public class DataSet
    {
        public int DataSetID { get; set; }
        public string DataSetName { get; set; }
        public string Description { get; set; }
        public int ProcedureID { get; set; }
        public int FieldID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public Procedure Procedure { get; set; }
        public Field Field { get; set; }
    }
}
