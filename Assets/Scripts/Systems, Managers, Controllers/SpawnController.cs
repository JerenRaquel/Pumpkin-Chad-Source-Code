using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    #region 
    public static SpawnController instance = null;
    private void Awake() {
        if(instance == null)
            instance = this;
        else
            Destroy(this);
    }
    #endregion

    public GameObject[] ghosts;

    [Header("Time Settings")]
    public float startDelay;
    public float delayPerSpawn;
    public float delayPerWave;

    [Header("Other Settings")]
    public bool isDisabled = false;
    public Vector2 minMax;
    public int waveSpawnAmount;

    [Header("Ghost Offsets")]
    [Header("Sinnie")]
    [Range(0, 1)]
    public float sinnieAmpMaxOffset = 0;
    [Range(0, 3)]
    public float sinnieSpeedMaxOffset = 0;
    [Header("Straitous")]
    [Range(0, 3)]
    public float straitousSpeedMaxOffset = 0;

    void Start()
    {
        if(!isDisabled)
            StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(startDelay);
        while(true)
        {
            for (int i = 0; i < waveSpawnAmount; i++)
            {
                float yPos = Random.Range(minMax.x, minMax.y);
                GameObject go = Instantiate(ghosts[Random.Range(0, ghosts.Length)], new Vector3(transform.position.x, yPos, 0f), Quaternion.identity, transform);
                GhostAI gAI = go.GetComponent<GhostAI>();

                if(gAI.ghostType == GhostType.Sinnie)
                {
                    gAI.amplitudeScalar += Random.Range(0, sinnieAmpMaxOffset);
                    gAI.speed += Random.Range(0, sinnieSpeedMaxOffset);
                }
                else if(gAI.ghostType == GhostType.Straitous)
                    gAI.speed += Random.Range(0, straitousSpeedMaxOffset);

                yield return new WaitForSeconds(delayPerSpawn);
            }
            yield return new WaitForSeconds(delayPerWave);
        }
    }
}
