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

         ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "enter a group name");
            string groupName = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "enter group maxSize");
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
                
            }
        }
        #endregion
        #region GetAllGroup
        public void GetAllGroup()
        { 
            var groups = _groupRepository.GetAll();
            if (groups.Count !=0)
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
            Console.WriteLine("Please choose the group to update");
            var groups = _groupRepository.GetAll();
            foreach (var group1 in groups)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, group1.Name);
            }
            string groupName = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
            if (group != null)
            {
                int oldSize= group.MaxSize;
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "please, enter a new group name");
                string name= Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "please, enter new MaxSize");
                string maxSizes = Console.ReadLine();
                int maxSize;
                 bool result = int.TryParse(maxSizes, out maxSize);
                if (result)
                {
                    group.Name =name;
                    group.MaxSize= maxSize;
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
        #endregion
        #region DeleteGroup
        public void DeleteGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGreen, "please choose the group you want to delete from displayed");
            
            var groups = _groupRepository.GetAll();
            foreach (var group1 in groups)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, group1.Name);
            }
            string groupName = Console.ReadLine();
            var group = _groupRepository.Get(g=>g.Name.ToLower()==groupName.ToLower());
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
        #endregion
        #region GetGroup
        public void GetGroup()
        {
            var groups = _groupRepository.GetAll();
            Console.WriteLine("Please enter the name of the group you want to get");
            foreach (var group2 in groups)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, group2.Name);
            }
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());

            if (group!=null)
            {
                int size=group.MaxSize;
                string groupName = group.Name;
                Console.WriteLine($"Group Name is {groupName} , group size is {size}");
            }
            else
            {
                Console.WriteLine("group doesnt exist");
            }
           
        }
        #endregion
       
    }
}
