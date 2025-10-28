using Godot;
using System;

public partial class GameMetricsEvaluator : Node
{
    public float AvaliarPerformance(PlayerStatistics stats)
    {
        float performance = (stats.NumeroFantasmaMorto * 0.6f)
                          - (stats.NumeroMortes * 0.2f)
                          - (stats.TempoMedioWave / 300 * 0.2f);
        return Math.Clamp(performance, 0.0f, 1.0f);
    }
}
