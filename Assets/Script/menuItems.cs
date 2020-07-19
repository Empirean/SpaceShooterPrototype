using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItems : MonoBehaviour
{
    public void btn_play()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void btn_back()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void btn_continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void btn_retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
