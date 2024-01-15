using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{

    [SerializeField] private Sprite UpSprite;
    [SerializeField] private Sprite DownSprite;
    [SerializeField] private DoorInteraction DoorToOpen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && DoorToOpen.DoorOpened == false)
        {
            this.GetComponent<SpriteRenderer>().sprite = DownSprite;
            DoorToOpen.OpenDoor();
        }
    }

    public void ResetButton()
    {
        this.GetComponent<SpriteRenderer>().sprite = UpSprite;
    }
}
