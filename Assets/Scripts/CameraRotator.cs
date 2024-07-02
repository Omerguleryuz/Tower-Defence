using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    private float rotationSpeed = 17.5f;
    private float previousMousePosX, currentMousePosX; 

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            previousMousePosX = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(1))
        {
            currentMousePosX = Input.mousePosition.x;
            float deltaY = currentMousePosX - previousMousePosX;

            transform.Rotate(Vector3.up, deltaY * rotationSpeed * Time.deltaTime);
        }
        previousMousePosX = currentMousePosX;
    }
}