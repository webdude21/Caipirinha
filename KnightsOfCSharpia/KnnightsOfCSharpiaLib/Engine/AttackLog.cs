namespace KnightsOfCSharpiaLib.Engine
{
    public struct AttackLog
    {

        public AttackLog(DamageType type, uint damage)
            :this()
        {
            this.Damage = damage;
            this.DamageType = type;
        }

        public DamageType DamageType { get; set; }

        public uint Damage { get; set; }

        public string AttackInformation { get; set; }
    }
}
