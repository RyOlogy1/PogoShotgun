using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController1 : MonoBehaviour
{
    public GameObject player;
    Vector3 playerStartPos = new Vector3(0f, -2.4f, 0f);
    Vector3 finishPos = new Vector3(0f, 64f, 0f);

    public GameObject reloads;
    Vector3[] reloadLocations = new Vector3[]
    {
        new Vector3(0f, 3.5f, 0f),
        new Vector3(2.5f, -2.4f, 0f)
    };
    Vector3[] respawnLocations = new Vector3[]
    {

    };

    public GameObject cam;

    public GameObject menu;

    private bool showingMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ResetLvl", 0.1f);
        menu.SetActive(showingMenu);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R)) ResetLvl();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            AltPause();
        }
    }

    public void AltPause()
    {
        showingMenu = !showingMenu;
        menu.SetActive(showingMenu);
        player.GetComponent<PlayerScript>().enabled = !player.GetComponent<PlayerScript>().enabled;
        cam.GetComponent<CameraController>().enabled = !cam.GetComponent<CameraController>().enabled;
        if (showingMenu) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }


    //full reset level code
    private void ResetLvl()
    {
        ResetPlayer();
        ResetReloadBoxes();
        ResetCamera();
    }


    //places player at checkpoint
    private void ResetPlayer()
    {
        player.transform.position = playerStartPos;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        player.GetComponent<PlayerScript>().canShoot = true;
    }


    //replaces reload boxes
    private void ResetReloadBoxes()
    {
        GameObject[] existing = GameObject.FindGameObjectsWithTag("ReloadBoxes");
        foreach (GameObject box in existing)
        {
            Destroy(box);
        }
        foreach (Vector3 rl in reloadLocations)
        {
            Instantiate(reloads, rl, Quaternion.identity);
        }
    }


    private void ResetCamera()
    {
        cam.GetComponent<CameraController>().ResetCamera(0);
    }

}
