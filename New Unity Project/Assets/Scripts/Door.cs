using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public RoomTransfer transfer;
    public Sprite door_open;
    public Sprite door_close;

    public void show(){
        this.GetComponent<Renderer>().enabled = true;
    }

    public void hide(){
        this.GetComponent<Renderer>().enabled = false;
    }

  
}
