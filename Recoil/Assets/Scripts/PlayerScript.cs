using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /*PLAYER DATA*/
    private bool isDead = false;
    private Rigidbody2D rb2d;

    /*GUN DATA*/
    private float recoil = 22f;
    private float fireCD = 0f;
    private float bulletSpeed = 70f;
    private int sprayNum = 7;
    private float spraySize = 1f;
    public bool canShoot = true;

    /*PREFABS*/
    public GameObject playerBullet;

    /*AUDIO*/
    private AudioSource shotSound;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        shotSound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        UpdateAim();


        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Fire();
        }
    }
    

    //Full function for the player shooting
    void Fire()
    {
        shotSound.Play();
        canShoot = false;
        SpawnBullets();
        PushAway();
    }



    //Pushes the player in the opposite direction of the mosue
    void PushAway()
    {
        Vector2 dir = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = dir.normalized;
            
        rb2d.velocity = dir * recoil;
        //Debug.Log("Magnitude: " + dir.magnitude);
    }


    //Creates bullets that travel away from the player
    void SpawnBullets()
    {
        

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dir = dir.normalized;


        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        for(int i = 0; i < sprayNum; i++)
        {
            GameObject bullet = Instantiate(playerBullet, transform.position, Quaternion.identity) as GameObject;
            Rigidbody2D bulletRB2D = bullet.GetComponent<Rigidbody2D>();

            float trueAngle = angle + (sprayNum / 2 - i) * spraySize;

            bullet.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, trueAngle));
            bulletRB2D.velocity = Vector2FromAngle(180 + trueAngle) * bulletSpeed;

            Object.Destroy(bullet, 0.15f);
        }
        

        
    }


    //Turns the player towards the mouse
    void UpdateAim()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }


    //Creates a vector from a rotation
    public Vector2 Vector2FromAngle(float a)
    {
        a *= Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }


    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
