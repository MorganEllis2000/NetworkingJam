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

    private bool IsGrounded;

    public bool IsInverted;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Horizontal = Input.GetAxisRaw("Horizontal");

    }

    void MovePlayer()
    {
        rigidBody2D.velocity = new Vector2(_Horizontal * f_RunSpeed, rigidBody2D.velocity.y);
    }

    void MoveInvertedPlayer()
    {
        if (IsInverted)
        {
            rigidBody2D.velocity = new Vector2(-_Horizontal * f_RunSpeed, rigidBody2D.velocity.y);
        }
    }

    private void FixedUpdate()
    {
        if (!LevelManager.Instance.LevelComplete)
        {
            MovePlayer();
            MoveInvertedPlayer();
        }
    }

    public void ChangePlayerSprite()
    {
        /*switch (playerDirection) {
        }*/
    }

}
