using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerDirection
    {
        NONE,
        LEFT,
        RIGHT,
        FALLING
    }

    private PlayerDirection playerDirection;

    [Tooltip("This describes how fast the player will move")] [Range(0f, 30f)] [SerializeField]
    protected float f_RunSpeed = 0.0f;

    protected Rigidbody2D rigidBody2D;
    public SpriteRenderer spriteRenderer;
    
    private float _Horizontal;

    public bool IsGrounded;

    public bool IsInverted;

    [SerializeField] private float Acceleration = 0;
    [SerializeField] private float TopSpeed = 10;
    [SerializeField] private float AccelerationTime = 3.0f;
    [SerializeField] private float Speed = 0;
    [SerializeField] private Vector2 Velocity = new Vector2(0, 0);
    

    void Start()
    {
        IsGrounded = true;
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Horizontal = Input.GetAxisRaw("Horizontal");

    }

    void MovePlayer()
    {
        /*if (IsGrounded)
        {
            if (_Horizontal == 1 || _Horizontal == -1)
            {
                Acceleration = TopSpeed / AccelerationTime;
            
                Speed += Acceleration * Time.deltaTime;
        
                if(Speed > TopSpeed)
                {
                    Speed = TopSpeed;
                }
        
                Velocity = new Vector2(Speed * _Horizontal * Time.deltaTime, rigidBody2D.velocity.y);
            
            }
            else
            {
                Speed = 0.0f;
                Acceleration = 0.0f;
                Velocity = new Vector2(0, rigidBody2D.velocity.y);
            }
        
            rigidBody2D.velocity = Velocity;
        }*/

        
        rigidBody2D.velocity = new Vector2(_Horizontal * f_RunSpeed, rigidBody2D.velocity.y);
    }

    void MoveInvertedPlayer()
    {
        /*if (_Horizontal == 1 || _Horizontal == -1)
        {
            Acceleration = TopSpeed / AccelerationTime;
            
            Speed += Acceleration * Time.deltaTime;
        
            if(Speed > TopSpeed)
            {
                Speed = TopSpeed;
            }
        
            Velocity = new Vector2(Speed * -_Horizontal * Time.deltaTime, rigidBody2D.velocity.y);
            
        }
        else
        {
            Speed = 0.0f;
            Acceleration = 0.0f;
            Velocity = new Vector2(0, rigidBody2D.velocity.y);
        }
        
        rigidBody2D.velocity = Velocity;*/
        
        rigidBody2D.velocity = new Vector2(-_Horizontal * f_RunSpeed, rigidBody2D.velocity.y);
    }

    private void FixedUpdate()
    {
        if (!LevelManager.Instance.LevelComplete)
        {
            

            if (IsInverted)
            {
                MoveInvertedPlayer();
            }
            else
            {
                MovePlayer();
            }
            
        }
    }

    public void ChangePlayerSprite()
    {
        /*switch (playerDirection) {
        }*/
    }

}
