using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    [Range(min: 1, max: 5)]
    public int selectedLevel = 1;

    [Header("UI")]
    public Button playButton;
    public TMP_Text buttonText;
    public GameObject lockedText;

    [Header("Objects")]
    public GameObject[] levelProps;

    public void ChangeLevelSelection(int index)
    {
        int tempSelectedLevel = selectedLevel;
        selectedLevel += index;

        if (selectedLevel < 1 || selectedLevel > 5)
            selectedLevel = tempSelectedLevel;

        CheckLevelAvailability();
    }

    private void CheckLevelAvailability()
    {
        switch (selectedLevel)
        {
            case 1:
                SetMenu(true);

                DisableProps();
                levelProps[0].SetActive(true);
                break;

            case 2:
                SetMenu(GameManager.instance.dataSave.level2Completed);

                DisableProps();
                levelProps[1].SetActive(true);
                DisableProps();
                break;

            case 3:
                SetMenu(GameManager.instance.dataSave.level3Completed);

                DisableProps();
                levelProps[2].SetActive(true);
                break;

            case 4:
                SetMenu(GameManager.instance.dataSave.level4Completed);

                DisableProps(); 
                levelProps[3].SetActive(true);
                break;

            case 5:
                SetMenu(GameManager.instance.dataSave.level5Completed);

                DisableProps();
                levelProps[4].SetActive(true);
                break;
        }
    }

    private void DisableProps()
    {
        for (int i = 0; i < levelProps.Length; i++)
        {
            levelProps[i].SetActive(false);
        }
    }

    private void SetMenu(bool levelCompleted)
    {
        if (levelCompleted)
        {
            lockedText.SetActive(false);
            playButton.interactable = true;
            buttonText.color = Color.white;
        }
        else
        {
            lockedText.SetActive(true);
            playButton.interactable = false;
            buttonText.color = Color.black;
        }        
    }
}
