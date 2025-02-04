namespace TextRPG
{
    internal class SaleItem : Shop
    {
        static readonly Dictionary<int, ActionBase> _nextActions = new Dictionary<int, ActionBase>
        {
            {0,new Return(0) },
        };

        public SaleItem(int number) : base(number)
        {
            ActionName = "아이템판매";
            NextActions = _nextActions;
            OnInputInvalidActionNumber = TrySaleItem;
        }

        public override void OnStart(string sceneName = "")
        {
            sceneName = $"상점 - {ActionName}";
            base.OnStart(sceneName);
        }

        public override void Display()
        {
            DisplayText();
            DisplayItem();
        }

        private void DisplayItem()
        {
            for (int i = 0; i < DataManager.Instance.HaveItems.Count; i++)
            {
                Item item = DataManager.Instance.HaveItems[i];
                Console.WriteLine($"- {i + 1}.{item.GetItemInfo()} | {DataManager.Instance.ShopItemDatas[item.Id]} G \n");
            }
        }

        private void TrySaleItem(int number)
        {
            ShopItem saleItem = DataManager.Instance.ShopItemDatas[number];

            if (saleItem == null)
            {
                TextPrintManager.ColorWriteLine("\n잘못된 입력입니다.", ConsoleColor.DarkRed);
                return;
            }
            else
            {
                if (saleItem.ItemData.IsEquipped)
                {
                    saleItem.ItemData.IsEquipped = false;
                }
                DataManager.Instance.HaveItems.Remove(saleItem.ItemData);
                TextPrintManager.ColorWriteLine($"{saleItem.ItemData.Name}이(가) 판매되었습니다.", ConsoleColor.Cyan);
                GameData.Gold.IncreaseGold(saleItem.SalePrice);
            }
        }
    }
}
