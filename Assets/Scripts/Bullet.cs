using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private void Start()
    {
        Destroy(gameObject, 2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(10);
            Debug.Log(enemy.health);
            Destroy(gameObject);
        }
    }
}
