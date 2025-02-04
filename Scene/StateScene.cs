namespace TextRPG
{
    internal class StateScene : SceneBase
    {
        static readonly Dictionary<int, SceneBase> _nextScenes = new Dictionary<int, SceneBase>
        {
            {0,new ReturnScene(0) },
        };

        public StateScene(int number) : base(number)
        {
            SceneName = "상태보기";
            NextScenes = _nextScenes;
        }

        public override void Display()
        {
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

            Player player = GameData.Player;

            Console.WriteLine("---------------------------------------------");
            string levelResult = string.Format("Lv. {0:D2}", player.Level);
            Console.WriteLine(levelResult);
            Console.WriteLine($"{player.Name} ({TextPrintManager.GetDescription(player.Job)})");
            Console.WriteLine(GetAttackPowerString(player.Stat.AttackPower, player.Stat.AddAttackPower));
            Console.WriteLine(GetDefensePowerString(player.Stat.DefensePower, player.Stat.AddDefensePower));
            Console.WriteLine($"체력 : {player.Hp.Current}");
            Console.WriteLine($"Gold : {GameData.Gold.Current} G");
            Console.WriteLine("---------------------------------------------");
        }

        /// <summary>
        /// 공격력 값 문자열 변환 함수
        /// </summary>
        /// <param name="aP">공격력</param>
        /// <param name="addAP">추가 공격력</param>
        /// <returns></returns>
        private string GetAttackPowerString(float aP,float addAP)
        {
            if (addAP != 0)
            {
                return $"공격력 : {aP} (+{addAP})";
            }
            return $"공격력 : {aP}";
        }

        /// <summary>
        /// 방어력 값 문자열 변환 함수
        /// </summary>
        /// <param name="dP">방어력</param>
        /// <param name="addDP">추가 방어력</param>
        /// <returns></returns>
        private string GetDefensePowerString(float dP,float addDP)
        {
            if (addDP != 0)
            {
                return $"방어력 : {dP} (+{addDP})";
            }
            return $"방어력 : {dP}";
        }
    }
}
