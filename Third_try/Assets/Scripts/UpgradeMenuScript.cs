using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UpgradeMenuScript : MonoBehaviour
{
    private int activeMenu;
    const int gunAmmount = 5;
    [SerializeField] private Upgrade upgrade;
    [SerializeReference] private GunMenuScript[] gunMenuScripts = new GunMenuScript[gunAmmount];
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Button[] gunMenuButtons = new Button[gunAmmount];
    [SerializeField] private GameObject[] gunMenus = new GameObject[gunAmmount];
    [SerializeReference] private AbilityShop abilityShop;
    void Start()
    {
        activeMenu = 0;
        gunMenuButtons[activeMenu].interactable = false;
    }


    public void ResetButtonPushed()
    {
        for (int i = 0; i < 2/*gunAmmount*/; i++)
        {
            gunMenuScripts[i].ResetLines();
        }
        upgrade.ResetMoney();
        moneyText.text = upgrade.moneyAmmount.ToString();
        abilityShop.ResetPushare();
    }

    public void DoneButtonPushed()
    {
        for (int i = 0; i < 2/*gunAmmount*/; i++)
        {
            gunMenuScripts[i].ApplyLines();
        }
        upgrade.ApplyMoney();
        moneyText.text = upgrade.moneyAmmount.ToString();
        abilityShop.ApplyPushare();
    }

    public void MenuChanger(int menuNumber)
    {
        gunMenus[activeMenu].SetActive(false);
        gunMenuButtons[activeMenu].interactable = true;
        gunMenus[menuNumber].SetActive(true);
        gunMenuButtons[menuNumber].interactable = false;
        activeMenu = menuNumber;
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }
}
