using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadBlock : MonoBehaviour
{
    // Start is called before the first frame update
    bool destroyed = false;
    bool processStarted = false;
    int count = 0;
    
    float vibrateVelocity = 5f;
    float change = 0.5f;

    private AudioSource destroySound;

    // Start is called before the first frame update;
    void Start()
    {
        destroySound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if(destroyed)
        {
            Vibrate();
            Expand();
            Fade();
        }
    }


    // Allows update to call destruction functions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gO = collision.gameObject;
        if (gO.tag == "Player")
        {
            destroySound.Play();

            Destroy(GetComponent<BoxCollider2D>());

            GameObject.Find("Player").GetComponent<PlayerScript>().canShoot = true;

            GetComponent<SpriteRenderer>().color = Color.red;

            destroyed = true;
        }
    }


    // Causes the block to vibrate
    private void Vibrate()
    {
        
        transform.position += new Vector3(vibrateVelocity, 0f, 0f) * Time.deltaTime;
        count++;
        if (count >= 3)
        {
            vibrateVelocity *= -1;
            count = 0;
        }
    }


    // Causes the block to expand slightly
    private void Expand()
    {
        
        transform.localScale += new Vector3(change, change, 0) * Time.deltaTime;
    }


    // Causes the block to fade away; destroys itself when it finishes its sound and is fully faded
    private void Fade()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a -= 4f * Time.deltaTime;
        GetComponent<SpriteRenderer>().color = tmp;
        if(tmp.a < 0 && !destroySound.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
