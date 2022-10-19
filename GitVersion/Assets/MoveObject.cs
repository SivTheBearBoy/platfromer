using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public Transform TargetA, TargetB;
    public float speed = 1.0f;

    public Vector3 TargetAPostion, TargetBPostion, TargetPosition, Position;
    public GameObject Player;

    public string playerTag = "Player";

    void Start()
    {
        TargetAPostion = TargetA.position;
        TargetBPostion = TargetB.position;
    }

    void FixedUpdate()
    {
        Position = transform.position;

        transform.position = Vector3.MoveTowards(Position, TargetPosition, speed * Time.deltaTime);

        if (Position == TargetBPostion)
        {
            TargetPosition = TargetAPostion;
        }
        else if (Position == TargetAPostion)
        {
            TargetPosition = TargetBPostion;
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.tag == playerTag)
        {
            Player.transform.parent = transform;
        }
    }
        private void OnTriggerExit(Collider other){
        if (other.tag == playerTag)
        {
            Player.transform.parent = transform;
        }
    }
}
