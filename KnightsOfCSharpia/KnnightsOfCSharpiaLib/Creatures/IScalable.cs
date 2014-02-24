namespace KnightsOfCSharpiaLib.Creatures
{
    public interface IScalable
    {
        uint CurrentXp { get; }

        uint NeededXP { get; }

        void AddXP(uint xp);

        void LevelUp();
    }
}