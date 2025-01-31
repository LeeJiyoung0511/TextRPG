using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Inventory : Action
    {
        public Inventory(int number) : base(number)
        {
            ActionName = "인벤토리";
        }

        public override void Select()
        {
            
        }
    }
}
