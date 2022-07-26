

using DataLibrary;
using DataLibrary.Implementation;
using EntityLibarary;
using RepositoryLibrary.Implementation;

namespace Manage.Controllers
{
    public class TeacherController
    {
        Teacher teacher = new Teacher();
        private TeacherRepository _teacherRepository;
        private GroupRepository _groupRepository;
        private TeacherController _teacherController;

        public TeacherController()
        {
            _teacherRepository = new TeacherRepository();
            _teacherController = new TeacherController();
        }
        public void Create()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please enter the teacher name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please enter the teacher surname");
            string surname = Console.ReadLine();
        TypingCorrectAge: ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please enter the teacher name");
            string age = Console.ReadLine();
            int ageint;
            bool result = int.TryParse(age, out ageint);
            if (result)
            {
                teacher.Name = name;
                teacher.Surname = surname;
                teacher.Age = ageint;
                Data.Teachers.Add(teacher);
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please,enter the correct age");
                goto TypingCorrectAge;
            }


        }



        public void Get()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count != 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please choose one of the teacher id to get information");
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{teacher.Id} : {teacher.Name}");

                }
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {
                    var teacher = _teacherRepository.Get(t => t.Id == Id);
                    if (teacher != null)
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"ID is {teacher.Id},Teacher Name is {teacher.Name}, surname is {teacher.Surname}");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no teacher found");
                    }
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no teacher on data, please hire one if you want to get");
            }
        }
        public void GetAll()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count != 0)
            {
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{teacher.Id},{teacher.Name},{teacher.Surname}");

                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no teacher found");
            }
        }

        public void Remove()
        {
            GetAll();
            if (GetAll != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "Please choose one of the teachers id");
                string id = Console.ReadLine();
                int Id;
                bool result = int.TryParse(id, out Id);
                if (result)
                {

                }
            }

        }

        public void Update()
        {

        }
    }
}





    }
}
