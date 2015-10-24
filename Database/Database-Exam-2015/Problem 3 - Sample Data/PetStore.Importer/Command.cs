namespace PetStore.Importer
{
    using System.Collections.Generic;
    using PetStore.Data;

    public abstract class Command : ICommand
    {
        protected readonly RandomGenerator Generator;
        protected PetStoreEntities Data;
        
        protected Command(PetStoreEntities data)
        {
            this.Data = data;
            this.Generator = new RandomGenerator();
        }

        public abstract void Execute();

        public string Message()
        {
            return this.GetType().Name + " added";
        }

        protected HashSet<string> GenerateSomeRandomeStrings(int minLength = 1, int maxLength = 10, int count = 10)
        {
            var result = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                result.Add(this.Generator.GetRandomString(minLength, maxLength));
            }

            return result;
        }
    }
}
