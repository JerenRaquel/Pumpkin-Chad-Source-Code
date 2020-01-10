using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ground") || other.CompareTag("Ghost"))
            playerController.isGrounded = true;
    }
}
