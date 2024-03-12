using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteration : MonoBehaviour
{
    [SerializeField] private AudioSource SFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && !LevelManager.Instance.Key)
        {
            LevelManager.Instance.Key = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
            
            if (!SFX.isPlaying)
            {
                SFX.Play();
            }
        } else if (other.gameObject.name == "InvertedPlayer" && !LevelManager.Instance.InvertedKey)
        {
            LevelManager.Instance.InvertedKey = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
            
            if (!SFX.isPlaying)
            {
                SFX.Play();
            }
        }


    }
}
