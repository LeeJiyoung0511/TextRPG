namespace TextRPG
{
    internal class GameData
    {
        static public Player Player { get; set; }
        static public Gold Gold { get; set; }
        static public bool IsCanEntryDungeon => Player.Hp.Current > 20;
    }
}
