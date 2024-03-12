using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Range(0, 15.0f)]
    [SerializeField] private float speed;

    [SerializeField] private int startingPoint;
    [SerializeField] private Transform[] points;

    private int arrIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[arrIndex].position) < 0.02f)
        {
            arrIndex++;
            if (arrIndex == points.Length)
            {
                arrIndex = startingPoint;
            }
        }

        transform.position =Vector2.MoveTowards(transform.position, points[arrIndex].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.SetParent((transform));
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }
}
