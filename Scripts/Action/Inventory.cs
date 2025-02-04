using System.Text;

namespace TextRPG
{
    internal class Inventory : ActionBase
    {
        static readonly Dictionary<int, ActionBase> _nextActions = new Dictionary<int, ActionBase>
        {
            {1,new EquipItem(1) },
            {2,new Return(2) },
        };

        public Inventory(int number) : base(number)
        {
            ActionName = "인벤토리";
            NextActions = _nextActions;
        }

        protected override void Display()
        {
            DisPlayHaveItems();
        }

        public void DisPlayHaveItems(bool isEquipScene = false)
        {
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템목록]");

            for (int i = 0; i < DataManager.Instance.HaveItems.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("- ");
                if (isEquipScene)
                {
                    sb.Append($"{i + 1}.");
                }
                Console.WriteLine($"{sb}{DataManager.Instance.HaveItems[i].GetItemInfo()}");
            }

        }
    }
}
