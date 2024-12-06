using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class CharacterController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public static  bool DiyalogPanel;
    public GameObject panel1, panel2, panel3, panel4,panel5;
    Animator anim;
    bool isRunning;
    public static int para;
    public Text paratext;
    private float distance;  
    private Transform target;
    private float detectionRadius = 15f;

    public  GameObject ak;
    public static GameObject aK;
    private Collider[] detectedEnemies;
    public LayerMask enemyLayer;
    public static bool Fire;
    public GameObject muzzel;
   // AudioManagerGame ac;

    public float rotationSpeed = 5f;
 
   AudioSource AkFire;
   public AudioClip akSes;

    private void Start()
    {
     //   ac = GameObject.Find("SoundManager").GetComponent<AudioManagerGame>();
        aK = ak;
        AkFire = GetComponent<AudioSource>();
        AkFire.clip = akSes;
        para = 700;
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
       
    }
    
    private void Update()
    {
        
        PointWorld();
        StopToCharacter();
        UpdateAnimator();
        paratext.text = para.ToString();
        detectedEnemies = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

      //  distance = Vector3.Distance(transform.position, target.position);
        foreach (Collider enemy in detectedEnemies)
        {
             distance = Vector3.Distance(transform.position, enemy.transform.position);
            // Debug.Log("D��man ile Mesafe: " + distance);
            if (distance <= 15 && isRunning == false && Zombi.zombieHp >0 ) 
            {
               /* this.transform.LookAt(enemy.transform.position);
                transform.Rotate(Vector3.up, 30f);
                anim.SetBool("Fire", true);
                Fire = true;
                muzzel.SetActive(true);
                ac.Fire();*/
                GameObject closestEnemy = FindClosestEnemy();

                if (closestEnemy != null)
                {
                    // Karakterin d��man hedefine do�ru yumu�ak bir �ekilde d�nmesi
                    RotateTowards(enemy.transform.position);
                    anim.SetBool("Fire", true);
                    Fire = true;
                    muzzel.SetActive(true);
                    //ac.Fire();
                    AkFire.enabled = true;
                    AkFire.PlayOneShot(akSes);
                  
                    // Ate� etme fonksiyonunu �a��rabilirsiniz

                }



            }
            else
            {
              
                anim.SetBool("Fire", false);
                muzzel.SetActive(false);
                Fire = false;
                AkFire.enabled = false;
                AkFire.Stop();

            }
        }
       

        if (HealthBar.health <= 0)
        {
            anim.SetBool("Death", true);
        }
    }
    private void PointWorld()
    {
        if (Input.GetMouseButtonDown(0) && DiyalogPanel==false ) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // T�klanan noktada bir hedef belirlenir
                Vector3 targetPosition = hit.point;
                navMeshAgent.SetDestination(hit.point);

                // Karakterin t�klanan y�ne d�nmesi
                Vector3 lookPos = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
                transform.LookAt(lookPos);
                 isRunning = true;

                // Hareket
                MoveToTarget(targetPosition);
            }

           

        }
    }

    private void MoveToTarget(Vector3 targetPosition)
    {
        // Karakteri t�klanan hedefe do�ru hareket ettirin
        navMeshAgent.SetDestination(targetPosition);
      //  isRunning = true;
        
    }
    private void StopToCharacter()
    {
        if (isRunning && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            isRunning = false;
         

        }
    }
    void UpdateAnimator()
    {
        Vector3 velocity = navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        anim.SetFloat("Forward", localVelocity.z, 0.15f, Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Quester") && EnvanterController.masude==false)
        {
            Debug.Log("Quester Aktif");
            panel1.SetActive(true);
            DiyalogPanel = true;
        }
        else if (other.CompareTag("Doktor") && EnvanterController.masude==false)
        {
            panel2.SetActive(true);
            DiyalogPanel = true;
        }
        else if (EnvanterController.masude == true && other.CompareTag("Doktor"))
        {
            panel3.SetActive(true);
            DiyalogPanel = true;
        }
        else if(EnvanterController.masude==true && other.CompareTag("Quester"))
        {
            panel4.SetActive(true);
            DiyalogPanel = true;
        }
        else if(EnvanterController.masude==true && other.CompareTag("Mahsur"))
        {
            panel5.SetActive(true);
            DiyalogPanel = true;
        }
       
    }
    
   public void panelkapat()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);
        DiyalogPanel = false;
    }
    GameObject FindClosestEnemy()
    {
        // D��man hedefini belirleyen bir fonksiyon
        // Bu �rnekte, d��man objelerinin bir listesini al�p en yak�n d��man� buluyoruz
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Zombi");

        if (enemies.Length > 0)
        {
            GameObject closestEnemy = enemies[0];
            float closestDistance = Vector3.Distance(transform.position, closestEnemy.transform.position);

            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestEnemy = enemy;
                    closestDistance = distance;
                }
            }

            return closestEnemy;
        }

        return null;
    }
    void RotateTowards(Vector3 targetPosition)
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
