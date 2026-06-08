using Godot;
using System;

public partial class Interact : BaseState
{
    [Export] private AnimatedSprite2D animatedSprite2D;
    [Export] private Sound_effect sound_Manage;

    public override void _Ready()
    {
        base._Ready();
        //sound_Manage = GetNode<Sound_effect>("/root/SoundEffect");
    }



    public override void onStateEnter()
    {
        base.onStateEnter();
        animatedSprite2D.Position = new Vector2(5, -11);
        sound_Manage.playMFX_Random();
        animatedSprite2D.Play("Interact");
        

    }

    public override void onStateUpdata(float delta)
    {
        base.onStateUpdata(delta);
        
        if (!animatedSprite2D.IsPlaying())
        {
            GetParent<StateMachine>().ChangeState<Idle>();
        }


    }

    public override void onStateExit()
    {
        base.onStateExit();
    }
}
