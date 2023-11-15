using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    [SerializeField] private ShootBarEventChannel _shootBarEventChannel;
    [SerializeField] private TextMeshProUGUI _player1Score;
    [SerializeField] private TextMeshProUGUI _player2Score;

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
        failCount = 0;
        if (playerNumber == 1)
        {
            scoreP1++;
            _player1Score.text = scoreP1.ToString();
        }
        else if (playerNumber == 2)
        {
            scoreP2++;
            _player2Score.text = scoreP2.ToString();
        };
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
