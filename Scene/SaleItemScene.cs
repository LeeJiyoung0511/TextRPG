namespace TextRPG
{
    internal class SaleItemScene : ShopScene
    {
        static readonly Dictionary<int, SceneBase> _nextScenes = new Dictionary<int, SceneBase>
        {
            {0,new ReturnScene(0) },
        };

        public SaleItemScene(int number) : base(number)
        {
            SceneName = "아이템판매";
            NextScenes = _nextScenes;
            OnInputInvalidActionNumber = SaleItem;
        }

        public override void OnStart(string sceneName = "")
        {
            sceneName = $"상점 - {SceneName}";
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

        private void SaleItem(int number)
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
                TextPrintManager.ColorWriteLine($"{saleItem.ItemData.Name}이 판매되었습니다.", ConsoleColor.Cyan);
                GameData.Gold.IncreaseGold(saleItem.SalePrice);
            }
        }
    }
}
