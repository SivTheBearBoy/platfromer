 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

 public class EnemyTrol : MonoBehaviour
 {
    //Variable
    Animator anim;
    Collider m_Collider;

    public GameObject player;

    public bool flip;
    public float damage = 5;
    public float maxHealth = 100;
    public float Currenthealth = 100;

    public float speed;

    public int MaxDist = 40;
    public int MinDist = 1;
    public int MinAttackDist = 2;

     void Start()
     {
        //Animator een kortere naam geven
        anim = GetComponent<Animator> ();
        m_Collider = GetComponent<Collider>();
        Currenthealth = maxHealth;
     }
    void Update()
    {
        //Checkt of de player buiten de maximale afstand is
        if (Currenthealth >= 1)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= MaxDist && (Vector3.Distance(transform.position, player.transform.position) >= MinDist))
            {
                Vector3 scale = transform.localScale;
                //Checkt welke kant de player is
                if(player.transform.position.x > transform.position.x)
                {
                    //Als Naar Links
                    scale.z = Mathf.Abs(scale.z) * -1 * (flip ? -1 : 1);
                    transform.Translate(0, 0 , speed * Time.deltaTime * -1);
                } else {
                    //Als naar rechts
                    scale.z = Mathf.Abs(scale.z) * (flip ? -1 : 1);
                    transform.Translate(0, 0 , speed * Time.deltaTime);
                }

                transform.localScale = scale;

                //Check 
                if (Vector3.Distance(transform.position, player.transform.position) <= MinAttackDist)
                {
                    //Voor aanvallen
                    anim.SetBool("Attacking", true);
                }
                else
                {
                    //Stoppen met aanvallen
                    anim.SetBool("Attacking", false);
                }
            }
        }
        else
        {
            anim.SetTrigger("Die");
            m_Collider.enabled = false;
        }
    }
    // void OnTriggerStay(Collider other) 
    // {
    //     if(other.CompareTag("player")) 
    //     {
    //         TakeDamage(3);
    //     }
    // }
    // public void TakeDamage (Damage)
    // {
    //     Currenthealth = Currenthealth - Damage;
    // }
}
