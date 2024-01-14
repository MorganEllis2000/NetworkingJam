using System;
using System.Collections;
using System.Collections.Generic;
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
    
    public static LevelManager Instance { get; private set; }
    private void Awake() {

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }

        Instance = this;

        Player.transform.position = StartingPos;
        InvertedPlayer.transform.position = InvertedStartingPos;
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (PlayerFinished && InvertedFinished)
        {
            LevelComplete = true;
        }
    }
}
