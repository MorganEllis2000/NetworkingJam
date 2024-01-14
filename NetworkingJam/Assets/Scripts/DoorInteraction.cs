using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public void OpenDoor()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Transform>().Rotate(0, 84.0f, 0);
    }
}
