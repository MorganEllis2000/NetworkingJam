using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewMap : MonoBehaviour
{
    [SerializeField] private Camera _camera1;
    [SerializeField] private Camera _camera2;
    [SerializeField] private Camera _camera3;
    
    void Start()
    {
        
    }

    void ZoomIn()
    {

        _camera1.GetComponent<Camera>().enabled = true;
        _camera2.GetComponent<Camera>().enabled = true;
        _camera3.GetComponent<Camera>().enabled = false;
    }

    void ZoomOUt()
    {
        _camera1.GetComponent<Camera>().enabled = false;
        _camera2.GetComponent<Camera>().enabled = false;
        _camera3.GetComponent<Camera>().enabled = true;
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ZoomOUt();
        } else if (Input.GetKeyUp(KeyCode.Z))
        {
            ZoomIn();
        }
    }
}
