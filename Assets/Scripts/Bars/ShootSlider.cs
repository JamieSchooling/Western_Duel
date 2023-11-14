using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShootSlider : MonoBehaviour
{
    [SerializeField] private Slider shootSlider;
    [SerializeField] private float sliderShuffleDelay = 0.1f;
    [SerializeField] private bool canMove;
    [Range(0f, 1f)]
    [SerializeField] private float validRange = 0.15f;
    [SerializeField] Image fillLeft;
    [SerializeField] Image fillRight;

    private bool isMovingRight = true;

    void Start()
    {
        //shootSlider.value = shootSlider.minValue;
        Debug.Log(shootSlider.value);
        StartCoroutine(SliderShuffle());
    }


    void Update()
    {
        fillLeft.fillAmount = validRange;
        fillRight.fillAmount = validRange;

        SliderSafetyNet();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canMove)
            {
                canMove = false;
                if (isMovingRight)
                {
                    Debug.Log(shootSlider.normalizedValue);
                    if (!(1 - shootSlider.normalizedValue <= validRange || shootSlider.normalizedValue <= validRange))
                    {
                        HandlePlayerDeath();
                    }
                }

            }
            else
            {
                StartCoroutine(SliderShuffle());
            }
        }
    }

    private void SliderSafetyNet()
    {
        if (shootSlider.value < shootSlider.minValue)
        {
            shootSlider.value = shootSlider.minValue;
        }
        if (shootSlider.value > shootSlider.maxValue)
        {
            shootSlider.value = shootSlider.maxValue;
        }
    }

    private IEnumerator SliderShuffle()
    {
        canMove = true;
        while (canMove)
        {
            if (isMovingRight)
            {
                shootSlider.value++;
            }
            else
            {
                shootSlider.value--;
            }

            if (shootSlider.value >= shootSlider.maxValue)
            {
                isMovingRight = false;
            }
            else if (shootSlider.value <= shootSlider.minValue)
            {
                isMovingRight = true;
            }
            yield return new WaitForSeconds(sliderShuffleDelay);
        }
    }
    private void HandlePlayerDeath()
    {
        // Add death animation and game over screen in here
        Debug.Log("You died!");
    }
}