public class WeaponAttack : AttackBase
{
    AttackSwing attackSwingObject;

    protected override void Start()
    {
        base.Start();
        attackSwingObject = transform.GetComponentInChildren<AttackSwing>();
    }

    protected override void Update() { base.Update(); }

    public override void Attack()
    {
        base.Attack();
        attackSwingObject.Swing(attackWeapon, attackDistance);
    }
}
