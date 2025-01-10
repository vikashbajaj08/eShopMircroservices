namespace Authentication.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Email { get; set; } =default!;

        public bool EmailConfirmed { get; set; }

        public string Password { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
