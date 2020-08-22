using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Unit))]
public class Upgradeable : MonoBehaviour
{
    [Header("Main Gun")]
    public int mainGunUpgradeCount;
    public List<GameObject> mainGunComponents;

    [Header("Auxillary Gun")]
    public int auxillaryGunUpgradeCount;
    public List<GameObject> auxillaryGunComponents;

    [Header("Barrage")]
    public int barrageUpgradeCount;
    public List<GameObject> barrageComponents;

    [Header("Heal")]
    public int healUpgradeCount;

    int mainGunCurrentUpgrade;
    int auxillaryGunCurrentUpgrade;
    int barrageCurrentUpgrade;

    Unit unit;
    bool isInitialized = false;


    private void Update()
    {
        if (!isInitialized) Initialize();
    }

    void Initialize()
    {

        for (int i = 0; i < PlayerPrefs.GetInt(Utility.key_MainGunlevel, 0); i++)
        {
            MainGunUpgrade();
        }

        for (int i = 0; i < PlayerPrefs.GetInt(Utility.key_AuxillaryGunLevel, 0); i++)
        {
            AuxillaryGunUpgrade();
        }

        for (int i = 0; i < PlayerPrefs.GetInt(Utility.key_Barragelevel, 0); i++)
        {
            BarrageUpgrade();
        }

        unit = GetComponent<Unit>();

        unit.SetHealth(PlayerPrefs.GetFloat(Utility.key_PlayerHealth, unit.maxHealth), unit.maxHealth);
        isInitialized = true;
    }

    public void Heal()
    {
        float healAmount = unit.maxHealth * .3f;
        unit.Heal(healAmount);
    }

    public void MainGunUpgrade()
    {

        if (mainGunCurrentUpgrade < mainGunUpgradeCount - 1)
        {
            for (int i = 0; i < mainGunUpgradeCount; i++)
            {
                mainGunComponents[i].SetActive(false);
            }

            mainGunComponents[++mainGunCurrentUpgrade].SetActive(true);
        }

    }

    public void AuxillaryGunUpgrade()
    {

        if (auxillaryGunCurrentUpgrade < auxillaryGunUpgradeCount - 1)
        {
            for (int i = 0; i < auxillaryGunUpgradeCount; i++)
            {
                auxillaryGunComponents[i].SetActive(false);
            }

            auxillaryGunComponents[++auxillaryGunCurrentUpgrade].SetActive(true);
        }

    }

    public void BarrageUpgrade()
    {

        if (barrageCurrentUpgrade < barrageUpgradeCount - 1)
        {
            for (int i = 0; i < barrageUpgradeCount; i++)
            {
                barrageComponents[i].SetActive(false);
            }

            barrageComponents[++barrageCurrentUpgrade].SetActive(true);
        }

    }

    public int GetCurrentFirepowerIndex()
    {
        return mainGunCurrentUpgrade + auxillaryGunCurrentUpgrade + barrageCurrentUpgrade;
    }

    public int GetMainGunCurrentLevel()
    {
        return mainGunCurrentUpgrade;
    }

    public int GetAuxillaryGunCurrentLevel()
    {
        return auxillaryGunCurrentUpgrade;
    }

    public int GetBarrageCurrentLevel()
    {
        return barrageCurrentUpgrade;
    }

    public float GetPlayerHealth()
    {
        return unit.currentHealth;
    }

}
