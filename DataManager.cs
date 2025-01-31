namespace TextRPG
{
    internal class DataManager
    {
        static public Item[] ItemDatas = new Item[]
        {
            new Item()
            {
                Name = "수련자 갑옷",
                Description = "수련에 도움을 주는 갑옷입니다.",
                DefensePower =5
            },
            new Item()
            {
                Name = "무쇠 갑옷",
                Description = "무쇠로 만들어져 튼튼한 갑옷입니다.",
                DefensePower =9
            },
            new Item()
            {
                Name = "스파르타 갑옷",
                Description = "스파르타의 전사들이 사용했다는 전설의 갑옷.",
                DefensePower =15
            },
            new Item()
            {
                Name = "낡은 검",
                Description = "쉽게 볼 수 있는 낡은 검 입니다.",
                AttackPower =2
            },
            new Item()
            {
                Name = "청돌 도끼",
                Description = "어디선가 사용됐던거 같은 도끼입니다.",
                AttackPower =5
            },
            new Item()
            {
                Name = "스파르타의 창",
                Description = "스파르타의 전사들이 사용했다는 전설의 창입니다.",
                AttackPower =7
            },
            new Item()
            {
                Name = "원펀맨의 망토",
                Description = "모든걸 한방에 터트립니다",
                AttackPower =999,
                DefensePower=999
            },
        };

        static public ShopItem[] ShopItemDatas = new ShopItem[]
        {
            new ShopItem()
            {
                ItemData = ItemDatas[0],
                Price=1000,
            },
            new ShopItem()
            {
                ItemData = ItemDatas[1],
                Price=2000,
            },
            new ShopItem()
            {
                 ItemData = ItemDatas[2],
                Price=3500,
            },
            new ShopItem()
            {
                ItemData = ItemDatas[3],
                Price=600,
            },
            new ShopItem()
            {
                ItemData = ItemDatas[4],
                Price=1500,
            },
            new ShopItem()
            {
                ItemData = ItemDatas[5],
                Price=2500,
            },
            new ShopItem()
            {
                ItemData = ItemDatas[6],
                Price=9999,
            },
        };

        static public List<Item> HaveItems = new List<Item>();
    }
}
