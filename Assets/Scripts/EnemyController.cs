using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool alive = true;

    public static Animator anim;

    public Transform objToFollow;

    public Transform bulletSpot;

    public GameObject bullet;

    public GameObject weapon;
    public GameObject neck;


    public Quaternion weaponStart;
    public Quaternion neckStartPos;
    public Quaternion RHandStart;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        neckStartPos = neck.transform.rotation;
        weaponStart = weapon.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletController>())
        {
            if (gameObject.CompareTag("Enemy" + GameController.stage))
            {
                gameObject.GetComponent<Animator>().SetBool("dead", true);
                alive = false;
                Destroy(gameObject, 0.5f);
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 2), ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerController>())
        {
            if(gameObject.CompareTag("Enemy" + GameController.stage))
                Invoke("CheckLife", 0.7f);
        }
    }
    
    private void CheckLife()
    {
        if (alive)
        {
           // GameController.gameOver = true;
            ShootToPlayer();
        }
    }


    void ShootToPlayer()
    {
        GameObject bullet2 = Instantiate(bullet, bulletSpot.position, bulletSpot.rotation);
        //bullet.GetComponent<EnemyBulletController>().aim = objToFollow.gameObject;

    }


    private void Update()
    {
        if(GameController.stage > 0)
            if (this.CompareTag("Enemy" + GameController.stage))
            {
                Quaternion neckStartPosRotation = neck.transform.rotation;

                Vector3 direction = objToFollow.transform.position - weapon.transform.position;
                var targetRotation = Quaternion.LookRotation(direction);
                var lookAt = Quaternion.RotateTowards(weapon.transform.rotation, new Quaternion(targetRotation.x, weaponStart.y, weaponStart.z, weaponStart.w), Time.deltaTime * 100f);
                if(lookAt.x >= -90 && lookAt.x <= 70)
                    weapon.transform.rotation = lookAt;

                Quaternion lookAt_Arms;
                //weapon.transform.rotation = new Quaternion(lookAt.x, weaponStart.y, weaponStart.z, weaponStart.w); 

                if (transform.rotation.y > 0f)
                    lookAt_Arms = Quaternion.RotateTowards(neck.transform.rotation, new Quaternion(neckStartPos.x, neckStartPos.y, neckStartPos.z + lookAt.z, neckStartPos.w), Time.deltaTime * 1000f);
                else
                    lookAt_Arms = Quaternion.RotateTowards(neck.transform.rotation, new Quaternion(neckStartPos.x + lookAt.z, neckStartPos.y, neckStartPos.z, neckStartPos.w), Time.deltaTime * 1000f);
                neck.transform.rotation = lookAt_Arms;

                //RotateTowards(neck.transform, weapon.transform.position);

                //neck.transform.rotation = Quaternion.Euler(neckStartPos.x, neckStartPos.y, neckStartPos.z + lookAt.z * 2);

                //rArm.transform.rotation = new Quaternion(0f, 0f, RHandStart.z - weapon.transform.rotation.z, 1f);
                //lArm.transform.rotation = new Quaternion(0f, 0f, LHandStart.z + weapon.transform.rotation.z, 1f);
            }
    }


    private void RotateTowards(Transform objToRotate, Vector2 target)
    {
        var offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        objToRotate.rotation = Quaternion.Euler(Vector3.forward * (angle));
    }

}
