using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Shop : Action
    {
        public Shop(int number): base(number)
        {
            ActionName = "상점";
        }

        public override void Select()
        {

        }
    }
}
