using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerGame : MonoBehaviour
{
    AudioSource ac;
    [SerializeField] private AudioClip fire;
    [SerializeField] private AudioClip zombi;

    void Start()
    {
        ac = GetComponent<AudioSource>();
    }
    public void Zombie()
    {
        ac.enabled = true;
        ac.Play();
  
        
    }
    public void ZombieP()
    {
        ac.Stop();
    }
    public void Fire()
    {
        ac.PlayOneShot(fire);
    }
    
}
