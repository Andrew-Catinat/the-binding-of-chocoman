using UnityEngine;
using UnityEngine.UI;

public class ManageInterface : MonoBehaviour
{

    public Text healText;

    void Update(){
        healText.text = "x " + GameManager.GetPlayer().GetHealth().ToString();
    }

}