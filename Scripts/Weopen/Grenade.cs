using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grenade: MonoBehaviour
{
    public float delay = 0.0f;
    float countdown;

    public int bomForce=700;
    public float radius = 5f;
    public GameObject boomEffect;
    bool hasExploded = false;
  
    void Start()
    {
        countdown = delay;
      
  
    }

   
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
            
        }
    }
    void Explode()
    {
        Instantiate(boomEffect, transform.position, transform.rotation);
       
        Collider[] colliders= Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliders)
        {
           Rigidbody rb  =nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(bomForce,transform.position,radius);
               
                
            }
        }


        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Zombi")
        {
            Zombie.zombieHp -= 40;
            Debug.Log("zombi 40 yedi");
        }
    }
}
