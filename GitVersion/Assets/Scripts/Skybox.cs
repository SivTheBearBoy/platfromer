using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox : MonoBehaviour
{

    public Material darkSky;
    public Material normalSky;


    [SerializeField] private Transform player;

    public GameObject Light;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = darkSky;
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            RenderSettings.skybox = normalSky;
            Light.SetActive(true);
        }
    }

}
