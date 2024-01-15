using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{

    public bool DoorOpened;
    public void OpenDoor()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Transform>().eulerAngles = new Vector3(0, 84, 0);
        DoorOpened = true;
    }
    
    public void CloseDoor()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        DoorOpened = false;
    }
}
