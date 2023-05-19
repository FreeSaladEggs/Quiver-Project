using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]public float maxHealth = 100;
    public  float power = 10;
    [SerializeField]  int killScore = 200;

    public float currentHealth{get; set ;}
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(float value)
    {
        currentHealth += value;
        Debug.Log("current health " + currentHealth + "/" + maxHealth);

        //if (transform.CompareTag("Enemy"))
            transform.Find("Canvas").GetChild(1).GetComponent<Image>().fillAmount = currentHealth / maxHealth;
        /* if (currentHealth <= 0) {
             Die();
         }
        if (maxHealth <= 0)
        {
           Die();
        }*/
    }


    public void Die()
    {
        if (transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Destroy(this.gameObject);
        /*else if (transform.CompareTag("Enemy"))
        {
            LevelManager.instance.score += killScore;
            Destroy(gameObject);
            //Destroy Enemy
        }*/
    }


}
