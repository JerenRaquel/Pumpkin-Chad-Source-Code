using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    public GameObject platform;

    [Header("Ghost Settings")]
    public GhostType ghostType;
    public float amplitudeScalar = 1;
    public float speed;

    private float startYPosition;

    private void Start() 
    {
        startYPosition = transform.position.y;

        switch (ghostType)
        {
            case GhostType.Sinnie:
                StartCoroutine(SineMove());
                break;
            case GhostType.Straitous:
                StartCoroutine(StraightMove());
                break;
            case GhostType.Blinkie:
                break;
            case GhostType.Bosster:
                break;
            default:
                break;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Shot"))
        {
            Instantiate(platform, transform.position, Quaternion.identity);
            //smoke effect
            GameController.instance.AddScore(1);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator SineMove()
    {
        float yAxis = 0;
        while(true)
        {
            yAxis = startYPosition + GetAmplitudeOfSine(Time.time);

            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), yAxis * amplitudeScalar, 0f);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator StraightMove()
    {
        while(true)
        {
            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0f);
            yield return new WaitForEndOfFrame();
        }
    }

    private float GetAmplitudeOfSine(float x)
    {
        return Mathf.Sin(x);
    }
}

public enum GhostType {Sinnie, Straitous, Blinkie, Bosster}