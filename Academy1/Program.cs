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

        {   GroupController _groupController = new GroupController();
            
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "Welcome");
            Console.WriteLine("   ");
            Console.WriteLine("Please enter 0 if you want to continue");
            string number = Console.ReadLine();

            try
            {
                if (number == "0")
                {
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
                                        break;
                                   
                                    case (int)Options.UpdateGroup:
                                        _groupController.Update();
                                        break;
                                    case (int)Options.RemoveGroup:
                                        _groupController.DeleteGroup();
                                        break;
                                    case (int)Options.GetGroup:
                                        _groupController.GetGroup();
                                        break;
                                    case (int)Options.GetAllGroups:
                                        _groupController.GetAllGroup();
                                        break;
                                    case (int)Options.Exit:
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.White, "you exit");
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
            }
            catch
            {
                Console.WriteLine("thanks for visiting");
            }

        }
    }
}
