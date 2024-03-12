using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetWorldBounds : MonoBehaviour
{
    private void Awake()
    {
        var bounds = GetComponent<BoxCollider2D>().bounds;
        Globals.WorldBounds = bounds;
    }
}
