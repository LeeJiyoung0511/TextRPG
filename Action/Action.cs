namespace TextRPG
{
    internal abstract class Action
    {
        public int ActionNumber;
        public string ActionName;

        public Action(int actionNumber)
        {
            ActionNumber = actionNumber;
            ActionName = "";
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{ActionNumber}. {ActionName}");
        }

        public abstract void Select();
    }
}
