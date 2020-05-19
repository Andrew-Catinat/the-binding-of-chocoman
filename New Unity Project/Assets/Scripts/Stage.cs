using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
   
    [SerializeField]
    private Player player;

    [SerializeField]
    private Room room;
    private bool[,] stage;
    private int sizeStage = 1;

    void Start(){
        //Instantiate(player, new Vector2(0, 0), Quaternion.identity);
        
        bool[,] matrice = { 
            { true, true}, 
            { true, true } 
        };
        
        stage = matrice;

        for(int i = 0; i <= this.sizeStage; i++){
            for(int j = 0; j <= this.sizeStage; j++){
                if(stage[i,j]){
                  //Instantiate(room, new Vector2(37 * i , 20 * j), Quaternion.identity);
                }
            }
        }

    }


}
