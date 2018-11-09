using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public float speed;
    public GameObject player;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerScript>().canShoot)
        {
            sr.color = Color.red;
        }
        else
        {
            sr.color = Color.grey;
        }
    }
}
