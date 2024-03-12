using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public BoxCollider2D levelCollider;
    public float sizeX, sizeY;

    public GameObject miniMap;
    public Image playerUI;
    public ForwardController player;
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        miniMap = this.gameObject;
        sizeX = levelCollider.size.x;
        sizeY = levelCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(player.transform.position);
        
        float x = screenPos.x / sizeX;
        float y = screenPos.y / sizeY;
        
        playerUI.transform.position = new Vector3(x, y, 0);
    }
}
