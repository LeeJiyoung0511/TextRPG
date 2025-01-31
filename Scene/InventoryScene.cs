using TextRPG.Scene;

namespace TextRPG
{
    internal class InventoryScene : SceneBase
    {
        static readonly Dictionary<int, SceneBase> _inventoryScenes = new Dictionary<int, SceneBase>
        {
            {1,new EquipScene(1) },
            {2,new ReturnScene(2) },
        };

        private Item[] _haveItems = new Item[] { };

        public InventoryScene(int number) : base(number)
        {
            SceneName = "인벤토리";
        }

        public override void OnStart()
        {
            base.OnStart();
            DisplayItem();
        }

        private void DisplayItem()
        {
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템목록]");

            for (int i = 0; i < _haveItems.Length; i++)
            {
                Console.WriteLine($"-{i}.{_haveItems[i].GetItemInfo}");
            }

            GameManager.DisplayScene(_inventoryScenes);
            GameManager.SelectScene(_inventoryScenes);
        }
    }
}
