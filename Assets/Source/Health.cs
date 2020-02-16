using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;
    public GameObject SpawnOnDeath;
    public float DebrisLife;

    public void TakeDamage (float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth < 0)
        {
            Destroy(gameObject);
            if (SpawnOnDeath)
            {
                GameObject debris = Instantiate(SpawnOnDeath, transform.position, transform.rotation);
                Destroy(debris, DebrisLife);
            }
        }
    }
}
