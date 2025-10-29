using Godot;
using samhain.components.Models;
using System;

public partial class Global : Node
{
    public static Global Instance;
    public int XPAmount { get; set; }//Adicionar n+1 quando um enemy morrer
    public int MaxXPAmount { get; private set; } = 100;
    public Action<GlobalParameters> OnLevelUp { get; set; }

    public override void _Ready()
    {
        Instance = this;
        base._Ready();
    }
    public PlayerStatistics PlayerStatistics { get; private set; } = new PlayerStatistics();  //Usado pelo DifficultyAI apenas

    //Passar para o método o parâmetro global quando clicar na carta. Assim cada interessado irá coletar apenas o parâmetro modificado
    public void LevelUp(GlobalParameters globalParam)
    {
        if(XPAmount >= MaxXPAmount)
        {
            OnLevelUp?.Invoke(globalParam);;
        }
    }
}
