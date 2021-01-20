using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Player UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timeLeftText;
    public TextMeshProUGUI countDownText;
    public GameObject playerArea;
    public Image shotIndicator;
    public TextMeshProUGUI powerUpTimerText;
    public TextMeshProUGUI powerUpTimeLeftText;
    public TextMeshProUGUI powerUpSpawned;
    public TextMeshProUGUI powerUpActived;

    [Header("Screens")]
    public GameObject WinScreen;
    public GameObject LoseScreen;

    private float countDownTimer = 3f;
    private bool countDownStarted = false;
    private bool inCooldown = false;
    private float fireRate;

    private void Start()
    {
        shotIndicator.fillAmount = 1f;
    }

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

        if (inCooldown)
        {
            shotIndicator.fillAmount += 1 / fireRate * Time.deltaTime;

            if(shotIndicator.fillAmount >= 1)
            {
                inCooldown = false;
                shotIndicator.fillAmount = 1;
            }
        }
    }

    // Starts the initial count down
    public void StartCountDown()
    {
        countDownText.enabled = true;
        countDownStarted = true;
        timeLeftText.enabled = false;
        timerText.enabled = false;
        shotIndicator.enabled = false;
        powerUpTimeLeftText.enabled = false;
        powerUpTimerText.enabled = false;
        powerUpActived.enabled = false;
        powerUpSpawned.enabled = false;
    }

    private IEnumerator EndCountDown()
    {
        countDownStarted = false;
        countDownText.text = "Survive!";
        yield return new WaitForSeconds(1f);
        countDownText.enabled = false;
        timeLeftText.enabled = true;
        timerText.enabled = true;
        shotIndicator.enabled = true;
        powerUpTimerText.enabled = true;
        powerUpTimeLeftText.enabled = true;
    }

    public void UpdateTimeLeft(int time)
    {
        timerText.text = time.ToString();
        powerUpTimerText.text = time.ToString();
    }

    public void ShowWinLoseScreen(bool playerWon)
    {
        if (playerWon)
            WinScreen.SetActive(true);
        else if (!playerWon)
            LoseScreen.SetActive(true);

        playerArea.SetActive(false);
    }

    public void StartCd(float amount)
    {
        shotIndicator.fillAmount = 0f;
        fireRate = amount;
        inCooldown = true;
    }
}
