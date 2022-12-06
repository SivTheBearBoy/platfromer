using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour
{
    //Variable
    Animator anim;

    public GameObject player;

    public bool flip;

    public float speed;

    public int MaxDist = 40;
    public int MinDist = 1;
    public int MinAttackDist = 2;

    void Start()
    {
        //Animator een kortere naam geven
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //Checkt of de player buiten de maximale afstand is
        if (Vector3.Distance(transform.position, player.transform.position) <= MaxDist && (Vector3.Distance(transform.position, player.transform.position) >= MinDist))
        {
            Vector3 scale = transform.localScale;
            //Checkt welke kant de player is
            if (player.transform.position.x > transform.position.x)
            {
                //Als Naar Links
                scale.z = Mathf.Abs(scale.z) * -1 * (flip ? -1 : 1);
                transform.Translate(0, 0, speed * Time.deltaTime * -1);
                anim.SetBool("Walking", true);
            }
            else
            {
                //Als naar rechts
                scale.z = Mathf.Abs(scale.z) * (flip ? -1 : 1);
                transform.Translate(0, 0, speed * Time.deltaTime);
                anim.SetBool("Walking", true);
            }

            transform.localScale = scale;

            //Check 
            if (Vector3.Distance(transform.position, player.transform.position) <= MinAttackDist)
            {
                //Voor aanvallen
                anim.SetBool("InRange", true);
            }
            else
            {
                //Stoppen met aanvallen
                anim.SetBool("InRange", false);
            }
        }
    }
}