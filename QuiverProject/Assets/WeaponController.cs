using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bulletObject = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            CrossBow bullet = bulletObject.GetComponent<CrossBow>();
            bullet.Fire();
        }
    }
}
