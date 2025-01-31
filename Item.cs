using System.Text;

namespace TextRPG
{
    internal class Item
    {
        public string Name;
        public string Description;
        public float AttackPower;
        public float DefensePower;
        public bool IsEquipped;

        public Item()
        {
            Name = "";
            Description = "";
            AttackPower = 0f;
            DefensePower = 0f;
            IsEquipped = false;
        }

        public string GetItemInfo()
        {
            StringBuilder sb = new StringBuilder();

            if (IsEquipped)
            {
                sb.Append("[E]");
            }
            sb.Append(Name);

            if (AttackPower != 0)
            {
                sb.Append($" | 공격력 +{AttackPower} |");
            }
            if (DefensePower == 0)
            {
                sb.Append($" | 방어력 +{DefensePower} |");
            }

            sb.Append(Description);

            return sb.ToString();
        }

    }
}
