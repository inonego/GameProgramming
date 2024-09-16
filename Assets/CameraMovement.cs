using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10f;
    public float sensitivity = 60.0f;

    private float x = 0f, y = 0f;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        x -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        y += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        transform.position += transform.rotation * new Vector3(h, 0f, v) * speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(Mathf.Clamp(x, -90f, 90f), y, 0f);
    }
}
