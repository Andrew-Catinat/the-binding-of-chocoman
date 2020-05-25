using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    // private static Player _player; 
    public Player player;
    //     get{
    //         return _player;
    //     }
    //     set{
    //         this._player = value;
    //     }
    // }

    //Idée GameManager
    // public Scene currentScene;
    //or public ManagerScene scene;
    // public int currentLevel;
    // public int difficulty;
    // public int maxEtage;

    public static GameManager Instance
    {
        get{
            if(_instance == null){
                _instance = new GameManager();
                //GameManager.Instance.player = GameObject.FindWithTag("Player").GetComponent<Player>();
            }
            return _instance;        
        }
    }

    public static Player GetPlayer(){
        return GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Start(){
    }

    void Awake()
    {
        
    }
}
