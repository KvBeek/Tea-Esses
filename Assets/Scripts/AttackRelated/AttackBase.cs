using UnityEngine;
using UnityEngine.InputSystem;

public class AttackBase : ControllerBase
{
    [SerializeReference] AttackReload attackReload = null;
    [SerializeReference] HitHittableObject hitHittableObject = null;

    [SerializeReference] protected GameObject attackWeapon = null;
    [SerializeReference] float attackFillSpeed = 1f;
    [SerializeReference] protected float attackDistance = 30;
    [SerializeReference] InputActionReference attackAction = null;
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
        if (hitHittableObject.GetHitState())
            HasHitHittable();

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
        hitHittableObject.SetHitState(false);
        GameObject hittedObject = hitHittableObject.GetHittenObject();

        if (Bounce(hittedObject)) return;

        Health health = hittedObject.GetComponent<Health>();
        health.TakeDamage();

        if (health.GetHealth() <= 0) hittedObject.SetActive(false);
    }

    bool Bounce(GameObject pHittedObject)
    {
        BounceOffAttack boa = null;

        Transform parent = null;
        if (pHittedObject.transform.parent != null)
            parent = pHittedObject.transform.parent.transform;

        if (parent != null)
            boa = parent.GetComponent<BounceOffAttack>();

        if (boa != null)
        {
            var obj = Instantiate(attackWeapon);

            obj.transform.position = attackWeapon.transform.position;
            obj.transform.rotation = attackWeapon.transform.rotation;

            foreach (BoxCollider t in obj.GetComponentsInChildren<BoxCollider>())
                Destroy(t);
            foreach (Rigidbody t in obj.GetComponentsInChildren<Rigidbody>())
                Destroy(t);
            foreach (HitHittableObject t in obj.GetComponentsInChildren<HitHittableObject>())
                Destroy(t);
            attackWeapon.SetActive(false);
            return true;
        }
        return false;
    }
}
