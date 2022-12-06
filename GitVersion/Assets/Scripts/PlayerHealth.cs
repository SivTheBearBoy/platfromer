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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            TakeDamage(20);
        }
    }
    public void TakeDamage(float HitDamage)
    {
        Currenthealth = Currenthealth - HitDamage;
    }
}
