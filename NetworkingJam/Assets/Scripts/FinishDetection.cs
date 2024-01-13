using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishDetection : MonoBehaviour
{

    public bool PlayerFinished;
    public bool InvertedPlayerFinished;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            LevelManager.Instance.PlayerFinished = true;
        } else if (other.gameObject.name == "InvertedPlayer")
        {
            LevelManager.Instance.InvertedFinished = true;
        }
    }
}
