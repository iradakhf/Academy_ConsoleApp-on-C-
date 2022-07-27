using EntityLibarary;
using EntityLibrary.abstraction;

namespace EntityLibrary
{
    public class Group : IEntity
    {
       
        public string Name { get; set; }
        public int MaxSize { get; set; }
        public int Id { get ; set ; }
        public int CurrentSize { get; set; }
        public Teacher teacher { get; set; }
        

    }
}