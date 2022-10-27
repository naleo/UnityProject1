using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    public GameObject bulletPrefab;
    public GameObject cameraCenter;
    private GameManager gm;
    public GameObject explosionParticleEffect;

    private SoundEffect se;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        se = GameObject.Find("SoundEffects").GetComponent<SoundEffect>();
    }

    // Update is called once per frame
    // 
    void Update()
    {
        if (gm.getPlayerHealth() > 0)
        {
            doPlayerMovement();
            doSpawnBullets();
        }
    }

    void doSpawnBullets()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 camLookDirection = Camera.main.transform.TransformVector(Vector3.forward);
            Vector3 bulletForward = new Vector3(camLookDirection.x, 0, camLookDirection.z).normalized;
            Quaternion rotation = Quaternion.LookRotation(bulletForward, Vector3.up);
            Instantiate(bulletPrefab, transform.position + bulletForward, rotation);
        }
    }
    void doPlayerMovement()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        Vector3 relativeMovement = Camera.main.transform.TransformVector(movement);

        rb.AddForce(relativeMovement * speed);

    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.CompareTag("Enemy"))
        {
            gm.updateScore(2);
            Instantiate(explosionParticleEffect, transform.position, explosionParticleEffect.transform.rotation);
            Destroy(other.gameObject);
            se.playPlayerHit();
            gm.updateHealth(-5);
        }
        if (other.gameObject.CompareTag("Mine"))
        {
            Instantiate(explosionParticleEffect, transform.position, explosionParticleEffect.transform.rotation);
            Destroy(other.gameObject);
            se.playPlayerHit();
            gm.updateHealth(-5);
        }
    }
}
