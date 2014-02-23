namespace KnnightsOfCSharpiaLib.Common
{
    using System;

    public struct AttackLog
    {
        public static AttackLog AttackFailed
        {
            get
            {
                return new AttackLog(false, string.Empty);
            }
        }

        private bool attackPassed;
        private string attackDetails;

        public AttackLog(bool attackResult, string details)
            :this()
        {
            this.AttackPassed = attackResult;
            this.AttackDetails = details;
        }

        public bool AttackPassed
        {
            get
            {
                return this.attackPassed;
            }
            private set
            {
                this.attackPassed = value;
            }
        }

        public string AttackDetails
        {
            get
            {
                return this.attackDetails;
            }
            set
            {
                this.attackDetails = value;
            }
        }

        public override string ToString()
        {
            return this.AttackDetails;
        }
    }
}
