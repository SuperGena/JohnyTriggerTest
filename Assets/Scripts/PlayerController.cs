using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public GameObject aimStick;

    public GameObject bullet;

    public Transform bulletSpot;

    public float bullSpeed;

    public bool shootSequence = false;

    public int bulletsCount;


    public Text bulletsCountText;

    public GameObject bullObj;

    public static Animator anim;

    public Rigidbody rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        shootSequence = false;

        bulletsCount = 5;
        bulletsCountText.text = bulletsCount.ToString();

    }

    public void OnJumpTrigger()
    {
        GetComponentInChildren<PlayerRunAnimation>().StopAnimate();

        bulletsCount = 5;

        bulletsCountText.text = bulletsCount.ToString();

        bullObj.SetActive(true);

        aimStick.SetActive(true);

        shootSequence = true;
    }

    public void OnStopJumpTrigger()
    {
        GetComponentInChildren<PlayerRunAnimation>().StartAnimate();

        shootSequence = false;

        bullObj.SetActive(false);

        aimStick.SetActive(false);

    }

    public void StartArmsAnimation1()
    {
        GetComponentInChildren<PlayerRunAnimation>().StartArms1();
    }

    public void StartArmsAnimation2()
    {
        GetComponentInChildren<PlayerRunAnimation>().StartArms2();
    }

    public void SetStage()
    {
        GameController.stage++;
    }


    public void GameOver()
    {
        GameController.gameOver = true;
    }


    public void Win()
    {
        GameController.win = true;
        FindObjectOfType<PlayerRunAnimation>().GetComponent<Animator>().enabled = false;
    }


    private void Update()
    {
        if(GameController.start && !GameController.gameOver)
        if (shootSequence)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (bulletsCount > 0)
                {
                    var bullet2 = Instantiate(bullet, bulletSpot.position, bulletSpot.rotation);
                    bulletsCount--;
                    bulletsCountText.text = bulletsCount.ToString();
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyBulletController>())
        {
            rb.velocity = other.GetComponent<Rigidbody>().velocity;
            FindObjectOfType< CameraController>().follow = false;
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponentInChildren<Animator>().enabled = false;
            FindObjectOfType<PlayerRunAnimation>().GetComponent<Animator>().enabled = false;
            aimStick.SetActive(false);
            GameOver();
        }
    }
}
