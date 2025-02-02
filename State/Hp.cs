namespace TextRPG
{
    internal class Hp
    {
        public int CurrentHp => _CurrentHp;

        private int _CurrentHp;

        private int _MinHp = 0;
        private int _MaxHp = 100;

        public Hp(int hp)
        {
            _CurrentHp = hp;
        }

        public void RecoverMaxHP()
        {
            _CurrentHp = _MaxHp;
        }

        public void DecreaseHp(int amount)
        {
            if (_CurrentHp - amount >= 0)
            {
                _CurrentHp -= amount;
            }
            else
            {
                _CurrentHp = _MinHp;
            }
        }
    }
}
