using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalInteraction : MonoBehaviour
{
    private GameObject Entrance;
    private GameObject Exit;

    private void Awake()
    {
        Exit = this.gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = Exit.transform.position;
        }
    }
}
