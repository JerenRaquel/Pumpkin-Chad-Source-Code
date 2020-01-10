using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaterOfWorlds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(!other.CompareTag("ScreenBoundary"))
        {
            if(other.CompareTag("Player"))
                GameController.instance.DeathScreen();
            else    
                Destroy(other.gameObject);
        }
    }
}
