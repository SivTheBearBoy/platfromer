using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Image HealthBarSprite;
    public float maxHealth = 100;
    public float Currenthealth = 100;
    

    // Start is called before the first frame update
    void Start()
    {
        HealthBarSprite = GetComponent<Image>();
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
}
