using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject grla;
    public GameObject me;
    public Transform Player;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, me.transform.position, .09f);
        transform.LookAt(Player);
        //The model was rotated when I got it, this is to counteract that.
        transform.Rotate(-90,0,0);
    }
}
