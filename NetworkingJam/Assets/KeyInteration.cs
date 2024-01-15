using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteration : MonoBehaviour
{
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
            LevelManager.Instance.Key = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
        } else if (other.gameObject.name == "InvertedPlayer")
        {
            LevelManager.Instance.InvertedKey = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
