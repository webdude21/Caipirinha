namespace KnnightsOfCSharpiaLib.Creatures
{
    public interface IScalable
    {
        void LevelUp();

        int CurrentXp { get; }

        int NeededXP { get; }
    }
}
