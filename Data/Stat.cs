using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TextRPG
{
    internal class Stat
    {
        public float baseAttackPower;
        public float AddAttackPower;
        [JsonIgnore]
        public float AttackPower => baseAttackPower + AddAttackPower;

        public float baseDefensePower;
        public float AddDefensePower;
        [JsonIgnore]
        public float DefensePower => baseDefensePower + AddDefensePower;


        public Stat(float aP,float dP)
        {
            baseAttackPower = aP;
            baseDefensePower = dP;
            AddAttackPower = 0;
            AddDefensePower = 0;
        }
    }
}
