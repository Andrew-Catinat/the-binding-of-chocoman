using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{ 
    
    public Door door_up;
    public Door door_right;
    public Door door_down;
    public Door door_left;    

    public void SetupDoor(bool[] roomAround){
        if(!roomAround[0])
            door_up.hide();
        if(!roomAround[1])
            door_right.hide();
        if(!roomAround[2])
            door_down.hide();
        if(!roomAround[3])
            door_left.hide();
    }

}
