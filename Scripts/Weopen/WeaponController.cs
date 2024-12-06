using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab; // Kurþun veya mermi prefabý
    public Transform firePoint;     // Ateþ noktasý, nereden kurþunun çýkacaðýný belirler
    
    public float bulletForce = 10000f;
    private bool canShoot = true;
    private float fireRate = 1f;
   


   

    private void Update()
    {
        if (CharacterController.Fire==true && canShoot==true)
        {


            StartCoroutine(Shoot());
          
            Debug.Log("ates edildi");
        }
       
    }

   IEnumerator Shoot()
    {
        canShoot = false;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        yield return new WaitForSeconds(1f / fireRate);
        canShoot = true;
        Destroy(bullet,5f);
    }
}
