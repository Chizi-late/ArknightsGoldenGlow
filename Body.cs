using Godot;
using System;

public partial class Body : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private Vector2 LastMousePosition;
	[Export] private StateMachine stateMachine;
	[Export] private Timer randomTimer;
	[Export] private Timer randomTimerSoundEffect;
	[Export] private Sound_effect sound_Effect;
	private float RandomTime = 4f;

	public override void _Ready()
	{
		randomTimer.Timeout += OnRandomTimerTimeout;
		randomTimerSoundEffect.Timeout += OnRandomTimerSoundEffectTimeout;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);

	}

	private void RandomTimerController()
	{
		RandomTime = GD.Randf() * 4f + 6f;//6到10秒之间
		randomTimer.Start(RandomTime);
		
	}

	private void OnRandomTimerTimeout()
	{
		if (stateMachine.currentState is Idle)
		{
			stateMachine.ChangeState<Walk>();
		}
		else if (stateMachine.currentState is Walk)
		{
			stateMachine.ChangeState<Idle>();
		}
		RandomTimerController();
	}

	private void OnRandomTimerSoundEffectTimeout()
	{
		sound_Effect.PlayRandom_Relax();
		RandomTime = GD.Randf() * 4f + 15f;
		randomTimerSoundEffect.Start(RandomTime);
	}

	private void MouseClickDrag(Node viewport, InputEvent @event, int shape_idx)
	{
		if (@event.IsActionPressed("click"))
		{
			stateMachine.ChangeState<Drag>();
		}
	}

	private void MouseClickInteract(Node viewport, InputEvent @event, int shape_idx)
	{
		if (@event.IsActionPressed("click"))
		{
			stateMachine.ChangeState<Interact>();
		}

	}

}
