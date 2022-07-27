

using DataLibrary;
using DataLibrary.Implementation;
using EntityLibarary;
using RepositoryLibrary.Implementation;

namespace Manage.Controllers
{
    public class TeacherController
    {
        
        private TeacherRepository _teacherRepository;
        private GroupRepository _groupRepository;
        

        public TeacherController()
        {
            _teacherRepository = new TeacherRepository();
            
        }
        public void Create()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please enter the teacher name");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please enter the teacher surname");
            string surname = Console.ReadLine();
        TypingCorrectAge: ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please enter the teacher age");
            string age = Console.ReadLine();
            int ageint;
            bool result = int.TryParse(age, out ageint);
            if (result)
            {
                Teacher teacher = new Teacher();
                teacher.Name = name;
                teacher.Surname = surname;
                teacher.Age = ageint;
                Data.Teachers.Add(teacher);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow,$"Teacher is created : name {name}, surname {surname}, age is {ageint}");
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
                    var teacher =_teacherRepository.Get(t=> t.Id == Id);
                    if(teacher != null)
                    {
                        _teacherRepository.Remove(teacher);
                    }
                }
            }

        }

        public void Update()
        {
            GetAll();
            if (GetAll!=null)
            {
                EnteringThCorrectId: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please choose teacher id to update");
                string Id = Console.ReadLine();
                int id;
                bool result = int.TryParse(Id, out id);
                if (result)
                {
                    var teacher= _teacherRepository.Get(t=> t.Id == id);
                    if( teacher != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter the new name ");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter the new surname");
                        string newSurname = Console.ReadLine();
                        EnteringThCorrectAge: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "Enter the new age");
                        string newAge = Console.ReadLine();
                        byte age;
                        result = byte.TryParse(newAge, out age);
                        if (result)
                        {
                            teacher.Name = newName;
                            teacher.Surname = newSurname;
                            teacher.Age = age;
                            _teacherRepository.Update(teacher);
                            
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter correct age");
                            goto EnteringThCorrectAge;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no teacher found");
                        
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter correct age");
                    goto EnteringThCorrectId;
                }
            }
        }
       
     
    }
}





