using DataLibrary;
using EntityLibrary;
using RepositoryLibrary.Base;


namespace RepositoryLibrary.Implementation
{
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group entity)
        {
            Data.Groups.Add(entity);
        }

        public Group Get(Predicate<Group> filter=null)
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

        public void Remove(Group entity)
        {
            Data.Groups.Remove(entity);
        }

        public void Update(Group entity)
        {
            var group = Data.Groups.Find(g => g.Id == entity.Id);
            if (group != null)
            {
                group.Name = entity.Name;
                group.MaxSize = entity.MaxSize;
            }

        }

        public List<Group> GetAll(  Predicate<Group> filter=null)
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
    }
}
