using UnityEngine;
using UnityEngine.UI;

public class ManageInterface : MonoBehaviour
{

    public Text healText;
    public Player player;

    void Update()
    {
        healText.text = "x " + player.GetHealth().ToString();
    }
}
