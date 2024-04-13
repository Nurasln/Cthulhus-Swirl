using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareSound : MonoBehaviour
{
    AudioManager audioManager;
    
    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() 
    {
        audioManager.PlaySFX(audioManager.death);
    }
}
