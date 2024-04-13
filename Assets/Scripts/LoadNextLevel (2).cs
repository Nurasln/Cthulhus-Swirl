using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    [SerializeField] int whichLevel;
    [SerializeField] float delay;
    private Animator anim;

    AudioManager audioManager;

    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    void Start() 
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            audioManager.PlaySFX(audioManager.checkpoint);
            anim.SetBool("isTouched", true);
            Invoke("NextScene", delay); 
        }
    } 

    void NextScene()
    {
        SceneManager.LoadScene(whichLevel);
    }
}
