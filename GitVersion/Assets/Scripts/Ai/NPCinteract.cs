using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCinteract : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            transform.GetChild(0).gameObject.SetActive(true);
            Player.GetComponent<PlayerMovement>().enabled=false;
        }
    }
}
