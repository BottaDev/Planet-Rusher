using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Player UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timeLeftText;
    public TextMeshProUGUI countDownText;
    public GameObject playerArea;
    [Header("Screens")]
    public GameObject WinScreen;
    public GameObject LoseScreen;

    private float countDownTimer = 3f;
    private bool countDownStarted = false;

    private void Update()
    {
        if (countDownStarted && countDownTimer <= 1)
        {
            StartCoroutine(EndCountDown());
        }
        else if (countDownStarted && countDownTimer > 1)
        {
            countDownTimer -= Time.deltaTime;
            countDownText.text = countDownTimer.ToString("F0");     // Decimals are not displayed
        }
    }

    // Starts the initial count down
    public void StartCountDown()
    {
        countDownText.enabled = true;
        countDownStarted = true;
        timeLeftText.enabled = false;
        timerText.enabled = false;
    }

    private IEnumerator EndCountDown()
    {
        countDownStarted = false;
        countDownText.text = "Survive!";
        yield return new WaitForSeconds(1f);
        countDownText.enabled = false;
        timeLeftText.enabled = true;
        timerText.enabled = true;
    }

    public void UpdateTimeLeft(int time)
    {
        timerText.text = time.ToString();
    }

    public void ShowWinLoseScreen(bool playerWon)
    {
        if (playerWon)
            WinScreen.SetActive(true);
        else if (!playerWon)
            LoseScreen.SetActive(true);

        playerArea.SetActive(false);
    }
}
