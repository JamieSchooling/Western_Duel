using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBars : MonoBehaviour
{
    [SerializeField] private ShootBarEventChannel _eventChannel;

    private void OnEnable()
    {
        _eventChannel.InvokeOnSliderStart();
    }
}
