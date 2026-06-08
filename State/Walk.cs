using Godot;
using System;

public partial class Walk : BaseState
{
    [Export] private static int speed = 1;
    [Export] private static int speed_ = 3;//几帧增加一次速度
    [Export] private AnimatedSprite2D animatedSprite2D;
    [Export] private Marker2D marker2D;
    private int speed_Temp;
    private int direction_last;
    private float scale_x;
    private bool flip_;
    private int direction = 1;

    public override void onStateEnter()
    {
        base.onStateEnter();
        speed_Temp = speed_;
        //记录翻转动画第一帧时的状态
        scale_x = marker2D.Scale.X;
        
        direction = GD.Randi() % 2 == 0 ? 1 : -1;
    }

    public override void onStateUpdata(float delta)
    {
        base.onStateUpdata(delta);
        Move(delta);
        

        if (direction * scale_x < 0)
        {
            FlipAniamtion();
        }
        animatedSprite2D.Position = new Vector2(-7, 1);
        animatedSprite2D.Play("Walk");


    }

    public override void onStateExit()
    {
        base.onStateExit();
        direction_last = direction;
        
    }

    private void Move(float delta)
    {

        if (speed_Temp <= 0)
        {
            GetWindow().Position += Vector2I.Right * speed * direction;
            speed_Temp = speed_;
        }
        speed_Temp--;
        //Check if the window is out of bounds
        if (GetWindow().Position.X < 0 || GetWindow().Position.X + GetWindow().Size.X > DisplayServer.ScreenGetSize().X)
        {
            direction *= -1;
        }

    }

    private void FlipAniamtion()
    {
        // if (animatedSprite2D.Scale.X == scale_x && animatedSprite2D.FlipH == flip_)
        // {
        //     animatedSprite2D.Scale = scale_x * new Vector2(0.5f,1);
        // }
        // else if (animatedSprite2D.Scale.X != scale_x && animatedSprite2D.FlipH == flip_)
        // {
        //     animatedSprite2D.FlipH = !animatedSprite2D.FlipH;
        // }
        // else if (animatedSprite2D.Scale.X != scale_x && animatedSprite2D.FlipH != flip_)
        // {
        //     animatedSprite2D.Scale = scale_x * new Vector2(2f,1);
        // }
        // else if (animatedSprite2D.Scale.X == scale_x && animatedSprite2D.FlipH != flip_)
        // {
        //     return;
        // }
        // else
        // {
        //     return;
        // }

        if (Math.Abs(marker2D.Scale.X) <= Math.Abs(scale_x))
        {
            if (scale_x > 0)
            {
                marker2D.Scale -= new Vector2(scale_x / 10, 0);
            }
            else if (scale_x < 0)
            {
                
                marker2D.Scale -= new Vector2(scale_x / 10, 0);
                
            }

        }
        else
        {
            //完成翻转同步比例与数据
            marker2D.Scale = new Vector2(-scale_x/ Math.Abs(scale_x) * marker2D.Scale.Y, marker2D.Scale.Y);
            scale_x = marker2D.Scale.X;
        }
    }



}
