using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItems : MonoBehaviour
{
    public void btn_play()
    {
        SceneManager.LoadScene("Level_1");

        ResetPlayer();
    }

    public void btn_back()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void btn_continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        PlayerPrefs.SetFloat(Utility.keyPlayerHealth, player.GetPlayerHealth());
        PlayerPrefs.SetInt(Utility.keyTurretLevel, player.GetTurretLevel());
        PlayerPrefs.SetInt(Utility.keyMissleLevel, player.GetMissleLevel());
        PlayerPrefs.SetInt(Utility.keyOrbiterLevel, player.GetOrbiterLevel());
        PlayerPrefs.Save();

    }

    public void btn_retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResetPlayer();
    }

    void ResetPlayer()
    {
        PlayerPrefs.DeleteKey(Utility.keyPlayerHealth);
        PlayerPrefs.DeleteKey(Utility.keyTurretLevel);
        PlayerPrefs.DeleteKey(Utility.keyMissleLevel);
        PlayerPrefs.DeleteKey(Utility.keyOrbiterLevel);
        PlayerPrefs.Save();
    }
}
