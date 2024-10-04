using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public float speedMultiplier = 1f;

    public float sensitivity = 40f;

    private new Rigidbody rigidbody;

    private Vector2 input = Vector2.zero;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        Vector2 mouseInput = Mouse.current.delta.ReadValue();

        float mouseX = mouseInput.x * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
    }

    private void FixedUpdate()
    {
        Vector3 movement = rigidbody.rotation * (new Vector3(input.x, 0f, input.y) * speed * speedMultiplier);

        rigidbody.velocity = new Vector3(movement.x, rigidbody.velocity.y, movement.z);
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }
}
