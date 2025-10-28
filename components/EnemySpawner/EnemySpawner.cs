using System;
using System.Collections.Generic;
using Godot;
using samhain.components.DynamicDifficultyAdjustAI;

public partial class EnemySpawner : Node2D
{
    [Export] public PackedScene EnemyScene; // Referência à cena do inimigo
    [Export] public float SpawnInterval = 2.0f; // Tempo entre spawns
    [Export] public int MaxEnemies = 10; // Limite de inimigos simultâneos
    [Export] public float DifficultyScale = 1.05f; // Escala de dificuldade por ciclo
    [Export] public DifficultyAI DDAIMechanic;  


    private EnemyParametersModel _enemyParameters;
    private Timer _spawnTimer;
    private List<Node2D> _activeEnemies;
    private int _wave = 1;
    private Rect2 ExpandedSpawnArea;
    private PlayerStatistics _playerStats;

    public override void _Ready()
    {
        ExpandedSpawnArea = GetViewport().GetVisibleRect().Grow(25f);

        _activeEnemies = new List<Node2D>();
        _spawnTimer = GetNode<Timer>("SpawnTimer");
        _spawnTimer.WaitTime = SpawnInterval;
        _spawnTimer.Timeout += OnSpawnTimeout;
        _spawnTimer.Start();
        
        _enemyParameters = new EnemyParametersModel();
        DDAIMechanic.OnDifficultyChange += OnDifficultyChanged;

        _playerStats = new PlayerStatistics();
        base._Ready();
    }

    private void OnSpawnTimeout()
    {
        _activeEnemies.RemoveAll(e => !IsInstanceValid(e));

        if(_activeEnemies.Count <  MaxEnemies)
        {
            SpawnEnemy();
        }
        _wave++;
        SpawnInterval = Mathf.Max(0.5f, SpawnInterval/DifficultyScale);
        _spawnTimer.WaitTime = SpawnInterval;
    }
    Vector2 GetRandomPointOnPerimeter(Rect2 rect)
    {
        float perimeter = rect.Size.X * 2 + rect.Size.Y * 2;
        float rand = (float)GD.RandRange(0, perimeter);

        if (rand < rect.Size.X)
        {
            // Topo
            return new Vector2(rect.Position.X + rand, rect.Position.Y);
        }
        rand -= rect.Size.X;

        if (rand < rect.Size.Y)
        {
            // Direita
            return new Vector2(rect.End.X, rect.Position.Y + rand);
        }
        rand -= rect.Size.Y;

        if (rand < rect.Size.X)
        {
            // Base
            return new Vector2(rect.End.X - rand, rect.End.Y);
        }
        rand -= rect.Size.X;

        // Esquerda
        return new Vector2(rect.Position.X, rect.End.Y - rand);
    }
    private void SpawnEnemy()
    {
        if (EnemyScene == null) return;
        var enemy = EnemyScene.Instantiate<Enemy>();
        AddChild(enemy);
        Vector2 randomOffSet = GetRandomPointOnPerimeter(ExpandedSpawnArea);
        enemy.Position = randomOffSet;
        enemy.AddParametersMultiplier(_enemyParameters);
        _activeEnemies.Add(enemy);
    }
    public void OnDifficultyChanged(float difficulty)
    { 
        MaxEnemies = Math.Clamp(MaxEnemies + Convert.ToInt32(_enemyParameters.MaxEnemyMultiplier), MaxEnemies, int.MaxValue);
        _enemyParameters.ApplicarDificuldade(difficulty);
    }
    public void WhenAllEnemyDies()
    {

    }
}
