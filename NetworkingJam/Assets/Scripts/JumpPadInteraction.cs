using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpPadInteraction : MonoBehaviour
{
    [SerializeField] private Sprite UpSprite;
    [SerializeField] private Sprite DownSprite;

    [SerializeField] private AudioSource SFX;
    
    [Tooltip("This describes how high the player will jump")] [Range(0f, 30f)] [SerializeField]
    protected float JumpHeight = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.GetComponent<SpriteRenderer>().sprite = DownSprite;
            //other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, JumpHeight);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce( Vector2.up * JumpHeight * 30 * Time.deltaTime, ForceMode2D.Impulse);
            if (!SFX.isPlaying)
            {
                SFX.Play();
            }
            
        }
    }

    private IEnumerator ResetSprite()
    {
        yield return new WaitForSeconds(0.05f);
        this.GetComponent<SpriteRenderer>().sprite = UpSprite;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(ResetSprite());
        other.gameObject.GetComponent<PlayerController>().IsGrounded = true;
    }
}
