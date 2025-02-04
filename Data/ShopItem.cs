using System.Text;
using System.Text.Json.Serialization;

namespace TextRPG
{
    internal class ShopItem
    {
        public long ShopId { get; set; }
        public long Price { get; set; }
        public bool IsPurchase { get; set; }

        [JsonIgnore]
        public Item ItemData => DataManager.Instance.ItemDatas[ShopId];

        [JsonIgnore]
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
