using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageRoom : MonoBehaviour
{
    
    public Gate gate_left;
    public Gate gate_right;
    public Gate gate_top;
    public Gate gate_down;

    
    void Update(){
        if (Input.GetKeyDown("space"))
        {
            gate_top.hide();
        }
        if (Input.GetKeyDown("c"))
        {   
            gate_top.show();
        }
        if (Input.GetKeyDown("b"))
        {
            gate_left.hide();
        }
        if (Input.GetKeyDown("n"))
        {   
            gate_left.show();
        }
    }
}
