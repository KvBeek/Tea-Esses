using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] WeaponSwingAttack weaponSwingAttack;
    Patrol patrol = null;
    Player player = null;
    [SerializeField] AttackReload attackReload = null;
    [SerializeField] float atttackDistance = 3f;

    private void Start()
    {
        weaponSwingAttack = GetComponent<WeaponSwingAttack>();
        patrol = GetComponent<Patrol>();
        player = FindObjectOfType<Player>();
        attackReload = transform.GetComponentInChildren<AttackReload>();
        weaponSwingAttack.SetAsEnemy();
    }

    private void Update()
    {
        if (!patrol.IsFollowing() || attackReload.reload) return;
        AttackInRange();
    }

    void AttackInRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < atttackDistance)
            weaponSwingAttack.Attack();
    }
}
