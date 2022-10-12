 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

 public class EnemyTrol : MonoBehaviour
 {
 
    Animator anim;

     public Transform Player;
     public int MoveSpeed = 4;
     public int MaxDist = 40;
     public int MinDist = 0;
 
     void Start()
     {
        anim = GetComponent<Animator> ();
     }
 
     void Update()
     {
         transform.LookAt(Player);
 
            if (gameObject.transform.position.x > Player.position.x) {
                //als enemy rechts is.
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            } else {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
         if (Vector3.Distance(transform.position, Player.position) >= MinDist)
         {
 
             transform.position += transform.forward * MoveSpeed * Time.deltaTime;
 
 
 
             if (Vector3.Distance(transform.position, Player.position) <= MinDist + 1)
             {
                 anim.SetBool("Attacking", true);
             }
             else
             {
                anim.SetBool("Attacking", false);
             }
 
         }
     }
 }
