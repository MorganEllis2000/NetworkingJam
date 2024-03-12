///////////// https://www.youtube.com/watch?v=Fqht4gyqFbo

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)] public float smoothFactor;
    public Vector3 minValues, maxValues;
    private Bounds _cameraBounds;
    private Vector3 targetPosition;
    private Vector3 boundPosition;

    public string name;

    private void Start()
    {
        SetBounds();
        name = target.name;
    }

    private void FixedUpdate()
    {
        Follow();
    }

    void SetBounds()
    {
        var height = this.GetComponent<Camera>().orthographicSize;
        var width = height * this.GetComponent<Camera>().aspect;

        var minX = Globals.WorldBounds.min.x + height;
        var maxX = Globals.WorldBounds.extents.x - width;

        var minY = Globals.WorldBounds.min.y + height;
        var maxY = Globals.WorldBounds.extents.y - height;

        _cameraBounds = new Bounds();
        _cameraBounds.SetMinMax(
            new Vector3(minX, minY, 0.0f),
            new Vector3(maxX, maxY, 0.0f)
        );
    }
    
    private Vector3 GetLeftCameraBounds()
    {
        return new Vector3(
            Mathf.Clamp(targetPosition.x, _cameraBounds.min.x, _cameraBounds.max.x / 2),
            Mathf.Clamp(targetPosition.y, _cameraBounds.min.y, _cameraBounds.max.y),
            -10.0f
        );
    }
    
    private Vector3 GetRightCameraBounds()
    {
        return new Vector3(
            Mathf.Clamp(targetPosition.x, (_cameraBounds.max.x / 2), _cameraBounds.max.x),
            Mathf.Clamp(targetPosition.y, _cameraBounds.min.y, _cameraBounds.max.y),
            -10.0f
        );
    }
    
    private Vector3 GetCameraBounds()
    {
        return new Vector3(
            Mathf.Clamp(targetPosition.x, _cameraBounds.min.x, _cameraBounds.max.x),
            Mathf.Clamp(targetPosition.y, _cameraBounds.min.y, _cameraBounds.max.y),
            -10.0f
        );
    }

    void Follow()
    {
        targetPosition = target.position + offset;

        //boundPosition = GetCameraBounds();
        
        boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValues.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z));
        
        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
