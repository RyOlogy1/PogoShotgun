using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public void SwitchToGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SwitchToTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void GetOuttaHere()
    {
        Application.Quit();
    }

    public void SwitchToMenu()
    {
        GameObject.Find("GameController").GetComponent<GameController>().AltPause();
        SceneManager.LoadScene(0);
    }
}
