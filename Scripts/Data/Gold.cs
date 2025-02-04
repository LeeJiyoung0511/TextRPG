using Newtonsoft.Json;

namespace TextRPG
{
    internal class Gold
    {
        [JsonIgnore]
        public long Current => _Current;

        [JsonProperty]
        private long _Current = 0;

        public Gold(long gold)
        {
            _Current = gold;
        }

        public void IncreaseGold(long amount)
        {
            if (amount > 0)
            {
                _Current += amount;
            }
        }

        public bool IsDecreaseGold(long amount)
        {
            bool isDecreaseGold = _Current - amount >= 0;

            if (isDecreaseGold)
            {
                _Current -= amount;
            }
            else
            {
                _Current = 0;
            }

            return isDecreaseGold;
        }
    }
}
