using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBullet : AttackBase
{
    GunAttack gunAttack;

    protected override void Start()
    {
        base.Start();
        gunAttack = transform.GetComponentInChildren<GunAttack>();
    }

    protected override void Update() { base.Update(); }

    public override void Attack()
    {
        base.Attack();
        gunAttack.Shoot(attackWeapon, attackDistance);
    }
}
