using System;
using UnityEngine;
using UnityEngine.UI;

public class PuasedUIController : MonoBehaviour
{
    [Header("Volume Settings")]
    public AudioSource audioSource;
    public Text volumeText;

    public void ChangeVolume(Slider slider)
    {
        audioSource.volume = slider.value / 100;
        volumeText.text = "Volume: " + slider.value.ToString();        
    }

    public void MainMenu()
    {
        SceneSystem.instance.ChangeScene(3);
    }
}
