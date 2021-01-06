using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button playButton;
    public GameObject lockedText;

    [Range(min: 1, max: 4 )]
    public int selectedLevel = 1;

    public void ChangeLevelSelection(int index)
    {
        int tempSelectedLevel = selectedLevel;
        selectedLevel += index;

        if (selectedLevel < 1 || selectedLevel > 4)
            selectedLevel = tempSelectedLevel;

        CheckLevelAvailability();
    }

    private void CheckLevelAvailability()
    {
        switch (selectedLevel)
        {
            case 1:
                lockedText.SetActive(false);
                playButton.interactable = true;
                break;

            case 2:
                if (GameManager.instance.dataSave.level2Completed)
                {
                    lockedText.SetActive(false);
                    playButton.interactable = true;
                }
                else
                {
                    lockedText.SetActive(true);
                    playButton.interactable = false;
                }
                break;

            case 3:
                if (GameManager.instance.dataSave.level3Completed)
                {
                    lockedText.SetActive(false);
                    playButton.interactable = true;
                }
                else
                {
                    lockedText.SetActive(true);
                    playButton.interactable = false;
                }
                break;

            case 4:
                if (GameManager.instance.dataSave.level4Completed)
                {
                    lockedText.SetActive(false);
                    playButton.interactable = true;
                }
                else
                {
                    lockedText.SetActive(true);
                    playButton.interactable = false;
                }
                break;
        }
        
    }
}
