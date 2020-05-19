using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
   
    [SerializeField]
    public Player player;

    [SerializeField]
    public Room room;
    private bool[,] stage;
    //private int sizeStage = 3;

    void Start(){
        //Instantiate(player, new Vector2(0, 0), Quaternion.identity);
        
        bool[,] matrice = { 
            { true, true, true}, 
            { true, true, true},
            { true, true, true}
        };
        
        stage = matrice;
Debug.Log(stage[0,0]);
        for(int i = 0; i < matrice.Length; i++){
            for(int j = 0; j < matrice.Length; j++){
                //Debug.Log("i : " + i + " / j : " + j + " / true/false : " + stage[i,j]);
                if(stage[i,j]){
                  Instantiate(room, new Vector2(39 * i , 21 * j), Quaternion.identity);
                }
            }
        }

    }


}
