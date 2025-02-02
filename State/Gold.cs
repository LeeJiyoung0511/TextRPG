namespace TextRPG
{
    internal class Gold
    {
        public long CurrentGold => _CurrentGold;
        private long _CurrentGold = 0;

        public Gold(long gold)
        {
            _CurrentGold = gold;
        }   

        public void DecreaseGold(long amount)
        {
            if (IsDecreaseGold(amount))
            {
                _CurrentGold -= amount;
                Console.WriteLine($"보유 골드는 {_CurrentGold}G 입니다\n");
            }
        }

        public bool IsDecreaseGold(long gold)
        {
            return _CurrentGold - gold >= 0;
        }
    }
}
