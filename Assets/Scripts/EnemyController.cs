using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    private GameObject player;
    private Rigidbody rb;
    
    public GameObject minePrefab;
    
    private float secondsSinceMine;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        secondsSinceMine = Random.Range(0,4);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce(lookDirection * speed);
        secondsSinceMine += Time.deltaTime;
        if (secondsSinceMine > 8) {
            Vector3 minePosition = new Vector3(transform.position.x, 0.0f, transform.position.z);
            Instantiate(minePrefab, minePosition, minePrefab.transform.rotation);
            secondsSinceMine = 0;
        }
    }
}
