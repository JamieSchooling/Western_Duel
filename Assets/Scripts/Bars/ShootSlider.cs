using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ShootSlider : MonoBehaviour
{
    [SerializeField] private ShootBarEventChannel _shootBarEventChannel;
    [SerializeField] private float _sliderShuffleDelay = 0.1f;
    [Range(0f, 1f)]
    [SerializeField] private float _validRange = 0.15f;
    [SerializeField] private Image _fillLeft;
    [SerializeField] private Image _fillRight;
    [SerializeField] private Image _fillBackground;
    [SerializeField] private bool _isMiddleSlider;
    [SerializeField] private Color _colourSuccessArea = Color.green;
    [SerializeField] private Color _colourFailArea = Color.red;
    [Range(1, 2)]
    [SerializeField] private int _playerNumber;

    private Slider _shootSlider;
    
    private bool _canMove;
    private bool _isMovingRight = true;


    private void Awake()
    {
        _shootSlider = GetComponent<Slider>();
    }

    void Start()
    {
        if (_isMiddleSlider)
        {
            _fillLeft.color = _colourFailArea;
            _fillRight.color = _colourFailArea;
            _fillBackground.color = _colourSuccessArea;
        }
        else
        {

            _fillLeft.color = _colourSuccessArea;
            _fillRight.color = _colourSuccessArea;
            _fillBackground.color = _colourFailArea;
        }

        StartCoroutine(SliderShuffle());
    }


    private void OnEnable()
    {
        _shootBarEventChannel.OnSliderStart += StartBar;
        _shootBarEventChannel.OnSliderSuccess += StopBar;
    }

    private void OnDisable()
    {
        _shootBarEventChannel.OnSliderSuccess -= StopBar;
    }

    private void StartBar()
    {
        StartCoroutine(SliderShuffle());
    }

    private void StopBar(int playerNumber)
    {
        _canMove = false;
    }

    void Update()
    {
        _fillLeft.fillAmount = _validRange;
        _fillRight.fillAmount = _validRange;

        SliderSafetyNet();

        if ((_playerNumber == 1 && Input.GetKeyDown(KeyCode.Space)) || (_playerNumber == 2 && Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            if (_canMove)
            {
                _canMove = false;
                bool isInRangeEdge = !_isMiddleSlider && (_shootSlider.normalizedValue <= _validRange || _shootSlider.normalizedValue >= 1 - _validRange);
                bool isInRangeMiddle = _isMiddleSlider && _shootSlider.normalizedValue > _validRange && _shootSlider.normalizedValue < 1 - _validRange;
                if (isInRangeEdge || isInRangeMiddle)
                {
                    Debug.Log("Success.");
                    _shootBarEventChannel.InvokeOnSliderSuccess(_playerNumber);
                }
                else
                {
                    _shootBarEventChannel.InvokeOnSliderFail(_playerNumber);
                }

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
        _shootSlider.value = _shootSlider.minValue;
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