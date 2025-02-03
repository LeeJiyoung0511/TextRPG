﻿using System.Text;

namespace TextRPG
{
    public enum ItemType
    {
        Weapon,
        Armor
    }

    internal class Item
    {
        public string Name;
        public string Description;
        public float AttackPower;
        public float DefensePower;

        public bool IsEquipped
        {
            get => isEquipped;
            set
            {
                isEquipped = value;
                UpdateEquipState();
            }
        }
        private bool isEquipped = false;

        public int OrderNumber;
        public ItemType ItemType;

        public Item()
        {
            Name = "";
            Description = "";
            AttackPower = 0;
            DefensePower = 0;
            OrderNumber = 0;
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
                DataManager.EquippedItems.Add(ItemType, this);
                GameData.Player.Stat.AddAttackPower += AttackPower;
                GameData.Player.Stat.AddDefensePower += DefensePower;
                TextPrintManager.ColorWriteLine($"\n{Name}을 장착했습니다.", ConsoleColor.Cyan);
            }
            else
            {
                DataManager.EquippedItems.Remove(ItemType);
                GameData.Player.Stat.AddAttackPower -= AttackPower;
                GameData.Player.Stat.AddDefensePower -= DefensePower;
                TextPrintManager.ColorWriteLine($"\n{Name}을 장착해제했습니다.", ConsoleColor.Cyan);
            }
        }
    }
}
