using UnityEngine;

public class RStickAim : ControllerBase
{
    Vector2 aiming;

    protected override void Update()
    {
        base.Update();

        aiming = playerInputManager.Player.Aiming.ReadValue<Vector2>();

        if (aiming == Vector2.zero) return;

        float angle = Mathf.Atan2(aiming.x, aiming.y) * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.up * angle;
    }

    private void FixedUpdate()
    {
        aiming = playerInputManager.Player.Aiming.ReadValue<Vector2>();

        if (aiming == Vector2.zero) return;

        float angle = Mathf.Atan2(aiming.x, aiming.y) * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.up * angle;
    }
}
