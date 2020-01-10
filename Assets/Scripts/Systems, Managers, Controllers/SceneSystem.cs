using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    #region Defining Instance
    public static SceneSystem instance = null;

    private void Awake() {
        if(instance == null)
            instance = this;
        else
            Destroy(instance);
    }
    #endregion

    public int startingScene;
    public string[] sceneNames;
    public bool disableNormalLoading = false;

    [HideInInspector]
    public static int highScore = 0;

    private void Start() {
        if(!disableNormalLoading)
            ChangeScene(startingScene);
    }

    public void ChangeScene(int sceneNumber)
    {  
        for(int i = 0; i < SceneManager.sceneCount; i++)
        {
            if(SceneManager.GetSceneAt(i) == SceneManager.GetActiveScene())
                continue;
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i));
        }
        Debug.Log(sceneNames[sceneNumber]);
        SceneManager.LoadSceneAsync(sceneNumber, LoadSceneMode.Additive);
    }
}
