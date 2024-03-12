using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button[] lvlButtons;
    public int levelAt;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 1 > levelAt)
            {
                lvlButtons[i].interactable = false;
                lvlButtons[i].transform.GetChild(0).gameObject.SetActive(true);
                lvlButtons[i].transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                lvlButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                lvlButtons[i].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
