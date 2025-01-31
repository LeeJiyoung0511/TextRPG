using TextRPG.Scene;

namespace TextRPG
{
    internal class InventoryScene : SceneBase
    {

        static readonly Dictionary<int, SceneBase> _nextScenes = new Dictionary<int, SceneBase>
        {
            {1,new EquipScene(1) },
            {2,new ReturnScene(2) },
        };

        public InventoryScene(int number) : base(number)
        {
            SceneName = "인벤토리";
            NextScenes = _nextScenes;
        }

        public override void Display()
        {
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템목록]\n");

            for (int i = 0; i < DataManager.HaveItems.Count; i++)
            {
                Console.WriteLine($"- {DataManager.HaveItems[i].GetItemInfo()}");
            }

            base.Display();
        }
    }
}
