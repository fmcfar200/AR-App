﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class GameManagerScript : MonoBehaviour {

    public static GameManagerScript manager;

    public GameObject testPrefab;

    public int enemyAmount;
    public List<EnemyIcon.Type> types = new List<EnemyIcon.Type>();
    public List<int> levels = new List<int>();

    public int playerLevel;
    public int currentXP;
    bool dataLoaded = false;


    Scene theScene;

	void Awake()
	{
        theScene = SceneManager.GetActiveScene();

        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }

        LoadData();
        

    }

    void Update()
    {
        theScene = SceneManager.GetActiveScene();
        switch (theScene.name)
        {
            case "AR Scene":
                Camera.main.GetComponent<VuforiaBehaviour>().enabled = true;

                break;
            case "Map Scene":
                Camera.main.GetComponent<VuforiaBehaviour>().enabled = false;

                break;

        }

    }
    void LoadData()
    {
        if (!dataLoaded)
        {
            if (PlayerPrefs.HasKey("playerLevel"))
            {
                playerLevel = PlayerPrefs.GetInt("playerLevel");

                Debug.Log("level found: " + PlayerPrefs.GetInt("playerLevel"));
            }
            else
            {
                playerLevel = 1;
            }

            if (PlayerPrefs.HasKey("playerXP"))
            {
                currentXP = PlayerPrefs.GetInt("playerXP");
                Debug.Log("xp found");

            }
            else
            {
                currentXP = 0;
            }
            dataLoaded = true;
        }
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("playerLevel", playerLevel);
        PlayerPrefs.SetInt("playerXP", currentXP);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }


}
