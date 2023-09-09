using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashAction : ControllerBase
{
    [SerializeField] InputActionReference attackAction;
    Rigidbody rb;

    [SerializeField] float dashSpeed = 25f;
    [SerializeField] float dashDuration = 0.25f;
    [SerializeField] float dashCooldown = 0.25f;
    public bool isDashing { get; private set; } = false;
    bool canDash = true;

    Vector3 dashDirection;

    protected override void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInputManager.FindAction(attackAction.name).performed += ctx => Dash();
    }

    void Dash()
    {
        if (!canDash) return;
        dashDirection = rb.velocity.normalized;
        StartCoroutine(DashActivated());
    }

    private IEnumerator DashActivated()
    {
        canDash = false;
        isDashing = true;
        rb.AddForce(dashDirection * dashSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(dashDuration);
        canDash = true;
    }
}
