namespace prueba_tecnica.Models
{
    public class Field
    {
        public int FieldID { get; set; }
        public string FieldName { get; set; }
        public string DataType { get; set; }

        public ICollection<DataSet> DataSets { get; set; }
    }
}
