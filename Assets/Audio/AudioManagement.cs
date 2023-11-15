using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    [SerializeField] private AudioSource sfxCountDown;
    [SerializeField] private AudioSource sfxLoadingShot;
    [SerializeField] private AudioSource sfxRevCylinder;
    [SerializeField] private AudioSource sfxFireShot;
    [SerializeField] private AudioSource sfxPlayerHit;
    [SerializeField] private AudioSource sfxPlayerDeath;
    [SerializeField] private AudioSource sfxPlayerWin;
    public ShootSlider Slider;

    bool bOnce = false;

    private void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Space) || (Input.GetKeyUp(KeyCode.KeypadEnter))) && (bOnce == false))
        {
            StartCoroutine(Sound());
            bOnce = true;
            
        }


    }

    public IEnumerator Sound()
    {
        yield return new WaitForSeconds(1f);
        sfxFireShot.Play();
    }

}