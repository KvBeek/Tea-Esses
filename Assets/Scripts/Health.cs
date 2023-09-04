using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject[] healthObject = null;
    [SerializeField] int currentHealth = 0;
    [SerializeField] int totalHealth = 3;

    private void Start()
    {
        totalHealth = healthObject.Length;
        currentHealth = totalHealth;
    }

    public void TakeDamage(int pDamage = 1)
    {
        currentHealth -= 1;
        if (currentHealth < 0) return;
        healthObject[currentHealth].SetActive(false);
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
