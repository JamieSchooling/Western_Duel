using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _gameSceneName;

    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadSceneAsync(_gameSceneName);
    }


    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit.");

    }
}
