using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    [Header("Health Damage")]
    public GameObject damageFx;
    public Transform damageFxPos;

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        Instantiate(damageFx, damageFxPos.position, Quaternion.identity);
    }   

    public virtual void Heal(float heal)
    {
        health += heal;
    }
}
