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
            }
        }

        public void IncreaseGold(long amount)
        {
            if (amount > 0)
            {
                _CurrentGold += amount;
            }
        }

        public bool IsDecreaseGold(long gold)
        {
            return _CurrentGold - gold >= 0;
        }
    }
}
