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
            NextScenes = _nextScenes;
            OnInputInvalidActionNumber = EquipItem;
        }

        public override void OnStart(string sceneName)
        {
            sceneName = $"인벤토리 - {SceneName}";
            base.OnStart(sceneName);
        }

        public override void Display()
        {
            DisPlayHaveItems(true);
        }

        private void EquipItem(int number)
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
