using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBar : MonoBehaviour
{
    private bool isMoving;
    private bool shootSuccess;
    private bool barShown;
    [SerializeField] private Image redBar;
    [SerializeField] private Image greenBar;
    [SerializeField] private RectTransform indicator;
    void Start()
    {
        Debug.Log(redBar.minHeight);
        Debug.Log(redBar.minWidth);
    }

    void Update()
    {
        
    }
}
