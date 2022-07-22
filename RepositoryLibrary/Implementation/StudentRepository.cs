using DataLibrary;
using EntityLibrary;
using RepositoryLibrary.Base;


namespace RepositoryLibrary.Implementation
{
    public class StudentRepository : IRepository<Student>
    {   
        private static int id;
        public Student Create(Student entity)
        {   id++;
            entity.Id = id;
            Data.Students.Add(entity);
            return entity;
        }

        public Student Get(Predicate<Student> filter = null)
        {
            if (filter == null)
            {
                return Data.Students[0];
            }
            else
            {
                return Data.Students.Find(filter);
            }
        }

        public void Remove(Student entity)
        {
            Data.Students.Remove(entity);
        }

        public void Update(Student entity)
        {
            var student = Data.Students.Find(g => g.Id == entity.Id);
            if (student != null)
            {
                student.Name = entity.Name;
                student.Surname = entity.Surname;
            }

        }

        public List<Student> GetAll(Predicate<Student> filter=null)
        {
            if (filter == null)
            {
                return Data.Students;
            }
            else
            {
                return Data.Students.FindAll(filter);
            }
        }
    }
}
