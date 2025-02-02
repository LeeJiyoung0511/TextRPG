using System.Text;
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
            DisPlayHaveItems();
            base.Display();
        }

        public void DisPlayHaveItems(bool isEquipScene = false)
        {
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템목록]\n");

            for (int i = 0; i < DataManager.HaveItems.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("- ");
                if (isEquipScene)
                {
                    sb.Append($"{i + 1}.");
                }
                Console.WriteLine($"{sb}{DataManager.HaveItems[i].GetItemInfo()}");
            }

        }
    }
}
