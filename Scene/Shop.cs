using System.Text;

namespace TextRPG
{
    internal class Shop : ActionBase
    {
        static readonly Dictionary<int, ActionBase> _nextActions = new Dictionary<int, ActionBase>
        {
            {1,new PurchaseItem(1) },
            {2,new SaleItem(2) },
            {0,new Return(0) },
        };

        public Shop(int number) : base(number)
        {
            ActionName = "상점";
            NextActions = _nextActions;
        }

        public override void Display()
        {
            DisplayText();
            DisplayShopItem();
        }

        public void DisplayShopItem(bool isPurchaseScene = false)
        {
            foreach(var shopItem in DataManager.Instance.ShopItemDatas.Values)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("- ");
                if (isPurchaseScene)
                {
                    sb.Append($"{shopItem.ShopId}.");
                }
                Console.WriteLine($"\n{sb}{shopItem.GetShopItemInfo()}");
            }
        }

        public void DisplayText()
        {
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다");
            Console.WriteLine($"\n[보유골드]\n{GameData.Gold.Current}G\n");
            Console.WriteLine("[아이템목록]");
        }
    }
}
