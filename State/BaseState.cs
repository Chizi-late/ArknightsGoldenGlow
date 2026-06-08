using Godot;
using System;

public partial class BaseState : Node
{
    protected StateMachine stateMachine;
    protected Node stateOwner;

    
    public virtual void Init(StateMachine stateMachine, Node stateOwner)
    {
        this.stateMachine = stateMachine;
        this.stateOwner = stateOwner;

    }

    /// <summary>
    /// 进入状态执行一次
    /// </summary>
    public virtual void onStateEnter()
    {

    }
    /// <summary>
    /// 每帧执行一次
    /// </summary>
    public virtual void onStateUpdata(float delta)
    {

    }
    /// <summary>
    /// 退出状态执行一次
    /// </summary>
    public virtual void onStateExit()
    {

    } 
}