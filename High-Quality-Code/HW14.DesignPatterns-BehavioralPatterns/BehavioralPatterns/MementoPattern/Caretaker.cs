using System.Collections.Generic;

namespace MementoPattern
{
    public static class Caretaker<T>
    {
        //list of states saved
        private static readonly List<Memento<T>> mementoList = new List<Memento<T>>();
        
        //save state of the originator
        public static void SaveState(Originator<T> originator)
        {
            mementoList.Add(originator.CreateMemento());
        }

        //restore state of the originator
        public static void RestoreState(Originator<T> originator, int stateNumber)
        {
            originator.SetMemento(mementoList[stateNumber]);
        }
    }

}
