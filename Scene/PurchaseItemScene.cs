using System.Text;

namespace TextRPG
{
    internal class PurchaseItemScene : ShopScene
    {
        static readonly Dictionary<int, SceneBase> _nextScenes = new Dictionary<int, SceneBase>
        {
            {0,new ReturnScene(0) },
        };

        public PurchaseItemScene(int number) : base(number)
        {
            SceneName = "아이템구매";
            NextScenes = _nextScenes;
        }

        public override void OnStart(string sceneName = "")
        {
            sceneName = $"상점 - {SceneName}";
            base.OnStart(sceneName);
        }

        public override void Display()
        {
            DisplayShopItem(true);
            ExecutePurchaseItem();
        }

        public void ExecutePurchaseItem()
        {
            string inputNumber = "";
            int number = 0;

            ShopItem purchaseItem = new ShopItem();

            while (true)
            {
                GameManager.DisplayScene(_nextScenes);

                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                inputNumber = Console.ReadLine();
                number = int.Parse(inputNumber);

                if (_nextScenes.ContainsKey(number))
                {
                    _nextScenes[number].OnStart();
                    break;
                }

                purchaseItem = DataManager.ShopItemDatas[number - 1];

                if (purchaseItem == null)
                {
                    Console.WriteLine("잘못된 입력입니다");
                    continue;
                }

                //이미 구매한 아이템이라면
                if (purchaseItem.IsPurchase)
                {
                    Console.WriteLine("이미 구매한 아이템 입니다");
                    continue;
                }
                //구매가 가능하다면
                else
                {
                    //보유 금액이 충분하다면
                    if (GameManager.State.Gold.IsDecreaseGold(purchaseItem.Price))
                    {
                        Console.WriteLine("구매를 완료했습니다");
                        purchaseItem.IsPurchase = true;
                        GameManager.State.Gold.DecreaseGold(purchaseItem.Price);
                        DataManager.HaveItems.Add(purchaseItem.ItemData);
                        continue;
                    }
                    // 보유금액이 부족하다면
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다");
                        continue;
                    }
                }
            }
        }
    }
}
