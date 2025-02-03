using System.Text;

namespace TextRPG
{
    internal class ShopItem
    {
        public Item ItemData;
        public long Price;
        public bool IsPurchase;
        public long SalePrice => (long)(Price * 0.85f);

        public string GetShopItemInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(ItemData.GetItemInfo());
            
            if(IsPurchase)
            {
                sb.Append("| 구매완료");
                return sb.ToString();
            }

            sb.Append($"| {Price} G");
            return sb.ToString();
        }
    }
}
