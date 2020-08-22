using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItems : MonoBehaviour
{
    public void btn_play()
    {
        if (Utility.build_number != PlayerPrefs.GetInt(Utility.key_StoredBuild,0))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt(Utility.key_StoredBuild, Utility.build_number);
        }
        PlayerPrefs.SetInt(Utility.key_CurrentLevel, 1);
        PlayerPrefs.SetInt(Utility.key_RetryCount, 0);
        ResetPlayer();
        SceneManager.LoadScene("Level_1");
    }

    public void btn_back()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void btn_continue()
    {

        Upgradeable unit = GameObject.FindGameObjectWithTag("Player").GetComponent<Upgradeable>();
        PlayerPrefs.SetFloat(Utility.key_PlayerHealth, unit.GetPlayerHealth());
        PlayerPrefs.SetInt(Utility.key_MainGunlevel, unit.GetMainGunCurrentLevel());
        PlayerPrefs.SetInt(Utility.key_AuxillaryGunLevel, unit.GetAuxillaryGunCurrentLevel());
        PlayerPrefs.SetInt(Utility.key_Barragelevel, unit.GetBarrageCurrentLevel());
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
        PlayerPrefs.DeleteKey(Utility.key_MainGunlevel);
        PlayerPrefs.DeleteKey(Utility.key_AuxillaryGunLevel);
        PlayerPrefs.DeleteKey(Utility.key_Barragelevel);
        PlayerPrefs.Save();
    }
}
