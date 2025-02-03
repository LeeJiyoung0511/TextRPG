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
            for (int i = 0; i < DataManager.HaveItems.Count; i++)
            {
                Item item = DataManager.HaveItems[i];
                item.OrderNumber = i + 1;
                Console.WriteLine($"- {i + 1}.{item.GetItemInfo()} | {DataManager.GetShopItem(item).SalePrice} G \n");
            }

        }

        public override void InputNextAction()
        {
            string inputNumber = "";
            int number = 0;

            Item saleItem = new Item();

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

                saleItem = DataManager.HaveItems.FirstOrDefault(x => x.OrderNumber == number);

                if (saleItem == null)
                {
                    Console.WriteLine("잘못된 입력입니다");
                }
                else
                {
                    if (saleItem.IsEquipped)
                    {
                        saleItem.IsEquipped = false;
                    }
                    else
                    {
                        DataManager.HaveItems.Remove(saleItem);
                    }

                    Console.WriteLine($"{saleItem.Name}이 판매되었습니다.");
                    GameManager.State.Gold.IncreaseGold(DataManager.GetShopItem(saleItem).SalePrice);
                }
                continue;
            }

        }
    }
}
