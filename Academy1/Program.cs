using System;
using DataLibrary;
using RepositoryLibrary.Implementation;
using static EntityLibrary.Constatnts.Constants;
using EntityLibrary;
using Manage.Controllers;

namespace Manage
{
    public class Program
    {
        public static void Main(string[] args)

        {   
            
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "Welcome");
            Console.WriteLine("   ");
            Initial:  Console.WriteLine("Please enter 0 if you want to continue with group or 1 if you want to continue with student ");
            string number = Console.ReadLine();

            try
            {
                if (number == "0")
                {
                    GroupController _groupController = new GroupController();
                    while (true)
                    {   
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "0-Exit");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "1-create group");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "2-update group");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "3-remove group");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "4-get group");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "5-get all groups");

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Select one of the options");
                        string number1 = Console.ReadLine();
                        int selected;
                        bool result = int.TryParse(number1, out selected);
                        if (result)
                        {
                            if (selected >= 0 && selected < 6)
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
                else if(number=="1")
                {
                    StudentController _studentController = new StudentController();
                    while (true)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "0-Exit");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "1-create student");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "2-update student");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "3-remove student by group");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "4-get student by group");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "5-get all students");

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Select one of the options");
                        string number1 = Console.ReadLine();
                        int selectedOption;
                        bool result = int.TryParse(number1, out selectedOption);
                        if(selectedOption>=0&& selectedOption <= 5)
                        {

                        switch (selectedOption)
                        {
                            case (int)Options2.Exit:
                                break;
                            case (int)Options2.CreateStudent:
                                 _studentController.CreateStudent();
                                goto Initial;
                                break;
                            case (int) Options2.UpdateStudent:
                                _studentController.UpdateStudent();
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
                        }
                        }
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "You have not entered a right digit, to continue press 5");
                    if (number == "5")
                    {
                        goto Initial;
                    }
                    else
                    {
                        Console.WriteLine("Thanks for visiting");
                    }

                }
            }
            catch
            {
                Console.WriteLine("thanks for visiting");
            }

        }
    }
}
