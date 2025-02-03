namespace TextRPG.Scene
{
    internal class EquipScene : InventoryScene
    {
        static readonly Dictionary<int, SceneBase> _nextScenes = new Dictionary<int, SceneBase>
        {
            {0,new ReturnScene(0) },
        };

        public EquipScene(int number) : base(number)
        {
            SceneName = "장착관리";
        }

        public override void OnStart(string sceneName)
        {
            sceneName = $"인벤토리 - {SceneName}";
            base.OnStart(sceneName);
        }

        public override void Display()
        {
            SetOrderNumber();
            DisPlayHaveItems(true);
        }

        private void SetOrderNumber()
        {
            for (int i = 0; i < DataManager.HaveItems.Count; i++)
            {
                DataManager.HaveItems[i].OrderNumber = i;
            }
        }

        public override void InputNextAction()
        {
            string inputNumber = "";
            int number = 0;

            Item haveItem = new Item();

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

                haveItem = DataManager.HaveItems.FirstOrDefault(x => x.OrderNumber + 1 == number);

                if (haveItem == null)
                {
                    Console.WriteLine("잘못된 입력입니다");
                }
                else
                {
                    if (DataManager.EquippedItems.TryGetValue(haveItem.ItemType, out Item equippedItem))
                    {
                        equippedItem.IsEquipped = false;
                        if (haveItem.OrderNumber != equippedItem.OrderNumber)
                        {
                            haveItem.IsEquipped = true;
                        }

                    }
                    else
                    {
                        haveItem.IsEquipped = true;
                    }
                }
                continue;
            }
        }

    }
}
