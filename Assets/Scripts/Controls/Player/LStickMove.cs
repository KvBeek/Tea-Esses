using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LStickMove : ControllerBase
{
    [SerializeField] float speed = 1f;

    Rigidbody rb;

    Vector2 movement = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement = playerInputManager.Player.Movement.ReadValue<Vector2>();

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.y) * speed;
    }

}
