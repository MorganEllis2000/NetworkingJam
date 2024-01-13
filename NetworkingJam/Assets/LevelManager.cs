using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public bool PlayerFinished;
    public bool InvertedFinished;
    public bool LevelComplete;
    
    public static LevelManager Instance { get; private set; }
    private void Awake() {

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }

        Instance = this;
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
