using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ShootSlider : MonoBehaviour
{
    [SerializeField] private float _sliderShuffleDelay = 0.1f;
    [Range(0f, 1f)]
    [SerializeField] private float _validRange = 0.15f;
    [SerializeField] private Image _fillLeft;
    [SerializeField] private Image _fillRight;
    [SerializeField] private bool _isMiddleSlider;

    private Slider _shootSlider;
    
    private bool _canMove;
    private bool _isMovingRight = true;

    public event Action OnSliderSuccess;

    private void Awake()
    {
        _shootSlider = GetComponent<Slider>();
    }

    void Start()
    {
        //shootSlider.value = shootSlider.minValue;
        Debug.Log(_shootSlider.value);
        StartCoroutine(SliderShuffle());
    }


    void Update()
    {
        _fillLeft.fillAmount = _validRange;
        _fillRight.fillAmount = _validRange;

        SliderSafetyNet();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_canMove)
            {
                _canMove = false;
                bool isInRangeEdge = !_isMiddleSlider && (_shootSlider.normalizedValue <= _validRange || _shootSlider.normalizedValue >= 1 - _validRange);
                bool isInRangeMiddle = _isMiddleSlider && _shootSlider.normalizedValue > _validRange && _shootSlider.normalizedValue < 1 - _validRange;
                if (isInRangeEdge || isInRangeMiddle)
                {
                    Debug.Log("Success.");
                    OnSliderSuccess?.Invoke();
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
        if (_shootSlider.value < _shootSlider.minValue)
        {
            _shootSlider.value = _shootSlider.minValue;
        }
        if (_shootSlider.value > _shootSlider.maxValue)
        {
            _shootSlider.value = _shootSlider.maxValue;
        }
    }

    private IEnumerator SliderShuffle()
    {
        _canMove = true;
        while (_canMove)
        {
            if (_isMovingRight)
            {
                _shootSlider.value++;
            }
            else
            {
                _shootSlider.value--;
            }

            if (_shootSlider.value >= _shootSlider.maxValue)
            {
                _isMovingRight = false;
            }
            else if (_shootSlider.value <= _shootSlider.minValue)
            {
                _isMovingRight = true;
            }
            yield return new WaitForSeconds(_sliderShuffleDelay);
        }
    }
}