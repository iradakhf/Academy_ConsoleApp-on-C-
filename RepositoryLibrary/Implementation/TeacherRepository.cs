using EntityLibarary;
using RepositoryLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Implementation        
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private static int id;
        public Teacher Create(Teacher entity)
        {
            id++;
            entity.Id = id;
            try
            {
                Data.Teachers.Add(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public Teacher Get(Predicate<Teacher> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Data.Teachers[0];
                }
                else
                {
                    return Data.Teachers.Find(filter);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Remove(Teacher entity)
        {
            try
            {

                Data.Teachers.Remove(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public void Update(Teacher entity)
        {
            try
            {
                var teacher = Data.Teachers.Find(g => g.Id == entity.Id);
                if (teacher != null)
                {
                    teacher.Name = entity.Name;
                    teacher.Surname = entity.Surname;
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        public List<Teacher> GetAll(Predicate<Teacher> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Data.Teachers;
                }
                else
                {
                    return Data.Teachers.FindAll(filter);
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
