using DataLibrary;
using EntityLibrary;
using RepositoryLibrary.Implementation;


namespace Manage.Controllers
{
    public class GroupController
    {
        public GroupRepository _groupRepository;
        public GroupController()
        {
            _groupRepository = new GroupRepository();
        }
        #region CreateGroup
        public void CreateGroup()
        {

        groupName: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "enter a group name");
            string groupName = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "Group maxSize");
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
                goto groupName;
            }
        }
        #endregion
        #region GetAllGroup
        public void GetAllGroup()
        {
            var groups = _groupRepository.GetAll();
            foreach (var group in groups)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, $"Name {group.Name} , MaxSize {group.MaxSize}");
            }
        }
        #endregion
        #region UpdateGroup
        public void Update()
        {
            Console.WriteLine("Please choose the group to update");
            string groupName = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
            if (group != null)
            {
                int oldSize= group.MaxSize;
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "please, enter a group name");
                string name= Console.ReadLine();
                group.Name =name;
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "please, enter MaxSize");
                string maxSizes = Console.ReadLine();
                int maxSize;
                 bool result = int.TryParse(maxSizes, out maxSize);
                if (result)
                {
                    group.MaxSize= maxSize;
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "please, enter number");
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
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "please enter the group you want to delete");
            string groupName = Console.ReadLine();
            var group = _groupRepository.Get(g=>g.Name.ToLower()==groupName.ToLower());
            if (group != null)
            {
                _groupRepository.Remove(group);
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "doesnt exist");
            }
        }
        #endregion
        #region GetGroup
        public void GetGroup()
        {
            Console.WriteLine("Please enter the name");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());

            if (group!=null)
            {
                int size=group.MaxSize;
                string groupName = group.Name;
                Console.WriteLine($"Group Name is {groupName} , group size is {size}");
            }
           
        }
        #endregion
       
    }
}
