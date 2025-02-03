namespace TextRPG
{
    internal class Gold
    {
        public long Current => _Current;
        private long _Current = 0;

        public Gold(long gold)
        {
            _Current = gold;
        }

        public void DecreaseGold(long amount)
        {
            if (IsDecreaseGold(amount))
            {
                _Current -= amount;
            }
        }

        public void IncreaseGold(long amount)
        {
            if (amount > 0)
            {
                _Current += amount;
            }
        }

        public bool IsDecreaseGold(long gold)
        {
            return _Current - gold >= 0;
        }
    }
}
