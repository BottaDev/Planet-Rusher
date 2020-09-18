using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Player UI")]
    public TextMeshProUGUI timerText;
    public GameObject playerArea;
    [Header("Screens")]
    public GameObject WinScreen;
    public GameObject LoseScreen;

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
