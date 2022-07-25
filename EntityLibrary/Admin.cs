using EntityLibrary.abstraction;
namespace EntityLibarary
{
   public class Admin : IEntity
    {
        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
