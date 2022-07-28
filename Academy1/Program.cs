using DataLibrary;
using static EntityLibrary.Constatnts.Constants;
using Manage.Controllers;
using DataLibrary.Implementation;

namespace Manage
{
    public class Program
    {
        public static void Main(string[] args)

        {

            AdminController _adminController = new AdminController();
            
            
        AdminAutetication: var admin = _adminController.Autenticate();
            if (admin != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"Welcome {admin.Username}");
                Console.WriteLine("   ");
            Initial: Console.WriteLine("Please enter 0 if you want to continue with group , 1 if you want to continue with student, 2 to continue with teacher or 3 to exit ");
                string number = Console.ReadLine();

                try
                {
                    while (true)
                    {

                        if (number == "0")
                        {
                            GroupController _groupController = new GroupController();
                            while (true)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Select one of the options"); 
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "0-Exit");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "1-create group");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "2-update group");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "3-remove group");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "4-get group");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "5-get all groups");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "6-Add Group To Teacher");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "7-Get All Groups By Teacher");
                                string number1 = Console.ReadLine();
                                int selected;
                                bool result = int.TryParse(number1, out selected);
                                if (result)
                                {
                                    if (selected >= 0 && selected < 8)
                                    {
                                        switch (selected)
                                        {

                                            case (int)Options.CreateGroup:
                                                _groupController.CreateGroup();
                                                goto Initial;
                                                break;

                                            case (int)Options.UpdateGroup:
                                                _groupController.Update();
                                                goto Initial;
                                                break;
                                            case (int)Options.RemoveGroup:
                                                _groupController.DeleteGroup();
                                                goto Initial;
                                                break;
                                            case (int)Options.GetGroup:
                                                _groupController.GetGroup();
                                                goto Initial;
                                                break;
                                            case (int)Options.GetAllGroups:
                                                _groupController.GetAllGroup();
                                                goto Initial;
                                                break;
                                            case (int)Options.AddGroupToTeacher:
                                                _groupController.AddGroupToTeacher();
                                                goto Initial;
                                                break;
                                            case (int)Options.GetAllGroupsByTeacher:
                                                _groupController.GetAllGroupsByTeacher();
                                                goto Initial;
                                                break;
                                            case (int)Options.Exit:
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "you exit");
                                                goto Initial;
                                                return;
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter correct number");

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Please enter correct number");
                                }
                            }
                        }
                        else if (number == "1")
                        {
                            StudentController _studentController = new StudentController();
                            while (true)
                            {
                            ChoosingCorrectPattern: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "0-Exit");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "1-create student");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "2-update student");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "3-remove student by group");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "4-get student by group");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "5-get all students by group");

                                string number1 = Console.ReadLine();
                                int selectedOption;
                                bool result = int.TryParse(number1, out selectedOption);
                                if (result)
                                {
                                    if (selectedOption >= 0 && selectedOption <= 5)
                                    {

                                        switch (selectedOption)
                                        {
                                            
                                            case (int)Options2.CreateStudent:
                                                _studentController.CreateStudent();
                                                goto Initial;
                                                break;
                                            case (int)Options2.UpdateStudent:
                                                _studentController.UpdateStudent();
                                                goto Initial;
                                                break;
                                            case (int)Options2.RemoveStudent:
                                                _studentController.RemoveStudent();
                                                goto Initial;
                                                break;
                                            case (int)Options2.GetStudentByGroup:
                                                _studentController.GetStudentByGroup();
                                                goto Initial;
                                                break;
                                            case (int)Options2.GetAllStudentsByGroup:
                                                _studentController.GetAllStudentsByGroup();
                                                goto Initial;
                                                break;
                                            case (int)Options2.Exit:
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "you exit");
                                                goto Initial; ;
                                                return;
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You have not entered a correct digit");
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "please, type a correct pattern");
                                    goto ChoosingCorrectPattern;
                                }
                            }

                        }
                        else if (number=="2")
                        {
                            TeacherController _teacherController = new TeacherController();
                            while (true)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "0-Exit");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "1-create teacher");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "2-update teacher");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "3-remove teacher");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "4-get teacher");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "5-get all teachers"); 

                                string number1 = Console.ReadLine();
                                int selected;
                                bool result = int.TryParse(number1, out selected);
                                if (result)
                                {
                                    if (selected >= 0 && selected < 6)
                                    {
                                        switch (selected)
                                        {

                                            case (int)Options3.CreateTeacher:
                                                _teacherController.Create();
                                                goto Initial;
                                                break;

                                            case (int)Options3.UpdateTeacher:
                                                _teacherController.Update();
                                                goto Initial;
                                                break;
                                            case (int)Options3.RemoveTeacher:
                                                _teacherController.Remove();
                                                goto Initial;
                                                break;
                                            case (int)Options3.GetTeacher:
                                                _teacherController.Get();
                                                goto Initial;
                                                break;
                                            case (int)Options3.GetAllTeachers:
                                                _teacherController.GetAll();
                                                goto Initial;
                                                break;
                                            case (int)Options3.Exit:
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "you exit");
                                                goto Initial;
                                                return;
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter correct number");

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Please enter correct number");
                                }
                            }
                        }
                        else if (number == "3")
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "you exit");
                            break;
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "You have not entered a right digit, to continue press 5");
                            string typedNumber = Console.ReadLine();
                            if (typedNumber == "5")
                            {
                                goto Initial;
                            }
                            else
                            {
                                Console.WriteLine("Thanks for visiting");
                                break;
                            }

                        }
                    }
                }
                catch
                {
                    Console.WriteLine("thanks for visiting");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "please enter the correct password");
                goto AdminAutetication;
            }

        }
    }
}
