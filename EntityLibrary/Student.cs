using EntityLibarary;
using EntityLibrary.abstraction;


namespace EntityLibrary
{
    public class Student : Teacher, IEntity
    {
        
        public int Id { get; set ; }

        public Group Group {get; set; }
    }
}
