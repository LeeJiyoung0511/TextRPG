namespace TextRPG
{
    internal class PurchaseItem : Shop
    {
        static readonly Dictionary<int, ActionBase> _nextActions = new Dictionary<int, ActionBase>
        {
            {0,new Return(0) },
        };

        public PurchaseItem(int number) : base(number)
        {
            ActionName = "아이템구매";
            NextActions = _nextActions;
            OnInputInvalidActionNumber = TryPurchaseItem;
        }

        protected override void OnStart(string sceneName = "")
        {
            sceneName = $"상점 - {ActionName}";
            base.OnStart(sceneName);
        }

        protected override void Display()
        {
            DisplayShopItem(true);
        }

        private void TryPurchaseItem(int number)
        {
            ShopItem purchaseItem = DataManager.Instance.ShopItemDatas[number];

            if (purchaseItem == null)
            {
                TextPrintManager.ColorWriteLine("\n잘못된 입력입니다.", ConsoleColor.DarkRed);
                return;
            }

            //이미 구매한 아이템이라면
            if (purchaseItem.IsPurchase)
            {
                TextPrintManager.ColorWriteLine("\n이미 구매한 아이템 입니다.", ConsoleColor.DarkRed);
                return;
            }
            //구매가 가능하다면
            else
            {
                //보유 금액이 충분하다면
                if (GameData.Gold.IsDecreaseGold(purchaseItem.Price))
                {
                    TextPrintManager.ColorWriteLine($"\n구매를 완료했습니다.", ConsoleColor.Cyan);
                    purchaseItem.IsPurchase = true;
                    DataManager.Instance.HaveItems.Add(purchaseItem.ItemData);
                }
                // 보유금액이 부족하다면
                else
                {
                    TextPrintManager.ColorWriteLine("\n골드가 부족합니다.", ConsoleColor.DarkRed);
                }
            }
        }
    }
}
