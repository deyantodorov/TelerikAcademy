namespace T2.MakePerson
{
    public class Person
    {
        private const string ManName = "Батката";
        private const string NameWomen = "Мацето";

        public Sex Sex { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        /// <summary>
        /// Make person 
        /// </summary>
        /// <param name="age">even for man or odd for women</param>
        public static Person MakePerson(int age)
        {
            Person person = new Person();

            person.Age = age;

            if (age % 2 == 0)
            {
                person.Name = ManName;
                person.Sex = Sex.Man;
            }
            else
            {
                person.Name = NameWomen;
                person.Sex = Sex.Women;
            }

            return person;
        }
    }
}