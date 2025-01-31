using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    internal class PurchaseItemScene : SceneBase
    {
        public PurchaseItemScene(int number) : base(number)
        {
            SceneName = "아이템구매";
        }
    }
}
