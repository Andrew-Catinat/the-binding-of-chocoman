using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
   
    [SerializeField]
    public Player player;

    [SerializeField]
    public Room room;
    public int numberLine = 4;
    public int numberCol = 3;
    private bool[,] labyrinth;
    private Room[,] rooms;
    

    void Start(){
        //Instantiate(player, new Vector2(0, 0), Quaternion.identity);
        
        bool[,] matrix = { 
            { true, true, true}, 
            { false, true, false},
            { true, true, false},
            { false, true, true}
        };

        this.labyrinth = matrix;
        this.rooms = new Room[numberLine, numberCol];
        for(int i = 0; i < numberLine; i++){
            for(int j = 0; j < numberCol; j++){

                if(this.labyrinth[i,j])
                    InitRoom(i,j);

            }
        }

    }

    private void InitRoom(int x, int y){
        this.rooms[x,y] = Instantiate(room, new Vector3(39 * y, 21 * x), Quaternion.identity);
        bool[] roomAround = RoomAround(x,y);
        this.rooms[x,y].SetupDoor(roomAround);
    }

    private bool[] RoomAround(int x, int y){
        
        if(x < 0 || y < 0 || x > numberLine || y > numberCol){
            Debug.LogWarning("Les paramètres d'entrée dépassent la limite du tableau.");
            return null;
        }

        bool[] roomAround = new bool[4];
        int xPlus = x + 1;
        int xMinus = x - 1;
        int yPlus = y + 1;
        int yMinus = y - 1;

        //Vérifie qu'après calcul on ne sort pas des limites du tableau               
        if(xPlus < numberLine)
            roomAround[0] = labyrinth[xPlus, y];

        if(yPlus < numberCol)
            roomAround[1] = labyrinth[x, yPlus];

        if(xMinus >= 0)
            roomAround[2] = labyrinth[xMinus, y];        

        if(yMinus >= 0)
            roomAround[3] = labyrinth[x, yMinus];
    
        return roomAround;       
    }
}
