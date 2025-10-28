using Godot;
using samhain.components.DynamicDifficultyAdjustAI;
using System;

public partial class Enemy : CharacterBody2D
{
    public float Vida { get; set; }
    public float Velocidade { get; set; }
    public float Dano { get; set; }
    public override void _Ready()
    {
        base._Ready();
    }
    public override void _Process(double delta)
    {
        //Test enemy movement and spawn
        Position = Position.MoveToward(GetGlobalMousePosition(), 3.0f);
        MoveAndSlide();
        base._Process(delta);
    }
    public void AddParametersMultiplier(EnemyParametersModel parameters)
    {
        Vida = 100f * parameters.HealthMultiplier;
        Velocidade = 50f * parameters.HealthMultiplier;
        Dano = 10f * parameters.HealthMultiplier;
    }
}
