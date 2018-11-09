using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Camera cam;
    private Vector3 offset;
    private bool scrolling = false;

    private float[] yLevels =
    {
        0f,
        15f, 
        30f, 
        45f,
        60f
    };
    private int currentLevel = 0;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }


    // Update is called once per frame
    void LateUpdate()
    {

       
        Vector3 playerPos = cam.WorldToViewportPoint(player.transform.position);

        if (playerPos.y > 1.0f && !scrolling)
        {
            scrolling = true;
            StartCoroutine(ScrollUp());
        }

        if(playerPos.y < 0f && !scrolling)
        {
            scrolling = true;
            StartCoroutine(ScrollDown());
        }
    }


    // Scrolls the camera to the level above its current level
    IEnumerator ScrollUp()
    {
        currentLevel++;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.5f);
        while (cam.transform.position.y < yLevels[currentLevel])
        {
            cam.transform.position += new Vector3(0f, 1f, 0f);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        cam.transform.position = new Vector3(0f, yLevels[currentLevel], -10f);
        yield return new WaitForSecondsRealtime(0.5f);
        scrolling = false;
        player.GetComponent<PlayerScript>().canShoot = true;

        if(player.GetComponent<Rigidbody2D>().velocity.magnitude < 15f)
        {
            player.GetComponent<Rigidbody2D>().velocity = player.GetComponent<Rigidbody2D>().velocity.normalized * 15f;
        }
        Time.timeScale = 1f;
        
    }


    // Scrolls the camera to the level below its current level
    IEnumerator ScrollDown()
    {
        currentLevel--;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.4f);
        while (cam.transform.position.y > yLevels[currentLevel])
        {
            cam.transform.position -= new Vector3(0f, 1f, 0f);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        cam.transform.position = new Vector3(0f, yLevels[currentLevel], -10f);
        yield return new WaitForSecondsRealtime(0.4f);
        scrolling = false;
        player.GetComponent<PlayerScript>().canShoot = true;
        
        Time.timeScale = 1f;
        

    }


    // Resets the camera
    public void ResetCamera(int checkPoint)
    {
        cam.transform.position = new Vector3(0f, yLevels[checkPoint], -10f);
        currentLevel = checkPoint;
    }


}
