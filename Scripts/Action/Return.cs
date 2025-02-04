namespace TextRPG
{
    internal class Return : ActionBase
    {
        public Return(int number) : base(number)
        {
            ActionName = "나가기";
        }

        protected override void OnStart(string sceneName)
        {
            Console.Clear();
            Game.DisplayVillageMessage();
        }
    }
}
