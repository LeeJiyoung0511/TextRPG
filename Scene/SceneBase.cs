namespace TextRPG
{
    internal class SceneBase
    {
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

        public virtual void OnStart()
        {
            Console.WriteLine(SceneName);
        }
    }
}
