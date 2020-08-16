using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItems : MonoBehaviour
{
    public void btn_play()
    {
        SceneManager.LoadScene("Level_1");
        PlayerPrefs.SetInt(Utility.key_CurrentLevel, 1);
        PlayerPrefs.SetInt(Utility.key_RetryCount, 0);
        ResetPlayer();
    }

    public void btn_back()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void btn_continue()
    {
        
        
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        PlayerPrefs.SetFloat(Utility.key_PlayerHealth, player.GetPlayerHealth());
        PlayerPrefs.SetInt(Utility.key_TurretLevel, player.GetTurretLevel());
        PlayerPrefs.SetInt(Utility.key_MissleLevel, player.GetMissleLevel());
        PlayerPrefs.SetInt(Utility.key_OrbiterLevel, player.GetOrbiterLevel());
        PlayerPrefs.SetInt(Utility.key_CurrentLevel, PlayerPrefs.GetInt(Utility.key_CurrentLevel, 1) + 1);
        PlayerPrefs.SetInt(Utility.key_RetryCount, 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void btn_retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt(Utility.key_RetryCount, PlayerPrefs.GetInt(Utility.key_RetryCount,0) + 1);
        ResetPlayer();
    }

    void ResetPlayer()
    {
        PlayerPrefs.DeleteKey(Utility.key_PlayerHealth);
        PlayerPrefs.DeleteKey(Utility.key_TurretLevel);
        PlayerPrefs.DeleteKey(Utility.key_MissleLevel);
        PlayerPrefs.DeleteKey(Utility.key_OrbiterLevel);
        PlayerPrefs.Save();
    }
}
