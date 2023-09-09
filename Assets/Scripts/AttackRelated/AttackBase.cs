using UnityEngine;
using UnityEngine.InputSystem;

public class AttackBase : ControllerBase
{
    [SerializeReference] AttackReload attackReload;
    [SerializeReference] HitHittableObject hitHittableObject;

    [SerializeReference] protected GameObject attackWeapon;
    [SerializeReference] float attackFillSpeed = 1f;
    [SerializeReference] protected float attackDistance = 30;
    [SerializeReference] InputActionReference attackAction;
    [SerializeReference] bool isEnemy = false;

    protected override void Start()
    {
        base.Start();
        attackReload = transform.GetComponentInChildren<AttackReload>();
        hitHittableObject = attackWeapon.GetComponentInChildren<HitHittableObject>();
        if (attackAction != null) attackAction.action.Enable();
    }
    public void SetAsEnemy()
    {
        isEnemy = true;
    }

    protected override void Update()
    {
        if (hitHittableObject.GetHitState()) HasHitHittable();
        if (attackReload.reload && !isEnemy) return;
        ControllerInput();
    }

    void ControllerInput()
    {
        if (attackAction == null) return;
        if (playerInputManager.FindAction(attackAction.name).IsPressed())
            Attack();
    }

    public virtual void Attack()
    {
        attackReload.ReloadAttackUI(attackFillSpeed);
    }

    void HasHitHittable()
    {
        GameObject hittedObject = hitHittableObject.GetHittenObject();
        Health health = hittedObject.GetComponent<Health>();
        health.TakeDamage();
        hitHittableObject.SetHitState(false);

        if (health.GetHealth() <= 0) hittedObject.SetActive(false);
    }

}
