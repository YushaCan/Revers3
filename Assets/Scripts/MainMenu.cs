using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelLoader lvlLoader;
    public AudioClip buttonAudio;
    private AudioSource mainMenuAudio;
    private void Start()
    {
        mainMenuAudio = GetComponent<AudioSource>();
    }
    public void Play()
    {
        mainMenuAudio.PlayOneShot(buttonAudio);
        lvlLoader.LoadNextLevel();
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit DONE!");
    }
}
