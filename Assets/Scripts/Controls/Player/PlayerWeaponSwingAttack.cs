using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponSwingAttack : ControllerBase
{
    AttackReload attackReload;
    AttackSwing attackSwing;

    [SerializeField] GameObject attackWeapon;
    [SerializeField] float attackFillSpeed = 1f;
    [SerializeField] float attackSwingDistance = 30;
    [SerializeField] InputActionReference attackAction;

    private void Start()
    {
        attackReload = FindObjectOfType<AttackReload>();
        attackSwing = FindObjectOfType<AttackSwing>();
        attackAction.action.Enable();
    }

    private void Update()
    {
        if (attackReload.reload) return;

        if (playerInputManager.FindAction(attackAction.name).IsPressed())
        {
            attackReload.ReloadAttackUI(attackFillSpeed);
            attackSwing.Swing(attackWeapon, attackSwingDistance);
        }
    }
}
