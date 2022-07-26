using RepositoryLibrary.Base;
using EntityLibarary;

namespace DataLibrary.Implementation
{
    public class AdminRepository : IRepository<Admin>
    {
        private static int id;

        public Admin Create(Admin entity)
        {
            id++;
            entity.Id = id;
            try
            {
            Data.Admins.Add(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return entity;
        }

        public Admin Get(Predicate<Admin> filter = null)
        {
            try
            {
            if (filter == null)
            {
                return Data.Admins[0];
            }
            else
            {
                return Data.Admins.Find(filter);
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Remove(Admin entity)
        {
            try
            {
            Data.Admins.Remove(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public void Update(Admin entity)
        {
            try
            {
            var admin = Data.Admins.Find(g => g.Id == entity.Id);
            if (admin != null)
            {
                admin.Username = entity.Username;
                admin.Password = entity.Password;
               
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        public List<Admin> GetAll(Predicate<Admin> filter = null)
        {
            try
            {
            if (filter == null)
            {
                return Data.Admins;
            }
            else
            {
                return Data.Admins.FindAll(filter);
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
