using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource MenuSelect;

    // Start is called before the first frame update
    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        MenuSelect.Play();
    }


    public void Quit()
    {
        Application.Quit();
        MenuSelect.Play();
        Debug.Log("Player has Quit the game");

    }
}
