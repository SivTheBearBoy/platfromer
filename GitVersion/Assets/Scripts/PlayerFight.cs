using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    public bool inRange = false;

    public float distance = 10;

    public Transform rangeChecker;
    public Transform player;
    public Transform orientation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (inRange)
            {
                Attack();
            }
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;

        transform.position = playerPos + playerDirection * distance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            inRange = false;
        }
    }

    void Attack()
    {
        Debug.Log("attacking");
    }

}