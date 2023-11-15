using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Shoot Bar/Shoot Bar Event Channel")]
public class ShootBarEventChannel : ScriptableObject
{
    public event Action OnSliderStart;
    public event Action<int> OnSliderSuccess;
    public event Action<int> OnSliderFail;

    public void InvokeOnSliderStart()
    {
        OnSliderStart?.Invoke();
    }

    public void InvokeOnSliderSuccess(int playerNumber)
    {
        OnSliderSuccess?.Invoke(playerNumber);
    }    
    public void InvokeOnSliderFail(int playerNumber)
    {
        OnSliderFail?.Invoke(playerNumber);
    }
}
