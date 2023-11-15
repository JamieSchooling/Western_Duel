using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BulletTimelineStarter : MonoBehaviour
{
    [SerializeField] private ShootBarEventChannel _eventChannel;
    [SerializeField] private Playable _player1BulletTimeline;
    [SerializeField] private Playable _player2BulletTimeline;

    private void OnEnable()
    {
        _eventChannel.OnSliderSuccess += StartBulletCam;
    }

    private void OnDisable()
    {
        _eventChannel.OnSliderSuccess -= StartBulletCam;
        
    }

    private void StartBulletCam(int playerNumber)
    {
        if (playerNumber == 1)
        {
            _player1BulletTimeline.Play();
        }
        else
        {
            _player2BulletTimeline.Play();
        }
    }

}
