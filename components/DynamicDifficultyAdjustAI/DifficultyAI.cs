using Godot;
using System;

public partial class DifficultyAI : Node
{
    private readonly GameMetricsEvaluator evaluator;
    public float DifficultyLevel { get; set; } = 0.5f; //0.5f normal; 1.0f médio; 2.0f difícil. 

    public Action<float> OnDifficultyChange; //Evento
    public void UpdateStats(PlayerStatistics stats)
    {
        float performance = evaluator.AvaliarPerformance(stats);

        var targetDifficulty = DifficultyLevel + 0.5f * (performance - 0.5f);
        targetDifficulty = Math.Clamp(targetDifficulty, 0.5f, 2.0f);
        if(targetDifficulty - DifficultyLevel > 0.04f)
        {
            //Aplicar aumento de dificuldade
            DifficultyLevel = targetDifficulty;
            OnDifficultyChange?.Invoke(targetDifficulty);
        }

    }
}
