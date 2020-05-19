using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    void Awake(){
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance d'Inventory !");
            return;
        }
        instance = this;
    }

    #endregion

    public int space = 2;
    public SortedList<string, Item> items = new SortedList<string, Item>();

    public bool Add(Item item){
        if(items.Count >= space){
            Debug.Log("Pas assez de place");
            return false;
        }

        if(item is Weapon){
            Weapon weapon = (Weapon) item;
            if(items.ContainsKey("Weapon"))
                SwitchWeapon(weapon);
            else 
                items.Add("Weapon", weapon);
        }
        return true;
    }

    public void SwitchWeapon(Weapon newWeapon){
        items["Weapon"].Drop();
        items["Weapon"] = newWeapon;
    }


}