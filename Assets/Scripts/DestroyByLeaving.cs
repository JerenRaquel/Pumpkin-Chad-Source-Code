using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByLeaving : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
            GameController.instance.DeathScreen();
        else if(!other.CompareTag("Ghost"))
            Destroy(other.gameObject);
    }
}
