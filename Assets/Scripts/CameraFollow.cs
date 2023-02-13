using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Range(0f, 10f)]
    public float smoothFactor;

    public Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Vector3.Lerp(cam.transform.position, transform.position, smoothFactor * Time.deltaTime);
        newPos.z = -10;

        cam.transform.position = newPos;

    }
}

