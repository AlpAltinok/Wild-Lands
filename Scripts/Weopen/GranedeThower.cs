using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GranedeThower : MonoBehaviour
{
    public float throweForce =15f;
    public GameObject granedePrefab;
    bool isCooldown;
  
    
    public float abilityCooldown = 10f; 
    private float currentCooldown = 0f;
    private AudioSource ac;

    public Text cooldownText;
    void Start()
    {
        
        isCooldown= true;
        ac = GetComponent<AudioSource>();
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isCooldown)
        {
            
            UseAbility();
            
        }
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;

           
            cooldownText.text = Mathf.CeilToInt(currentCooldown).ToString();

            
            if (currentCooldown <= 0)
            {
                isCooldown = false;
                cooldownText.text = ""; 
            }
        }
    }
    
    
    void UseAbility()
    {
       
        GameObject grenade = Instantiate(granedePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        isCooldown = false;
        rb.AddForce(transform.forward * throweForce, ForceMode.VelocityChange);
        // ac.Play();
        Invoke("PlayDelayedSound", 2.6f);
        // Bekleme süresini baþlat
        StartCoroutine(CooldownTimer());
    }
    IEnumerator CooldownTimer()
    {
        isCooldown = true;
        currentCooldown = abilityCooldown;

        
        while (currentCooldown > 0)
        {
            yield return null;
        }

        isCooldown = false;
        cooldownText.text = ""; // Geri sayýmý temizle
    }

    private void PlayDelayedSound()
    {
        ac.enabled = true;
        ac.Play();
    }








}
