﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    public DataSave dataSave;
    [SerializeField]
    private string savePath = "/Save.sav";
    private string sceneName;

    private void Awake()
    {
        if (instance == null)
            instance = this;

#if UNITY_EDITOR
        savePath = Application.streamingAssetsPath + savePath;
#else
        savePath = Application.persistentDataPath + savePath;
#endif
    }

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if(sceneName == "Main Menu")
            LoadData();
    }

    public void SaveData()
    {
        StreamWriter streamWriter = null;
        try
        {
            if (sceneName != "Main Menu")
            {
#if UNITY_EDITOR
                if (!Directory.Exists(Application.streamingAssetsPath))
                    Directory.CreateDirectory(Application.streamingAssetsPath);
#else
                if (!Directory.Exists(Application.persistentDataPath))
                    Directory.CreateDirectory(Application.persistentDataPath);
#endif

                if (!File.Exists(savePath))
                    streamWriter = File.CreateText(savePath);
                else
                    streamWriter = new StreamWriter(savePath, false);

                switch (sceneName)
                {
                    case "Level 1":
                        dataSave.level1Completed = true;
                        break;

                    case "Level 2":
                        dataSave.level1Completed = true;
                        dataSave.level2Completed = true;
                        break;

                    case "Level 3":
                        dataSave.level1Completed = true;
                        dataSave.level2Completed = true;
                        dataSave.level3Completed = true;
                        break;

                    case "Level 4":
                        dataSave.level1Completed = true;
                        dataSave.level2Completed = true;
                        dataSave.level3Completed = true;
                        dataSave.level4Completed = true;
                        break;
                }

                streamWriter.Write(dataSave.DeserializeData());
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        finally
        {
            if (streamWriter != null)
                streamWriter.Close();
        }
    }

    private void LoadData()
    {
        if (File.Exists(savePath))
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(savePath);
                dataSave = DataSave.SerializeData(streamReader.ReadToEnd());
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }
        }
        else
        {
            Debug.LogWarning("No save file could be found!");
        }
    }
}
