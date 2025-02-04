namespace TextRPG
{
    internal class Rest : ActionBase
    {
        static readonly Dictionary<int, ActionBase> _nextActions = new Dictionary<int, ActionBase>
        {
            {0,new Return(0) },
        };

        private long _RestPrice = 500;

        public Rest(int number) : base(number)
        {
            ActionName = "휴식하기";
            NextActions = _nextActions;
            OnInputInvalidActionNumber = TryRest;
        }

        protected override void Display()
        {
            Console.WriteLine($"{_RestPrice}G를 내면 체력을 회복할 수 있습니다. (보유골드 : {GameData.Gold.Current}G)\n");
            Console.WriteLine("1. 휴식하기(。-ω-)zzz");
        }

        private void TryRest(int number)
        {
            if (number == 1)
            {
                if (GameData.Gold.IsDecreaseGold(_RestPrice))
                {
                    if (GameData.Player.Hp.Current == 100)
                    {
                        TextPrintManager.ColorWriteLine("\n풀피인데요? 500G 잘먹겠습니다!", ConsoleColor.Green);
                    }
                    TextPrintManager.ColorWriteLine("휴식을 완료했습니다.", ConsoleColor.Cyan);
                    GameData.Player.Hp.RecoverMaxHP();
                }
                else
                {
                    TextPrintManager.ColorWriteLine("Gold가 부족합니다.", ConsoleColor.DarkRed);
                }
            }
        }
    }
}
