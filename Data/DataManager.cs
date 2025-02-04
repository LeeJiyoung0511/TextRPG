using Newtonsoft.Json;

namespace TextRPG
{
    internal class DataManager
    {
        static public DataManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DataManager();
                }
                return _Instance;
            }
        }

        static public DataManager? _Instance = null;

        private string _Path = "C:\\Users\\81804\\Desktop\\Study\\TextRPG\\Save\\SaveData";

        public Player Player { get; set; }
        public Gold Gold { get; set; }

        public Dictionary<long, Item> ItemDatas = new()
        {
            { 1,new Item()
            {
                Id=1,
                Name = "수련자의 갑옷",
                Description = "수련에 도움을 주는 갑옷.",
                DefensePower =5,
                ItemType=ItemType.Armor
            }},
            { 2,new Item()
            {
                Id=2,
                Name = "무쇠 갑옷",
                Description = "무쇠로 만들어져 튼튼한 갑옷입니다.",
                DefensePower =9,
                ItemType=ItemType.Armor
            }},
            { 3,new Item()
            {
                Id=3,
                Name = "스파르타 갑옷",
                Description = "스파르타의 전사들이 사용했다는 전설의 갑옷.",
                DefensePower =15,
                ItemType=ItemType.Armor
            }},
            { 4,new Item()
            {
                Id=4,
                Name = "낡은 검",
                Description = "쉽게 볼 수 있는 낡은 검 입니다.",
                AttackPower =2,
                ItemType=ItemType.Weapon
            }},
            { 5,new Item()
            {
                Id=5,
                Name = "청돌 도끼",
                Description = "어디선가 사용됐던거 같은 도끼입니다.",
                AttackPower =5,
                ItemType=ItemType.Weapon
            }},
            { 6,new Item()
            {
                Id=6,
                Name = "스파르타의 창",
                Description = "스파르타의 전사들이 사용했다는 전설의 창입니다.",
                AttackPower =7,
                ItemType=ItemType.Weapon
            }},
            { 7,new Item()
            {
                Id=7,
                Name = "원펀맨의 주먹",
                Description = "모든걸 한방에 터트립니다",
                AttackPower =9999,
                DefensePower =9999,
                ItemType=ItemType.Weapon
            }},
        };

        public Dictionary<long, ShopItem> ShopItemDatas = new()
        {
            { 1, new ShopItem { ShopId = 1, Price = 1000 } },
            { 2, new ShopItem { ShopId = 2, Price = 2000 } },
            { 3, new ShopItem { ShopId = 3, Price = 3500 } },
            { 4, new ShopItem { ShopId = 4, Price = 600 } },
            { 5, new ShopItem { ShopId = 5, Price = 1500 } },
            { 6, new ShopItem { ShopId = 6, Price = 2500 } },
            { 7, new ShopItem { ShopId = 7, Price = 9999 } },
        };

        public List<Item> HaveItems = new List<Item>();

        public Dictionary<ItemType, Item> EquippedItems = new Dictionary<ItemType, Item>();

        [JsonIgnore]
        public Dictionary<long, Dungeon> DungeonDatas = new()
        {
            { 1, new Dungeon(5,  DungeonLevel.Easy, 1000) },
            { 2, new Dungeon(11, DungeonLevel.Normal,1700) },
            { 3, new Dungeon(17, DungeonLevel.Hard, 2500) },
        };

        public void Initialize()
        {
            Player = new Player("플레이어", Job.Warrior, 10, 5);
            Gold = new Gold(1500);
        }

        public void Save()
        {
            string dataManager = JsonConvert.SerializeObject(Instance);
            File.WriteAllText(_Path, dataManager);
        }

        public void Load()
        {
            if (!File.Exists(_Path))
            {
                Instance.Initialize();
                Save();
                return;
            }
            else
            {
                string dataManager = File.ReadAllText(_Path);
                _Instance = JsonConvert.DeserializeObject<DataManager>(dataManager);
            }
        }

    }
}
