using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private ForwardController Player;
    [SerializeField] private PlayerController InvertedPlayer;

    public bool PlayerFinished;
    public bool InvertedFinished;
    public bool LevelComplete;

    [SerializeField] private Vector3 StartingPos;
    [SerializeField] private Vector3 InvertedStartingPos;

    public bool Key;
    public bool InvertedKey;
    
    public bool IsClockwise;
    public bool IsAntiClockwise;
    public bool IsCentral;

    public int nextSceneLoad;

    [SerializeField] private GameObject LevelFinishPanel;
    [SerializeField] private GameObject PausePanel;

    [SerializeField] private AudioSource Music;
    
    public static LevelManager Instance { get; private set; }
    private void Awake() {

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }

        Instance = this;

        Player = GameObject.Find("Player").gameObject.GetComponent<ForwardController>();
        InvertedPlayer = GameObject.Find("InvertedPlayer").gameObject.GetComponent<PlayerController>();
        
        Player.transform.position = StartingPos;
        InvertedPlayer.transform.position = InvertedStartingPos;

        IsCentral = true;
    }

    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        Cursor.visible = false;
        Time.timeScale = 1.0f;

        if (!Music.isPlaying)
        {
            Music.Play();
        }
    }


    public void ResetLevel()
    {
        Player.transform.position = StartingPos;
        InvertedPlayer.transform.position = InvertedStartingPos;

        Key = false;
        InvertedKey = false;
        PlayerFinished = false;
        InvertedFinished = false;

        foreach (KeyInteration i in FindObjectsOfType<KeyInteration>())
        {
            i.GetComponent<SpriteRenderer>().enabled = true;
        }
        
        foreach (DoorInteraction i in FindObjectsOfType<DoorInteraction>())
        {
            i.CloseDoor();
        }
        
        foreach (ButtonInteraction i in FindObjectsOfType<ButtonInteraction>())
        {
            i.ResetButton();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //ResetLevel();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        Cursor.visible = true;
        PausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        PausePanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (PlayerFinished && InvertedFinished)
        {
            LevelComplete = true;
            LevelFinished();
        }
    }

    public void LevelFinished()
    {
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt") && nextSceneLoad < 7)
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
        
        LevelFinishPanel.SetActive(true);

        Cursor.visible = true;
    }
}
