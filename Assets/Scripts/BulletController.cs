using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public Rigidbody rb;

    public GameObject aim;

    public float speed = 50f;

    private void Awake()
    { 
        rb = GetComponent<Rigidbody>();
        //aim = GameObject.FindGameObjectWithTag("BulletSpot");
        aim = GameObject.FindGameObjectWithTag("Respawn");
    }

    void Start()
    {        
        aim = GameObject.FindGameObjectWithTag("Respawn");
        Destroy(gameObject, 2f);
        if (aim == null)
            Debug.LogError("Aim object not found");
        else
            //rb.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode.Impulse);
            rb.AddForce(aim.transform.up * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<EnemyController>())
            Destroy(gameObject);
    }
}
