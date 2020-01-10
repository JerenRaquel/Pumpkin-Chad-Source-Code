using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public GameObject controls;
    public int newGameSceneIndex;

    private void Start() {
        controls.SetActive(false);
    }

    public void NewGame()
    {
        SceneSystem.instance.ChangeScene(newGameSceneIndex);
    }

    public void OpenControls()
    {
        controls.SetActive(true);
    }

    public void CloseControls()
    {
        controls.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
