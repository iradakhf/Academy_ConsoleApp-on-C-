using DataLibrary;
using DataLibrary.Implementation;
using EntityLibarary;


namespace Manage.Controllers
{
    public class AdminController
    {
        private AdminRepository _adminRepository;
        public AdminController()
        {
            _adminRepository = new AdminRepository();
        }
        public  Admin Autenticate()
        {
            AdminAutetication: ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please enter username");
            string username = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please enter password");
            string password = Console.ReadLine();
            var admin = _adminRepository.Get(a => a.Username.ToLower() == username.ToLower() && PasswordHasher.Decrypt(a.Password) == password);
            return admin;
        }
    }
}
