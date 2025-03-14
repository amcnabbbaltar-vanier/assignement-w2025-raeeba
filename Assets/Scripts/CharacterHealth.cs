using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public Slider healthBar;
    public CharacterHealth Instance;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            currentHealth = maxHealth;
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
            DontDestroyOnLoad(gameObject); // The DontDestroyOnLoad  will make sure the game manager stays active between scene loading.
        } else 
        {
            Destroy(gameObject);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.IncrementScore();
            GameManager.Instance.LoadNextScene();
        }
    }
}
