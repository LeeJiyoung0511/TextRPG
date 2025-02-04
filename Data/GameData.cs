namespace TextRPG
{
    internal class GameData
    {
        static public Player Player => DataManager.Instance.Player;
        static public Gold Gold =>  DataManager.Instance.Gold;
        static public bool IsCanEntryDungeon => Player.Hp.Current > 20;
    }
}
