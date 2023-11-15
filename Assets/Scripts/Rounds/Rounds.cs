using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rounds : MonoBehaviour
{
    private PlayerKill kill;

    private bool player1HasShot;
    private bool player2HasShot;
    private bool player1Died;
    private bool player2Died;

    

    void Start()
    {
        kill = FindAnyObjectByType<PlayerKill>();
    }

    void Update()
    {
        //if (Playe)
    }
}
