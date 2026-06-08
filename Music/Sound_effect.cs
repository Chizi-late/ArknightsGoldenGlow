using Godot;
using System;
using System.Collections.Generic;
using System.IO;

public partial class Sound_effect : Node
{

    [Export] private Node touch;
    [Export] private Node Relax;
    private int Last_Index_Touch = 0;
    private int Last_Index_Relax = 0;
    //private bool MFXPlaying

    Dictionary<Node, bool> WorkingStateOfNode = new Dictionary<Node, bool>();
    public void playMFX_Random()
    {

        if (((AudioStreamPlayer)touch.GetChild(Last_Index_Touch)).Playing == false
         && ((AudioStreamPlayer)Relax.GetChild(Last_Index_Relax)).Playing == false)
        {

            int index = (int)(GD.Randi() % touch.GetChildCount());
            AudioStreamPlayer MFX = (AudioStreamPlayer)touch.GetChild(index);
            MFX.Play();
            Last_Index_Touch = index;
        }
    }

    public void PlayRandom_Relax()
    {
        if (((AudioStreamPlayer)Relax.GetChild(Last_Index_Relax)).Playing == false
         && ((AudioStreamPlayer)touch.GetChild(Last_Index_Touch)).Playing == false)
        {

            int index = (int)(GD.Randi() % Relax.GetChildCount());
            AudioStreamPlayer MFX = (AudioStreamPlayer)Relax.GetChild(index);
            MFX.Play();
            Last_Index_Relax = index;
        }

    }

    private void UpdataDictionary()
    {
        if (((AudioStreamPlayer)touch.GetChild(Last_Index_Relax)).Playing == false)
        { 

        }
    }
    

}
