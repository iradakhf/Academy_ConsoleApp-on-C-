using EntityLibrary.abstraction;


namespace EntityLibrary
{
    public class Student : IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Id { get; set ; }

        public Group Group {get; set; }
    }
}
