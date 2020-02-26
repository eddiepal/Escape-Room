using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private int secondsLeft;
    [SerializeField] private bool currentlyCountingDown = false;
    [SerializeField] private TextMeshProUGUI timerText;

    private void Start()
    {
        timerText.text = "00: " + secondsLeft;
    }

    private void Update()
    {
        if (currentlyCountingDown == false && secondsLeft > 0)
        {
            StartCoroutine(Timer());
        }
        else
        {
            
        }
    }

    private IEnumerator Timer()
    {
        currentlyCountingDown = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            timerText.text = "00:0" + secondsLeft;
        }
        else
        {
            timerText.text = "00:" + secondsLeft;
        }
        currentlyCountingDown = false;
    }
}
