using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject player;
    Vector3 playerStartPos = new Vector3(0f, -2.4f, 0f);
    Vector3 finishPos = new Vector3(0f, 64f, 0f);

    public GameObject reloads;
    Vector3[] reloadLocations;
    Vector3[] respawnLocations = new Vector3[]
    {

    };

    public GameObject cam;

    public GameObject menu;

    private bool showingMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1") reloadLocations = new Vector3[]
        {
            new Vector3(0f, 3.5f, 0f),
            new Vector3(1.73f, -2.46f, 0f),
            new Vector3(-9.17f, 6.45f, 0f),
            new Vector3(-8.45f, 11.58f, 0f),
            new Vector3(-3.71f, 14.47f, 0f),
            new Vector3(-0.370f, 26.853f, 0f),
            new Vector3(-0.74f, 21.34f, 0f),
            new Vector3(-2.96f, 8.99f, 0f),
            new Vector3(4f, 28f, 0f),
            new Vector3(5f, 28f, 0f),
            new Vector3(11f, 23f, 0f),
            new Vector3(10.14f, 25.73f, 0f),
            new Vector3(8f, 25f, 0f),
            new Vector3(8f, 26f, 0f),
            new Vector3(8f, 27f, 0f),
            new Vector3(8f, 28f, 0f),
            new Vector3(8f, 29f, 0f),
            new Vector3(8f, 30f, 0f),
            new Vector3(8f, 31f, 0f),
            new Vector3(8f, 32f, 0f),
            new Vector3(8f, 33f, 0f),
            new Vector3(8f, 34f, 0f),
            new Vector3(8f, 35f, 0f),
            new Vector3(8f, 36f, 0f),
            new Vector3(8f, 37f, 0f),
            new Vector3(12f, 33f, 0f),
            new Vector3(2f, 36f, 0f),
            new Vector3(3f, 36f, 0f),
            new Vector3(4f, 36f, 0f),
            new Vector3(-7f, 30.5f, 0f),
            new Vector3(-8f, 30.5f, 0f),
            new Vector3(-9f, 30.5f, 0f),
            new Vector3(-10f, 30.5f, 0f),
            new Vector3(-11f, 30.5f, 0f),
            new Vector3(-12f, 30f, 0f),
            new Vector3(-12f, 31f, 0f),
            new Vector3(-12f, 32f, 0f),
            new Vector3(-12f, 33f, 0f),
            new Vector3(-12f, 34f, 0f),
            new Vector3(-12f, 35f, 0f),
            new Vector3(-12f, 36f, 0f),
            new Vector3(-12f, 37f, 0f),
            new Vector3(-12f, 38f, 0f),
            new Vector3(-12f, 39f, 0f),
            new Vector3(-12f, 40f, 0f),
            new Vector3(-12f, 41f, 0f),
            new Vector3(0f, 40f, 0f),
            new Vector3(0f, 46f, 0f),
            new Vector3(0f, 52f, 0f),
            new Vector3(0f, 58f, 0f)
        };
        else reloadLocations = new Vector3[]
        {
            new Vector3(0f, 3.5f, 0f),
            new Vector3(2.5f, -2.4f, 0f)
        };

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
