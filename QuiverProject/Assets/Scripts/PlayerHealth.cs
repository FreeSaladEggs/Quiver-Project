using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;
    public Slider healthBar;
    public GameObject playerPrefab;
    public Transform respawnPoint;
    public float respawnDelay = 3f;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead)
            return;
        currentHealth -= damageAmount;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Debug.Log("motna");
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        Invoke("RestartScene", respawnDelay);
    }
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



