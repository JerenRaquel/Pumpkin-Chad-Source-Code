using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
	public bool disableScroll = false;
    public Transform cameraPosition;
    public float scrollSpeed;
	public float tileSizeZ;

	private Vector3 startPosition;


	void Update()
	{
		if(!disableScroll)
		{
			float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
			transform.position = new Vector3(cameraPosition.position.x, cameraPosition.position.y, 0) + Vector3.left * newPosition * 2;
		}
	}
}
