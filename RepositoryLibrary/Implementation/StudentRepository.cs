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
            try
            {
            Data.Students.Add(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public Student Get(Predicate<Student> filter = null)
        {
            try
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
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Remove(Student entity)
        {
            try
            {

            Data.Students.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public void Update(Student entity)
        {
            try
            {
            var student = Data.Students.Find(g => g.Id == entity.Id);
            if (student != null)
            {
                student.Name = entity.Name;
                student.Surname = entity.Surname;
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); 
            }

        }

        public List<Student> GetAll(Predicate<Student> filter=null)
        {
            try
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
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
