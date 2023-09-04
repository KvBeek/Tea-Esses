using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwingAttack : ControllerBase
{
    AttackReload attackReload;
    AttackSwing attackSwing;
    HitHittableObject hitHittableObject;

    [SerializeField] GameObject attackWeapon;
    [SerializeField] float attackFillSpeed = 1f;
    [SerializeField] float attackSwingDistance = 30;
    [SerializeField] InputActionReference attackAction;
    [SerializeField] bool isEnemy = false;

    private void Start()
    {
        attackReload = transform.GetComponentInChildren<AttackReload>();
        attackSwing = transform.GetComponentInChildren<AttackSwing>();
        hitHittableObject = attackWeapon.GetComponent<HitHittableObject>();
        if (attackAction != null) attackAction.action.Enable();
    }
    public void SetAsEnemy()
    {
        isEnemy = true;
    }


    private void Update()
    {
        if (hitHittableObject.GetHitState()) HasHitHittable();
        if (attackReload.reload && !isEnemy) return;
        ControllerInput();
    }

    void ControllerInput()
    {
        if (attackAction == null) return;
        if (playerInputManager.FindAction(attackAction.name).IsPressed())
        {
            Attack();
        }
    }

    public void Attack()
    {
        attackReload.ReloadAttackUI(attackFillSpeed);
        attackSwing.Swing(attackWeapon, attackSwingDistance);
    }

    void HasHitHittable()
    {
        Health health = hitHittableObject.GetHittenObject().GetComponent<Health>();
        health.TakeDamage();
        hitHittableObject.SetHitState(false);

        if(health.GetHealth() <= 0) hitHittableObject.GetHittenObject().SetActive(false);
    }
}
