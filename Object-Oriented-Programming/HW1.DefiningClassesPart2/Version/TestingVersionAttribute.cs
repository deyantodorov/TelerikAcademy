namespace Version
{
    using System;

    public class TestingVersionAttribute
    {
        private static void Main()
        {
            SimpleClass myTest = new SimpleClass();
            Type myType = typeof(SimpleClass);

            object[] myAttributes = myType.GetCustomAttributes(false);

            foreach (VersionAttribute item in myAttributes)
            {
                Console.WriteLine("{0} {1}", item, item.Version);
            }
        }
    }
}