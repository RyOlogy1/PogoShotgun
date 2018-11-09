using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    float expandSpeed = 0f;
    public GameObject FinishText;
    public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        FinishText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Complete());
        }
    }

    IEnumerator Complete()
    {
        controller.GetComponent<GameController>().enabled = false;
        FinishText.SetActive(true);
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime *= Time.timeScale;
        yield return new WaitForSecondsRealtime(2f);
        Time.fixedDeltaTime /= Time.timeScale;
        Time.timeScale = 1f;
        FinishText.SetActive(false);
        controller.GetComponent<GameController>().enabled = true;
        SceneManager.LoadScene(0);
    }
}
