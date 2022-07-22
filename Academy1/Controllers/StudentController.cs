using DataLibrary;
using RepositoryLibrary.Implementation;
using EntityLibrary;
namespace Manage.Controllers
{
    public class StudentController

    {
        private GroupRepository _groupRepository;
        private StudentRepository _studentRepository;
        private GroupController _groupController;
        public StudentController()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
            _groupController = new GroupController();
        }
        Student student = new Student();
        #region CreateStudent
        public void CreateStudent()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count != 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Choose one group to continue");
                foreach (var group in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, group.Name);
                }

                var choosenGroup = Console.ReadLine();

                var gr = _groupRepository.Get(g => g.Name.ToLower() == choosenGroup.ToLower());
                if (gr != null)
                {
                    if (gr.CurrentSize < gr.MaxSize)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "enter student name");
                        string name = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "enter student surname");
                        string surname = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please, enter the student's age");
                        string agestr = Console.ReadLine();
                        byte age;
                        bool result = byte.TryParse(agestr, out age);
                    correctAge: if (result)
                        {
                            student.Name = name;
                            student.Age = age;
                            student.Surname = surname;
                            student.Group = gr;
                            student.Group.CurrentSize++;
                            _studentRepository.Create(student);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"New Student Name is {name} , Age is {age}, Id is {student.Id}");

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "not correct age typed");
                            goto correctAge;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "you have exceeded the group size");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"There is no such group on data");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "no group found");
            }

        }
        #endregion
        #region UpdateStudent
        public void UpdateStudent()
        {
            GetAllStudentsByGroup();
            Console.WriteLine("enter id of one student from diplayed students to update choosen student");
            string id = Console.ReadLine();
            int studentId;
            bool result = int.TryParse(id, out studentId);
            if (result)
            {
                var studentsId = _studentRepository.Get(s => s.Id == studentId);
                if (student != null)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please, enter the new name,new age and surname");
                    string newName = Console.ReadLine();
                    string age_str = Console.ReadLine();
                    string newSurname = Console.ReadLine();
                    byte age;
                    result = byte.TryParse(age_str, out age);
                    if (result)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "press 1 if you want to choose a new group for student or 2 if you want to keep it at the same place ");
                        string choosenNumber = Console.ReadLine();
                        if (choosenNumber == "1")
                        {
                            var groups = _groupRepository.GetAll();
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "please indicate group you want to continue with");
                            foreach (var group in groups)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, group.Name);
                            }
                            string choosenGroup = Console.ReadLine();
                            var choosen = _groupRepository.Get(g => g.Name == choosenGroup);
                            if (choosen != null)
                            {
                                student.Age = age;
                                student.Name = newName;
                                student.Surname = newSurname;
                                student.Group = choosen;
                                student.Group.CurrentSize++;
                                _studentRepository.Update(student);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"new Name is {student.Name}, surname is {student.Surname}, age is{student.Age}, id is {id} ");
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "there is no group as indicated");
                            }
                        }
                        else if (choosenNumber == "2")
                        {
                            student.Age = age;
                            student.Name = newName;
                            student.Surname = newSurname;
                            _studentRepository.Update(student);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"new Name is {student.Name}, surname is {student.Surname}, age is{student.Age}, id is {id} ");
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "there is no group as indicated");
                        }
                    }
                    else
                    {
                        Console.WriteLine("enter a correct age");
                    }


                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no student found");
                }

            }
        }


        #endregion

        #region RemoveStudentByGroup
        public void RemoveStudent()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "all groups");
            var groups = _groupRepository.GetAll();
            foreach (var group in groups)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, group.Name);
            }
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "choose one group to remove student from");
            string groupToRemoveStudentFrom = Console.ReadLine();
            var groupGet = _groupRepository.Get(g => g.Name.ToLower() == groupToRemoveStudentFrom.ToLower());
            if (groupGet != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "Please, enter a student name to delete");
                string name = Console.ReadLine();
                var studentToRemove = _studentRepository.Get(s => s.Name.ToLower() == name.ToLower());
                if (studentToRemove != null)
                {
                    _studentRepository.Remove(studentToRemove);
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "no student found");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "group doesnt exist");
            }
        }
        #endregion
        #region GetStudentByGroup
        public void GetStudentByGroup()
        {
            if (_groupRepository.GetAll() != null)
            {

                var groups = _groupRepository.GetAll();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please, choose a group name to continue");
                foreach (var group in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, group.Name);
                }
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
        #region GetAllStudentsByGroup
        public void GetAllStudentsByGroup()
        {

            var groups = _groupRepository.GetAll();
            if (groups != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "choose a group name");
                foreach (var group in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, group.Name);
                }
                string groupName = Console.ReadLine();
                var groupToGetAllStudents = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
                if (groupToGetAllStudents != null)
                {
                    var students = _studentRepository.GetAll();
                    foreach (var student in students)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $" Student name is {student.Name}, surname is {student.Surname}, age is {student.Age}, id is {student.Id}");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "no group like that");

                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "group doesnt exist");
            }
        }
        #endregion
    }
}













