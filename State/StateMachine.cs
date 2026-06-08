using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class StateMachine : Node
{
    [Export] private BaseState startingState;

    public BaseState lastState;
    public BaseState currentState;

    //private BaseValue Value;
    private List<BaseState> stateList = new();

    public override void _Ready()
    {
        base._Ready();
        foreach (BaseState state in GetChildren().OfType<BaseState>())
        {

            state.Init(this, GetParent<Node>());
            stateList.Add(state);

        }

        LaunchStateMachine();
    }

    private void LaunchStateMachine()
    {
        currentState = startingState;
        currentState.onStateEnter();
    }


    public override void _Process(double delta)
    {
        base._Process(delta);
        currentState.onStateUpdata((float)delta);
    }

    public void ChangeState<T>() where T : BaseState
    {
        BaseState state_new = stateList.FirstOrDefault(x => x is T);
        if (state_new == null) return;
        currentState.onStateExit();
        lastState = currentState;
        currentState = state_new;
        currentState.onStateEnter();
    }

    public void ChangeLastState()
    {
        BaseState temp = new BaseState();
        temp = lastState;
        currentState.onStateExit();
        lastState = currentState;
        currentState = temp;
        currentState.onStateEnter();
        
    }

}
