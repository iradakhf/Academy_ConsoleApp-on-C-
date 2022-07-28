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
                Console.WriteLine("Please choose the group id to create");
                foreach (var group1 in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, $"ID is {group1.Id}, Name is {group1.Name}");
                }
                int id;
                string groupId = Console.ReadLine();
                bool result = int.TryParse(groupId, out id);
                var group = _groupRepository.Get(g => g.Id == id);
                if (group != null)
                {
                    if (group.CurrentSize < group.MaxSize)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "enter student name");
                        string name = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "enter student surname");
                        string surname = Console.ReadLine();

                    correctAge: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please, enter the student's age");
                        string agestr = Console.ReadLine();
                        byte age;
                        result = byte.TryParse(agestr, out age);
                        if (result)
                        {
                            student.Name = name;
                            student.Age = age;
                            student.Surname = surname;
                            student.Group = group;
                            ++student.Group.CurrentSize;
                            _studentRepository.Create(student);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"New student's name is {name} , surname is, {surname} Age is {age}, Id is {student.Id}");

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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "no group found, in order to create student, please create group first");
            }

        }
        #endregion
        #region UpdateStudent
        public void UpdateStudent()
        {
            _studentRepository.GetAll();
            if (_studentRepository.GetAll().Count != 0)
            {

                Group oldGroup = GetAllStudentsByGroup();

                Console.WriteLine("enter id of one student from diplayed students to update choosen student");
            WriteInCorrectFormat: string id = Console.ReadLine();
                int studentId;
                bool result = int.TryParse(id, out studentId);
                if (result)
                {
                    var studentsId = _studentRepository.Get(s => s.Id == studentId);
                    if (student != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please, enter the new name");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please, enter the new surname");
                        string newSurname = Console.ReadLine();
                    WriteCorrectAge: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please, enter the new age");
                        string age_str = Console.ReadLine();
                        byte age;
                        result = byte.TryParse(age_str, out age);
                        if (result)
                        {
                        ChoosingGroup: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "press 1 if you want to choose a new group for student or 2 if you want to keep it at the same place ");
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
                                    if (choosen.Name != oldGroup.Name)
                                    {
                                        student.Age = age;
                                        student.Name = newName;
                                        student.Surname = newSurname;
                                        student.Group = choosen;
                                        ++student.Group.CurrentSize;
                                        _studentRepository.Update(student);
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"new Name is {student.Name}, surname is {student.Surname}, age is{student.Age}, id is {id} ");
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "You have choosen the same group");
                                        goto ChoosingGroup;
                                    }

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
                            goto WriteCorrectAge;
                        }


                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no student found");
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter in the correct format");
                    goto WriteInCorrectFormat;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "there is no student on data");
            }
        }


        #endregion

        #region RemoveStudentByGroup
        public void RemoveStudent()
        {
            
            if (student.Groups!= null)
            {
                GetAllStudentsByGroup();
            TypingId: ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "Please, enter a student id to delete a student");
            string studentId = Console.ReadLine();
            int id;
            bool result = int.TryParse(studentId, out id);
            if (result)
            {

                var studentToRemove = _studentRepository.Get(s => s.Id == id);
                if (studentToRemove != null)
                {
                    _studentRepository.Remove(studentToRemove);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "successfully removed");

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "no student found");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "please, enter the correct format");
                goto TypingId;
            }

        }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "no group found on data");
            }

            }
        #endregion
        #region GetStudentByGroup
        public void GetStudentByGroup()
        {
            var groups = _groupRepository.GetAll();
            if (_groupRepository.GetAll().Count != 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please, choose a group name to continue with student of that group");
                foreach (var group in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, group.Name);
                }
                string choosenGroup = Console.ReadLine();
                var gr = _groupRepository.Get(g => g.Name.ToLower() == choosenGroup.ToLower());
                if (gr != null)
                {
                    student.Group = gr;
                    var students = _studentRepository.GetAll(s => s.Group.Id == gr.Id);
                    if (students.Count != 0)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "please, choose student id");
                        foreach (var student in students)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $" name is {student.Name}, id is {student.Id}");
                        }
                        string sId = Console.ReadLine();
                        int studentId;
                        bool result = int.TryParse(sId, out studentId);
                        if (result)
                        {

                        var choosenStudent = _studentRepository.Get(s => s.Id== studentId);
                        if (choosenStudent != null)
                        {

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"id is {choosenStudent.Id}, Name is {choosenStudent.Name}, surname is {choosenStudent.Surname}, age is{choosenStudent.Age}");

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "there is no student like typed in the group");
                        }

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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "please create a group to continue");
            }
        }
        #endregion
        #region GetAllStudentsByGroup
        public Group GetAllStudentsByGroup()
        {

        var groups = _groupRepository.GetAll();
        if (groups.Count!= 0)
            {
                Console.WriteLine("Please choose the group id to get all students by group");
                foreach (var group1 in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, $"ID is {group1.Id}, Name is {group1.Name}");
                }
                int id;
                string groupId = Console.ReadLine();
                bool result = int.TryParse(groupId, out id);
                var group = _groupRepository.Get(g => g.Id == id);
                if (group != null)
                {
                    var allStudentsOfTheGroup = _studentRepository.GetAll(s => s.Group.Id == group.Id);
                    if (allStudentsOfTheGroup.Count != 0)
                    {
                        foreach (var student in allStudentsOfTheGroup)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $" Student name is {student.Name}, surname is {student.Surname}, age is {student.Age}, id is {student.Id}");
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "there is no student in this group");
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
            return student.Group;
        }
        #endregion

    }
}













