namespace TextRPG
{
    internal class Hp
    {
        public int Current => _Current;

        private int _Current;

        private int _MinHp = 0;
        private int _MaxHp = 100;

        public Hp(int hp)
        {
            _Current = hp;
        }

        public void RecoverMaxHP()
        {
            _Current = _MaxHp;
        }

        public void DecreaseHp(int amount)
        {
            if (_Current - amount >= 0)
            {
                _Current -= amount;
            }
            else
            {
                _Current = _MinHp;
            }
        }
    }
}
