namespace CommandPattern
{
    public class Calculator : IReceiver
    {
        private int x;
        private int y;
        private ActionList currentActionList;

        public Calculator(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetAction(ActionList action)
        {
            this.currentActionList = action;
        }

        public int GetResult()
        {
            int result = 0;

            switch (this.currentActionList)
            {
                case ActionList.Add:
                    result = this.x + this.y;
                    break;
                case ActionList.Multiply:
                    result = this.x * this.y;
                    break;
                case ActionList.Substract:
                    result = this.x - this.y;
                    break;
            }

            return result;
        }
    }
}
