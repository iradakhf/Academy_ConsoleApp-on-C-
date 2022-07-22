using DataLibrary;
using RepositoryLibrary.Implementation;
using EntityLibrary;
namespace Manage.Controllers
{
    public class StudentController

    {
        private GroupRepository _groupRepository;
        private StudentRepository _studentRepository;
        public StudentController()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }
        Student student = new Student();
        #region CreateStudent
        public void CreateStudent()
        {


            var groups = _groupRepository.GetAll();
            if (groups.Count != 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "in order to create student, please choose one of the groups below");
                foreach (var group in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, group.Name);
                }
                var choosenGroup = Console.ReadLine();

                var gr = _groupRepository.Get(g => g.Name.ToLower() == choosenGroup.ToLower());
                if (gr != null)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Please enter the student name and surname");
                    string name = Console.ReadLine();
                    string surname = Console.ReadLine();

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please, enter the student's age");
                    string agestr = Console.ReadLine();
                    int age;
                    bool result = int.TryParse(agestr, out age);

                    student.Name = name;
                    student.Age = age;
                    student.Surname = surname;
                    student.Group = gr;
                    _studentRepository.Create(student);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"New Student Name is {name} , Age is {age}");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"There is no such group on data");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please create the group to continue");
            }
        }





        #endregion
        #region UpdateStudent
        public void UpdateStudent()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "Please, enter a student name to update");
            string name1 = Console.ReadLine();

            var student = _studentRepository.Get(s => s.Name.ToLower() == name1.ToLower());
            if (student != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please, enter the new name,new age and surname");
                string newName = Console.ReadLine();
                string age_str = Console.ReadLine();
                byte age;
                bool result = byte.TryParse(age_str, out age);
                if (result)
                {
                    string newSurname = Console.ReadLine();
                    student.Age = age;
                    student.Name = name1;
                    student.Surname = newSurname;
                    _studentRepository.Update(student);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"new Name is {student.Name}, surname is {student.Surname}, age is{student.Age} ");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter age in number format");
                }
            }
            else
            {
                Console.WriteLine("no student");
            }

        }
        #endregion
        #region RemoveStudentByGroup
        //public void RemoveStudent()
        //{ 
        //    ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "Please, enter a student name to delete");
        //    string name = Console.ReadLine();

        //   foreach(var stu in Data.Students)
        //    {
        //     Data.Students.FindAll(s => s.Name.ToLower() == name.ToLower());
        //        Console.WriteLine($"{s}");
        //    }
        //}
        #endregion
        #region GetStudentByGroup
        public void GetStudentByGroup()
        {
            if (_groupRepository.GetAll() != null)
            {

            var groups = _groupRepository.GetAll();
            foreach (var group in groups)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, group.Name);
            }
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please, choose a group name to continue");
            string choosenGroup = Console.ReadLine();
            var gr = _groupRepository.Get(g => g.Name.ToLower() == choosenGroup.ToLower());
            if (gr != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "please, enter student name");
                string studentName = Console.ReadLine();
                var students = _studentRepository.GetAll(g => g.Group.Id == gr.Id);
                if (students.Count != 0)
                {
                    var choosenStudent = _studentRepository.Get(s => s.Name.ToLower() == studentName.ToLower());
                    if (choosenStudent != null)
                    {
                        
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"id is {choosenStudent.Id}, Name is {choosenStudent.Name}, surname is {choosenStudent.Surname}, age is{choosenStudent.Age}");

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "there is no student like typed in the group");
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no student in the group");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, choose existing group or create one");
            }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "please create a group");
            }
        }
        #endregion
    }
}



