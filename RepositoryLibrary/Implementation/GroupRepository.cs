using DataLibrary;
using EntityLibrary;
using RepositoryLibrary.Base;
using EntityLibrary.abstraction;


namespace RepositoryLibrary.Implementation
{
    public class GroupRepository : IRepository<Group>
    { 
        private static int id;
       
        public Group Create(Group entity)
        {
            id++;
            entity.Id = id;
            
            try
            {
            Data.Groups.Add(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Group Get(Predicate<Group> filter=null)
        {
            try
            {
            if (filter == null)
            {
                return Data.Groups[0];
            }
            else
            {
                return Data.Groups.Find(filter);
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Remove(Group entity)
        {
            try
            {

            Data.Groups.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public void Update(Group entity)
        {
            try
            {
            var group = Data.Groups.Find(g => g.Id == entity.Id);
            if (group != null)
            {
                group.Name = entity.Name;
                group.MaxSize = entity.MaxSize;
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        public List<Group> GetAll(  Predicate<Group> filter=null)
        {
            try
            {
            if (filter == null)
            {
                return Data.Groups;
            }
            else
            {
                return Data.Groups.FindAll(filter);
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
