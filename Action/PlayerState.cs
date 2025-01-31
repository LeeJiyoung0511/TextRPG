namespace TextRPG
{
    internal class PlayerState : Action
    {
        public PlayerState(int number) : base(number)
        {
            ActionName = "상태보기";
        }

        public override void Select()
        {

        }
    }
}
