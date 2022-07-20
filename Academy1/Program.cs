using System;
using DataLibrary;
using RepositoryLibrary.Implementation;
using static EntityLibrary.Constatnts.Constants;
using EntityLibrary;

namespace Manage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GroupRepository groupRepository = new GroupRepository();
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
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "4-get all groups");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "5-get group by size");

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
                                    #region
                                    case (int)Options.CreateGroup:
                                    groupName: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "enter a group name");
                                        string groupName = Console.ReadLine();
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "Group maxSize");
                                        string sizeString = Console.ReadLine();
                                        int maxSize;
                                        bool result1 = int.TryParse(sizeString, out maxSize);
                                        if (result1)
                                        {
                                            Console.WriteLine($"Group Name is {groupName} Maxsize is {maxSize}");
                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct patterns");
                                            goto groupName;
                                        }
                                        break;
                                    #endregion
                                    case (int)Options.UpdateGroup:
                                       
                                        break;
                                    case (int)Options.RemoveGroup:
                                        break;
                                    case (int)Options.GetGroup:
                                        break;
                                    case (int)Options.GetAllGroups:
                                       var groups = groupRepository.GetAll();
                                        foreach(var group in groups)
                                        {

                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, $"Name {group.Name} , MaxSize {group.MaxSize}");
                                        }
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
