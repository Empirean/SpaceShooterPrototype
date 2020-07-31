using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItems : MonoBehaviour
{
    public void btn_play()
    {
        SceneManager.LoadScene("Level_1");
        PlayerPrefs.SetInt(Utility.keyCurrentLevel, 1);
        PlayerPrefs.SetInt(Utility.keyRetryCount, 0);
        ResetPlayer();
    }

    public void btn_back()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void btn_continue()
    {
        
        
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        PlayerPrefs.SetFloat(Utility.keyPlayerHealth, player.GetPlayerHealth());
        PlayerPrefs.SetInt(Utility.keyTurretLevel, player.GetTurretLevel());
        PlayerPrefs.SetInt(Utility.keyMissleLevel, player.GetMissleLevel());
        PlayerPrefs.SetInt(Utility.keyOrbiterLevel, player.GetOrbiterLevel());
        PlayerPrefs.SetInt(Utility.keyCurrentLevel, PlayerPrefs.GetInt(Utility.keyCurrentLevel, 1) + 1);
        PlayerPrefs.SetInt(Utility.keyRetryCount, 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void btn_retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt(Utility.keyRetryCount, PlayerPrefs.GetInt(Utility.keyRetryCount,0) + 1);
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
