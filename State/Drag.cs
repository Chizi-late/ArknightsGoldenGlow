using Godot;
using System;

public partial class Drag : BaseState
{
    private Vector2 LastMousePosition;
    [Export] private Node2D body;
    public override void onStateEnter()
    {
        base.onStateEnter();
        if (body != null)
        { 
            LastMousePosition = body.GetGlobalMousePosition();
        }
        
    }

    public override void onStateUpdata(float delta)
    {
        base.onStateUpdata(delta);
        if (Input.IsActionPressed("click"))
        {

            GetWindow().Position += (Vector2I)(body.GetGlobalMousePosition() - LastMousePosition);
            LastMousePosition = body.GetGlobalMousePosition();
        }

        if (Input.IsActionJustReleased("click"))
        {
            GetParent<StateMachine>().ChangeState<Idle>();
        }
        

    }

    public override void onStateExit()
    {
        base.onStateExit();
    }

    
}
