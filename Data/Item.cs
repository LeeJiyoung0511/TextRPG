using Newtonsoft.Json;
using System.Text;

namespace TextRPG
{

    public enum ItemType
    {
        Weapon,
        Armor
    }

    internal class Item
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float AttackPower { get; set; }
        public float DefensePower { get; set; }
        public ItemType ItemType { get; set; }

        [JsonIgnore]
        public bool IsEquipped
        {
            get => _IsEquipped;
            set
            {
                _IsEquipped = value;
                UpdateEquipState();
            }
        }

        [JsonProperty]
        private bool _IsEquipped = false;

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
                sb.Append($" | 공격력 + {AttackPower} |");
            }

            if (DefensePower != 0)
            {
                sb.Append($" | 방어력 + {DefensePower} |");
            }

            sb.Append(Description);

            return sb.ToString();
        }

        private void UpdateEquipState()
        {
            if(IsEquipped)
            {
                DataManager.Instance.EquippedItems.Add(ItemType, this);
                GameData.Player.Stat.AddAttackPower += AttackPower;
                GameData.Player.Stat.AddDefensePower += DefensePower;
                TextPrintManager.ColorWriteLine($"\n{Name}을(를) 장착했습니다.", ConsoleColor.Cyan);
            }
            else
            {
                DataManager.Instance.EquippedItems.Remove(ItemType);
                GameData.Player.Stat.AddAttackPower -= AttackPower;
                GameData.Player.Stat.AddDefensePower -= DefensePower;
                TextPrintManager.ColorWriteLine($"\n{Name}을(를) 장착해제했습니다.", ConsoleColor.Cyan);
            }
        }
    }
}
