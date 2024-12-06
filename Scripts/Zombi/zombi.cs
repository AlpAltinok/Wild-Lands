using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombi : MonoBehaviour
{
   [SerializeField]
   private AudioSource ses;
    public AudioClip clip;
  //  AudioManagerGame ac;
    public Transform target;
    Animator zombiAnim;
    NavMeshAgent agent;
    public float distance;
    public float attackDistance;
   
    public static int zombieHp=100;
    public GameObject blood;
    
    void Start()
    {
     
        // ac = GameObject.Find("SoundManager").GetComponent<AudioManagerGame>();
        zombiAnim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
       // ses = GetComponent<AudioSource>();
        ses.clip = clip;
    }

   
    void Update()
    {
        zombiAnim.SetFloat("Speed", agent.velocity.magnitude);
        distance = Vector3.Distance(transform.position, target.position);

        if (distance <= 25)
        {
            //  ac.enabled = true;
            //   ac.Zombie();
            
            ses.PlayOneShot(clip);

           
        }
        if (distance <= 15 && distance>attackDistance && zombieHp> 0)
        {
            this.transform.LookAt(target.transform.position);
            agent.destination = target.position;
            agent.enabled = true;
            zombiAnim.SetBool("Attack", false);
           
           
        }
        else if(distance < attackDistance && zombieHp>0)
        {
            this.transform.LookAt(target.transform.position);
            zombiAnim.SetBool("Attack", true);
           
        }
        else
        {
         
            zombiAnim.SetBool("Attack", false);
            
        }
        if (zombieHp <= 0)
        {
            //  Debug.Log("OLDU");
            zombiAnim.SetTrigger("Dead");
            // ac.enabled = false;
            //    ac.ZombieP();
            ses.Stop();
        
          

            StartCoroutine(Kaybol());
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthBar.health -= 10;
          //  Debug.Log("zombi vurdu");
        }
        if (other.CompareTag("Bullet"))
        {
            //Debug.Log("vuruldu");
            blood.SetActive(true);
            zombieHp -= 25;
        }
       
    }
    private IEnumerator Kaybol()
    {

        yield return new WaitForSeconds(5f);
        Destroy(gameObject, 10f);
    }
  

}
