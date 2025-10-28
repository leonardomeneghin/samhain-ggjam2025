using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace samhain.components.DynamicDifficultyAdjustAI
{
    public class EnemyParametersModel
    {
        public float HealthMultiplier { get; set; }
        public float SpeedMultiplier { get; set; }
        public float DamageMultiplier { get; set; }

        public float MaxEnemyMultiplier { get; set; }
        public void ApplicarDificuldade(float difficulty)
        {
            HealthMultiplier = 1f + (difficulty * 0.5f);
            SpeedMultiplier = 1f + (difficulty * 0.35f);
            DamageMultiplier = 1f + (difficulty * 0.5f);
            MaxEnemyMultiplier = 1f + (difficulty * 0.6f);
        }
    }
}
