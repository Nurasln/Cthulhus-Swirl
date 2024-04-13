using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSanity : MonoBehaviour
{
    [SerializeField] int playerSanity;
    [SerializeField] int finalScreenIndex;

    [SerializeField] int health;
    [SerializeField] int numberOfHearts;
    [SerializeField] float delay;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    AudioManager audioManager;

    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update() 
    {
        if(playerSanity <= 0)
        {
            SceneManager.LoadScene(finalScreenIndex);
        }

        if(health > numberOfHearts)
        {
            health = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }

            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            playerSanity--;
            health--;
            audioManager.PlaySFX(audioManager.enemySound);
            Debug.Log(playerSanity);
            Destroy(other.gameObject);
        }
    }
}