using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransfer : MonoBehaviour
{

    public Vector2 cameraChange;
    public Vector3 playerChange;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            //Récupére la position de la caméra, crée un nouveau Vector3 en additionnant ses x et y avec le Vector2 en entrée (le z ne change pas) puis bouge la caméra avec une certaine vitesse grâce au Vector3.Lerp(start,end,speed)
            Vector3 cameraPosition = Camera.main.transform.position;
            Vector3 newCameraPosition = new Vector3(cameraPosition.x + this.cameraChange.x, cameraPosition.y + this.cameraChange.y, cameraPosition.z);
            Camera.main.transform.position = Vector3.Lerp(cameraPosition, newCameraPosition, 1F);
            other.transform.position += playerChange;
        }
    }
}
