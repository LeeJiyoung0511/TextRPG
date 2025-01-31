using TextRPG.Scene;

namespace TextRPG
{
    internal class ShopScene : SceneBase
    {
        static readonly Dictionary<int, SceneBase> _nextScenes = new Dictionary<int, SceneBase>
        {
            {1,new PurchaseItemScene(1) },
            {0,new ReturnScene(0) },
        };

        public ShopScene(int number) : base(number)
        {
            SceneName = "상점";
            NextScenes = _nextScenes;
        }

        public override void Display()
        {
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다");
            Console.WriteLine($"\n[보유골드]\n{GameManager.State.Gold}G\n");
            Console.WriteLine("[아이템목록]\n");

            foreach (var shopItem in DataManager.ShopItemDatas)
            {
                Console.WriteLine("- " + shopItem.GetShopItemInfo() + "\n");
            }

            base.Display();
        }
    }
}
