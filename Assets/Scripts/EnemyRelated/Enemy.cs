using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] WeaponSwingAttack weaponSwingAttack;
    Patrol patrol = null;
    Player player = null;
    [SerializeField] AttackReload attackReload = null;
    [SerializeField] float atttackDistance = 3f;
    [SerializeField] float rotationSpeed = 2f;

    private void Start()
    {
        weaponSwingAttack = GetComponent<WeaponSwingAttack>();
        patrol = GetComponent<Patrol>();
        player = FindObjectOfType<Player>();
        attackReload = transform.GetComponentInChildren<AttackReload>();

        // mark this gameobject as enemy inside the WeaponSwingAttack script
        weaponSwingAttack.SetAsEnemy();
    }

    private void Update()
    {
        // Check if player is being follow
        if (!patrol.IsFollowing()) return;

        // Rotate towards player when not moving, otherwise enemy always misses
        Vector3 direction = player.transform.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction, transform.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);

        // If reload is not active, attack if in range
        if (attackReload.reload) return;
        AttackInRange();
    }

    void AttackInRange()
    {
        // If player is in range, attack
        if (Vector3.Distance(transform.position, player.transform.position) < atttackDistance && player.gameObject.activeSelf)
            weaponSwingAttack.Attack();
    }
}
