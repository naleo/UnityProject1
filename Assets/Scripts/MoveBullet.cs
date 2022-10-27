using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float bulletSpeed = 25f;
    private GameManager gm;
    public GameObject explosionParticleEffect;
    private SoundEffect se;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 20.0f;
        Destroy(gameObject, 4);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        se = GameObject.Find("SoundEffects").GetComponent<SoundEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += this.transform.forward * bulletSpeed * Time.deltaTime;
    }
    
    private void OnCollisionEnter(Collision other) {
        Debug.Log("Trigger");
        if (other.gameObject.CompareTag("Enemy")) {
            gm.updateScore(2);
            se.playEnemyHit();
            Instantiate(explosionParticleEffect, transform.position, explosionParticleEffect.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        // if (other.gameObject.CompareTag("Mine")) {
        //     Instantiate(explosionParticleEffect, transform.position, explosionParticleEffect.transform.rotation);
        //     Destroy(other.gameObject);
        //     Destroy(gameObject);
        // }
    }
}
