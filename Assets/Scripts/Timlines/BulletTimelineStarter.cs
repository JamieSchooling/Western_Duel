using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class BulletTimelineStarter : MonoBehaviour
{
    [SerializeField] private ShootBarEventChannel _eventChannel;
    [SerializeField] private PlayableDirector _player1BulletTimeline;
    [SerializeField] private PlayableDirector _player2BulletTimeline;
    [SerializeField] private PlayableDirector _idleTimeline;

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
        _idleTimeline.Stop();
        if (playerNumber == 1)
        {
            Debug.Log("run");
            _player1BulletTimeline.Play();
        }
        else
        {
            _player2BulletTimeline.Play();
        }
    }

}
