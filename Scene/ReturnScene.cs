namespace TextRPG
{
    internal class ReturnScene : SceneBase
    {
        public ReturnScene(int number) : base(number)
        {
            SceneName = "나가기";
        }

        public override void OnStart(string sceneName)
        {
            Console.Clear();
            Game.Display();
        }
    }
}
