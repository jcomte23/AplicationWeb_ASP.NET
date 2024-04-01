

namespace WebApplicationCRUD_USERS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Names { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public void setNames(string _names)
        {
            Names = _names.ToLower();
        }

        public void setLastName(string _lastName)
        {
            LastName = _lastName.ToLower();
        }

        public void setEmail(string _email)
        {
            Email = _email.ToLower();
        }

    }
}
