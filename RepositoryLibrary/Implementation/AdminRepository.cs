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
            Data.Admins.Add(entity);

            return entity;
        }

        public Admin Get(Predicate<Admin> filter = null)
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

        public void Remove(Admin entity)
        {
            Data.Admins.Remove(entity);
        }

        public void Update(Admin entity)
        {
            var admin = Data.Admins.Find(g => g.Id == entity.Id);
            if (admin != null)
            {
                admin.Username = entity.Username;
                admin.Password = entity.Password;
               
            }

        }

        public List<Admin> GetAll(Predicate<Admin> filter = null)
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
    }
}
