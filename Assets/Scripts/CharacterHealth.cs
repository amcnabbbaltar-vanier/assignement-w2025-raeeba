using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public Slider healthBar;
    public Vector3 startingPoint = new Vector3(0f, 1f, 0f);
    public CharacterHealth Instance;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // The DontDestroyOnLoad  will make sure the game manager stays active between scene loading.
        } else 
        {
            Destroy(gameObject);
        }

        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        if(transform.position.y < -10f)  // check if player has fallen off the level
        {
            FellOffLevel();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
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

    public void FellOffLevel()
    {
        transform.position = startingPoint; // reset player to their respawn point if they fell off the level
        Die();
        TakeDamage(1);
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
