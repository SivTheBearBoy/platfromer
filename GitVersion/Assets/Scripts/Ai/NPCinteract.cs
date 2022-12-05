using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCinteract : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            transform.GetChild(0).gameObject.SetActive(true);
            this.GetComponent<BoxCollider>().enabled=false;
        }
    }
}
