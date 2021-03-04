using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SpawnPowerUp : BaseSpawner
{
    public bool isSpawned = false;
    public bool isActived;
    public AudioSource audioSource;
    public GameObject stopper;
    private string sceneName;
    private UIManager uiManager;

    protected override void Start()
    {
        base.Start();
        currentSpawnTime = spawnTime;
        uiManager = GameObject.Find("LevelManager").GetComponent<UIManager>();
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
}

    protected override void Update()
    {
        if(!isSpawned && !isActived)
        {
            currentSpawnTime -= Time.deltaTime;
            uiManager.UpdateTimePowerUpLeft((int)currentSpawnTime);
        }
        if (currentSpawnTime <= 0)
        {
            isSpawned = true;
            uiManager.powerUpTimeLeftText.enabled = false;
            uiManager.powerUpSpawned.enabled = true;
            PowerUpType();
        }
    }

    private void PowerUpType()
    {
        int randomSpawn = Random.Range(1, 3);

        switch (randomSpawn)
        {
            case 1:
                SpawnPU();
                break;

            case 2:
                if (sceneName != "Level 1")
                    SpawnStopper();
                break;
        }
    }

    private void SpawnPU()
    {
        Vector3 position = new Vector3(Random.insideUnitSphere.x * sphereCollider.radius, Random.insideUnitSphere.y * sphereCollider.radius, Random.insideUnitSphere.z * sphereCollider.radius);
        Instantiate(objectToSpawn, position, new Quaternion(0, Random.value, 0, 0));
        audioSource.Play();
        currentSpawnTime = spawnTime;
    }

    private void SpawnStopper()
    {
        Vector3 position = new Vector3(Random.insideUnitSphere.x * sphereCollider.radius, Random.insideUnitSphere.y * sphereCollider.radius, Random.insideUnitSphere.z * sphereCollider.radius);
        Instantiate(stopper, position, new Quaternion(0, Random.value, 0, 0));
        audioSource.Play();
        currentSpawnTime = spawnTime;
    }
}
