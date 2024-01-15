using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private PlayerController Player;
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
    
    public static LevelManager Instance { get; private set; }
    private void Awake() {

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }

        Instance = this;

        Player = GameObject.Find("Player").gameObject.GetComponent<PlayerController>();
        InvertedPlayer = GameObject.Find("InvertedPlayer").gameObject.GetComponent<PlayerController>();
        
        Player.transform.position = StartingPos;
        InvertedPlayer.transform.position = InvertedStartingPos;

        IsCentral = true;
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
            ResetLevel();
        }
    }


    private void FixedUpdate()
    {
        if (PlayerFinished && InvertedFinished)
        {
            LevelComplete = true;
        }


    }
}
