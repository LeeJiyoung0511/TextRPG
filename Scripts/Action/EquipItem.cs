namespace TextRPG
{
    internal class EquipItem : Inventory
    {
        static readonly Dictionary<int, ActionBase> _nextActions = new Dictionary<int, ActionBase>
        {
            {0,new Return(0) },
        };

        public EquipItem(int number) : base(number)
        {
            ActionName = "장착관리";
            NextActions = _nextActions;
            OnInputInvalidActionNumber = TryEquipItem;
        }

        protected override void OnStart(string sceneName)
        {
            sceneName = $"인벤토리 - {ActionName}";
            base.OnStart(sceneName);
        }

        protected override void Display()
        {
            DisPlayHaveItems(true);
        }

        private void TryEquipItem(int number)
        {
            Item haveItem = DataManager.Instance.ItemDatas[number];

            if (haveItem == null)
            {
                TextPrintManager.ColorWriteLine("\n잘못된 입력입니다.", ConsoleColor.DarkRed);
                return;
            }
            else
            {
                if (DataManager.Instance.EquippedItems.TryGetValue(haveItem.ItemType, out Item equippedItem))
                {
                    if(haveItem.Id != equippedItem.Id)
                    {
                        equippedItem.IsEquipped = false;
                    }
                }
                haveItem.IsEquipped = !haveItem.IsEquipped;
            }
        }

    }
}
