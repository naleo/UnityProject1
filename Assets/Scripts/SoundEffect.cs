using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioClip playerHit;
    public AudioClip EnemyHit;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void playPlayerHit() {
        GetComponent<AudioSource>().clip = playerHit;
        GetComponent<AudioSource>().Play();
    }
    
    public void playEnemyHit() {
        GetComponent<AudioSource>().clip = EnemyHit;
        GetComponent<AudioSource>().Play();
    }
}
