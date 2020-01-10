using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool disableScroll = false;
    public float scrollSpeed;

    void Update()
    {
        if(!disableScroll)
            transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
    }
}
