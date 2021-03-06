﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonScript : MonoBehaviour {

    PlayerCombatScript playerCombat;
    public Button[] buttons;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "AR Scene")
        {
            playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombatScript>();
        }

        if (playerCombat == null)
        {
            Debug.LogError("Player combat not found");
        }
    }

	public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void FireButton()
    {
        playerCombat.fire = true;
    }
}
