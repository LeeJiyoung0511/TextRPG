namespace TextRPG
{
    internal class SceneBase
    {
        public Dictionary<int, SceneBase> NextScenes = new Dictionary<int, SceneBase>();

        public int SceneNumber;
        public string SceneName;

        public SceneBase(int actionNumber)
        {
            SceneNumber = actionNumber;
            SceneName = "";
        }

        public void PrintInfo()
        {
            Console.WriteLine($"\n{SceneNumber}. {SceneName}");
        }

        public virtual void OnStart(string sceneName = "")
        {
            if (String.IsNullOrEmpty(sceneName))
            {
                sceneName = SceneName;
            }
            Console.WriteLine(sceneName);
            Display();
            InputNextAction();
        }

        public virtual void Display()
        {
            GameManager.DisplayScene(NextScenes);
        }

        public virtual void InputNextAction()
        {
            GameManager.SelectScene(NextScenes);
        }
    }
}
