namespace prueba_tecnica.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Procedure> CreatedProcedures { get; set; }
        public ICollection<Procedure> LastModifiedProcedures { get; set; }
    }
}
