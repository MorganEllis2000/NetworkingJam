using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SwitchInteraction : MonoBehaviour
{
    public Tilemap _tilemap;

    public bool IsClockwise;
    public bool IsAntiClockwise;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Q) && !LevelManager.Instance.IsAntiClockwise && LevelManager.Instance.IsCentral)
            {
                LevelManager.Instance.IsAntiClockwise = true;
                LevelManager.Instance.IsCentral = false;

                foreach (PlayerController i in FindObjectsOfType<PlayerController>())
                {
                    i.gameObject.transform.eulerAngles = new Vector3(0, 0, 90f);
                }
                
                //other.gameObject.transform.eulerAngles = new Vector3(0, 0, 90f);
                
                _tilemap.gameObject.transform.eulerAngles = new Vector3(0, 0, -90f);
                Camera.main.orthographicSize = 9.05f;
                other.transform.position = this.gameObject.transform.position;
            } else if (Input.GetKey((KeyCode.E)) && LevelManager.Instance.IsAntiClockwise && !LevelManager.Instance.IsCentral)
            {
                LevelManager.Instance.IsAntiClockwise = false;
                LevelManager.Instance.IsCentral = true;
                _tilemap.gameObject.transform.eulerAngles = new Vector3(0, 0, 0f);
                foreach (PlayerController i in FindObjectsOfType<PlayerController>())
                {
                    i.gameObject.transform.eulerAngles = new Vector3(0, 0, 0f);
                }
                Camera.main.orthographicSize = 5.0f;
                other.transform.position = this.gameObject.transform.position;
            } 
            
            if (Input.GetKey(KeyCode.E) && !LevelManager.Instance.IsClockwise && LevelManager.Instance.IsCentral)
            {
                LevelManager.Instance.IsClockwise = true;
                LevelManager.Instance.IsCentral = false;
                foreach (PlayerController i in FindObjectsOfType<PlayerController>())
                {
                    i.gameObject.transform.eulerAngles = new Vector3(0, 0, -90f);
                }
                _tilemap.gameObject.transform.eulerAngles = new Vector3(0, 0, 90f);
                Camera.main.orthographicSize = 9.05f;
                other.transform.position = this.gameObject.transform.position;
            } else if (Input.GetKey((KeyCode.Q)) && LevelManager.Instance.IsClockwise && !LevelManager.Instance.IsCentral)
            {
                LevelManager.Instance.IsClockwise = false;
                LevelManager.Instance.IsCentral = true;
                _tilemap.gameObject.transform.eulerAngles = new Vector3(0, 0, 0f);
                foreach (PlayerController i in FindObjectsOfType<PlayerController>())
                {
                    i.gameObject.transform.eulerAngles = new Vector3(0, 0, 0f);
                }
                Camera.main.orthographicSize = 5.0f;
                other.transform.position = this.gameObject.transform.position;
            }
        }
    }
}
