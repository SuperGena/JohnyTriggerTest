using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{

    public Rigidbody rb;


    public float speed = 50f;

    private void Awake()
    { 
        rb = GetComponent<Rigidbody>();
        //aim = GameObject.FindGameObjectWithTag("BulletSpot");
    }

    void Start()
    {
        Destroy(gameObject, 2f);
            rb.AddForce(transform.up * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Destroy(gameObject);
            GameController.gameOver = true;
        }
    }
}
