using Godot;
using System;

public partial class Idle : BaseState
{
    [Export] private AnimatedSprite2D animatedSprite2D;
    public override void onStateEnter()
    {
        base.onStateEnter();
    }

    public override void onStateUpdata(float delta)
    {
        base.onStateUpdata(delta);
        animatedSprite2D.Position = new Vector2(-7, 1);
        animatedSprite2D.Play("Relax");


    }

    public override void onStateExit()
    {
        base.onStateExit();
    }
}
