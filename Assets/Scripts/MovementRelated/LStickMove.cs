using UnityEngine;

public class LStickMove : ControllerBase
{
    [SerializeField] float speed = 1f;
    DashAction dashAction;

    Rigidbody rb;

    public Vector2 movement = Vector2.zero;

    protected override void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashAction = GetComponent<DashAction>();
    }

    private void FixedUpdate()
    {
        movement = playerInputManager.Player.Movement.ReadValue<Vector2>().normalized * speed;
        if (dashAction.isDashing) return;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.y);
    }

}
