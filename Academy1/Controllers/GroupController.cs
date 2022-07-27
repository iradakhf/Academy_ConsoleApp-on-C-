using DataLibrary;
using DataLibrary.Implementation;
using EntityLibarary;
using EntityLibrary;
using RepositoryLibrary.Implementation;


namespace Manage.Controllers
{
    public class GroupController
    {
        public GroupRepository _groupRepository;
        public TeacherRepository _teacherRepository;
        Teacher teacher = new Teacher();
        public GroupController()
        {
            _groupRepository = new GroupRepository();
            _teacherRepository = new TeacherRepository();
        }
        #region CreateGroup
        public void CreateGroup()
        {

            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "enter a group name");
            string groupName = Console.ReadLine();
            var groups = _groupRepository.Get(g => g.Name.ToLower() == groupName);
            if (groups == null)
            {
            EnteringCorrectPatterns: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "enter group maxSize");
                string sizeString = Console.ReadLine();
                int maxSize;
                bool result1 = int.TryParse(sizeString, out maxSize);
                if (result1)
                {

                    Group group = new Group();
                    group.Name = groupName;
                    group.MaxSize = maxSize;
                    var createdGroup = _groupRepository.Create(group);
                    Console.WriteLine($"Group Name is {groupName} Maxsize is {maxSize}");


                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct patterns");
                    goto EnteringCorrectPatterns;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Group already exist");
            }
        }
        #endregion
        #region GetAllGroup
        public void GetAllGroup()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, $"Name {group.Name} , MaxSize {group.MaxSize}");
                }
            }
            else
            {
                Console.WriteLine("no groups found");
            }
        }
        #endregion
        #region UpdateGroup
        public void Update()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                Console.WriteLine("Please choose the group id to update");
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
                    int oldSize = group.MaxSize;
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "please, enter a new group name");
                    string name = Console.ReadLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "please, enter new MaxSize");
                    string maxSizes = Console.ReadLine();
                    int maxSize;
                    result = int.TryParse(maxSizes, out maxSize);
                    if (result)
                    {
                        group.Name = name;
                        group.MaxSize = maxSize;
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "please, enter a correct number for maxSize");
                    }


                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "no group found");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, "no group found");
            }

        }
        #endregion
        #region DeleteGroup
        public void DeleteGroup()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {

                Console.WriteLine("Please choose the group id to update");
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
                    _groupRepository.Remove(group);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "group is removed");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "doesnt exist");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no group on data");
            }
        }
        #endregion
        #region GetGroup
        public void GetGroup()
        {
            var groups = _groupRepository.GetAll();
            Console.WriteLine("Please choose the group id to update");
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
                int size = group.MaxSize;
                string groupName = group.Name;
                Console.WriteLine($"Group Name is {groupName} , group size is {size}");
            }
            else
            {
                Console.WriteLine("group doesnt exist");
            }

        }
        #endregion
        public void AddGroupToTeacher()
        {

            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please choose one of the teacher's id to continue");
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{teacher.Id} : {teacher.Name}");
                }
                string id = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(id, out choosenId);
                if (result)
                {
                    var groups = _groupRepository.GetAll();
                    if (groups.Count != 0)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Please choose group for teacher");
                        foreach (var group in groups)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, $"{group.Name}");
                        }
                        string choosenGroup = Console.ReadLine();
                        var groupChoosen = _groupRepository.Get(g => g.Name == choosenGroup);
                        if (groupChoosen != null)
                        {
                            teacher.Groups.Add(groupChoosen);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Teacher has group named {groupChoosen.Name}");
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no group on data");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is no group on data");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please enter correct id");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "No teacher found");
            }
        }
        public void GetAllGroupsByTeacher()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
            WritingCorrectId: ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please choose teacher id to continue");
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{teacher.Id}: {teacher.Name}");
                }
                string Id = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(Id, out choosenId);
                if (result)
                {
                var teacher1 = _teacherRepository.Get(t => t.Id == choosenId);
                    if (teacher1!=null)
                    {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"{teacher1.Name} {teacher1.Surname} ");
                        foreach (var tgroup in teacher.Groups)
                        {
                            Console.WriteLine($"teacher's groups are {tgroup.Name}");
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "no teacher found");
                        goto WritingCorrectId;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "no teacher found");
                    goto WritingCorrectId;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "no teacher found");
            }
        }
    }
}
