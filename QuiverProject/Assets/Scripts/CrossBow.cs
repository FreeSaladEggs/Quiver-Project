using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;
    public int bulletDamage = 1;
    public GameObject hitEffect;

    private Rigidbody obj;
    [SerializeField] bool isCollided; 

    private void Start()
    {
        obj = GetComponent<Rigidbody>();
        Destroy(gameObject, bulletLifetime);
    }


    /* private void OnTriggerEnter(Collider other)
     {
        /EnemyController enemy = other.GetComponent<EnemyController>();

         if (enemy != null)
         {
             enemy.TakeDamage(bulletDamage);
         }

         Instantiate(hitEffect, transform.position, Quaternion.identity);

         Destroy(gameObject);
     }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            isCollided = true;
        }
    }
    public void Fire()
    {
        obj.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }
}
