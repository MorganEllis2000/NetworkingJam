using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedController : PlayerController
{
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = this.GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        if (!LevelManager.Instance.LevelComplete)
        {
            _Horizontal = Input.GetAxisRaw("Horizontal");
            rigidBody2D.velocity = new Vector2(-_Horizontal * f_RunSpeed, rigidBody2D.velocity.y);
        }


    }
}
