using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Image HealthBarSprite;
    public float maxHealth = 100;
    public float Currenthealth = 100;
    public float Damage = 20;

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        Currenthealth = maxHealth;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Currenthealth > 0)
        {
            UpdateHealthBar();

        }
        else
        {
            player.transform.position = respawnPoint.transform.position;
            Currenthealth = maxHealth;
        }
        
    }

    public void UpdateHealthBar()
    {
        HealthBarSprite.fillAmount = Currenthealth / maxHealth;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            TakeDamage(Damage);
        }
    }
    public void TakeDamage(float HitDamage)
    {
        Currenthealth = Currenthealth - HitDamage;
    }
}
