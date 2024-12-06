using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthBar : MonoBehaviour
{
    public static float health;
    public float animSlow;
    private float maxHealt, trueScale;

    void Start()
    {
        health = 100;
        maxHealt = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //SceneManager.LoadScene(0);
        }
        trueScale = health / maxHealt;
        if (transform.localScale.x > trueScale)
        {
            transform.localScale = new Vector3(transform.localScale.x - (transform.localScale.x-trueScale) / animSlow, transform.localScale.y, transform.localScale.z);
        }
        if (transform.localScale.x < trueScale)
        {
            transform.localScale = new Vector3(transform.localScale.x + (trueScale - transform.localScale.x) / animSlow, transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetKeyDown("b")&& health>0) // can azaltma darbe alýnca
        {
            health -= 10;
        }
        if(Input.GetKeyDown("r")&& health< maxHealt) // can doldurma iðne filan yerse
        {
            health = maxHealt;
        }
    }
}
