using Godot;
using System;

public partial class PlayerGhost : CharacterBody2D
{
    private AnimatedSprite2D _anim;
    public override void _Ready()
    {
        _anim = GetNode("Animation") as AnimatedSprite2D;
        base._Ready();
    }
    public override void _Process(double delta)
    {
        Movimento(delta);
        base._Process(delta);
    }

    private void Movimento(double delta)
    {

        var dir_x = Input.GetAxis("ui_left", "ui_right");
        var dir_y = Input.GetAxis("ui_up", "ui_down"); 
        Position += new Vector2(dir_x, dir_y).Normalized() * (float) delta * 200;
        MoveAndSlide();
    }
}
