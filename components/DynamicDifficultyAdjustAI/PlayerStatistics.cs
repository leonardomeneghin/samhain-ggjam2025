using Godot;
using System;

public partial class PlayerStatistics : Node
{
    //Numero de mortes
    public int NumeroMortes { get; set; }
    //Numero de fantasmas mortos
    public int NumeroFantasmaMorto { get; set; }

    //Tempo médio por nível
    public int TempoMedioWave { get; set; }

}
