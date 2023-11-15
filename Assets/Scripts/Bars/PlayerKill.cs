using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    [SerializeField] private ShootBarEventChannel _shootBarEventChannel;

    private int scoreP1 = 0;
    private int scoreP2 = 0;

    public int failCount = 0;

    [SerializeField] private float barStartTime = 0.5f;

    private void OnEnable()
    {
        _shootBarEventChannel.OnSliderSuccess += Kill;
        _shootBarEventChannel.OnSliderFail +=OnFail;
    }

    private void OnDisable()
    {
        _shootBarEventChannel.OnSliderSuccess -= Kill;
        _shootBarEventChannel.OnSliderFail -= OnFail;
    }

    private void Kill(int playerNumber)
    {

        if (playerNumber == 1)
        {
            scoreP1++;
            Debug.Log($"Player {playerNumber} Score: {scoreP1}");
        }
        else if (playerNumber == 2)
        {
            scoreP2++;
            Debug.Log($"Player {playerNumber} Score: {scoreP2}");
        };

        StartCoroutine(StartBars());
    }

    private IEnumerator StartBars()
    {
        failCount = 0;
        yield return new WaitForSeconds(barStartTime);
        _shootBarEventChannel.InvokeOnSliderStart();
    }

    private void OnFail(int playerNumber)
    {
        failCount++;

        if (failCount >= 2)
        {
            Debug.Log("Both Failed. Restarting.");
            StartCoroutine(StartBars());
        }
    }
}
