using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level Settings")]
    public float levelTime = 60f;       // Time to win the level
    [Header("Camera")]
    public GameObject endGameCamera;

    private float currentLevelTime;
    private UIManager uiManager;
    private bool gameEnded = true;

    private void Start()
    {
        currentLevelTime = levelTime;
        uiManager = GetComponent<UIManager>();
        StartCoroutine(StartLevel());
    }

    private void Update()
    {
        CheckGameState();
    }

    private void CheckGameState()
    {
        if (currentLevelTime <= 0 && !gameEnded)
            WinLoseGame(true);
        else if (currentLevelTime > 0 && !gameEnded)
        {
            currentLevelTime -= Time.deltaTime;
            uiManager.UpdateTimeLeft((int)currentLevelTime);
        }
    }

    private IEnumerator StartLevel()
    {
        uiManager.StartCountDown();
        yield return new WaitForSeconds(3f);
        gameEnded = false;
    }

    public void WinLoseGame(bool playerWon)
    {
        if (playerWon && !gameEnded)
        {
            uiManager.ShowWinLoseScreen(playerWon);

            PlayerInput player = GameObject.Find("Player").GetComponent<PlayerInput>();
            player.enabled = false;
        }
        else if (!playerWon && !gameEnded)
            uiManager.ShowWinLoseScreen(playerWon);

        endGameCamera.SetActive(true);
        gameEnded = true;
    }
}
