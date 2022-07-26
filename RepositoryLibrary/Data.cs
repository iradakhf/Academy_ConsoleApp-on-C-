using EntityLibarary;
using EntityLibrary;


namespace DataLibrary
{
    public static class Data
    {
         static Data()
        {
            Students = new List<Student>();
            Groups = new List<Group>();
            Admins = new List<Admin>();
            Teachers = new List<Teacher>();

            string password1 = "12345678";
            var hashedPassword = PasswordHasher.Encrypt(password1);
            Admin admin1 = new Admin("admin1", hashedPassword);
            Admins.Add(admin1);

            string password2 = "87654321";
            var hashedPassword2 = PasswordHasher.Encrypt(password2);
            Admin admin2 = new Admin("admin2", hashedPassword);
            Admins.Add(admin2);

            
        }
        public static List<Student> Students {get; set;}
     public static List<Group> Groups { get; set; }
        public static List<Teacher> Teachers { get; set; }
        public static List<Admin> Admins { get; set; }
    }
}
