using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityShop : MonoBehaviour
{
    const int abilityAmmount = 1;
    [SerializeField] private Upgrade upgrade;
    //[SerializeField] private int[] abilityCost;
    [SerializeField] private TextMeshProUGUI[] costText = new TextMeshProUGUI[abilityAmmount];
    [SerializeField] private TextMeshProUGUI[] ammountText = new TextMeshProUGUI[abilityAmmount];
    [SerializeField] private TextMeshProUGUI[] addAmmountText = new TextMeshProUGUI[abilityAmmount];
    private int[] tempAbilityAmmount = new int[abilityAmmount];
    [SerializeField] private TextMeshProUGUI moneyText;
    void Start()
    {
        for (int i = 0; i < costText.Length; i++)
        {
            costText[i].text = upgrade.abilityCost[i].ToString();
            ammountText[i].text = upgrade.abilityItemAmmount[i].ToString() + "/" + upgrade.maxAbility[i].ToString();
            addAmmountText[i].text = " "; 
        }
    }

    public void BuyBtnPush(int abilityNumber)
    {
        if (tempAbilityAmmount[abilityNumber] + upgrade.abilityItemAmmount[abilityNumber] < upgrade.maxAbility[abilityNumber] && upgrade.moneyAmmount >= upgrade.abilityCost[abilityNumber])
        {
            tempAbilityAmmount[abilityNumber]++;
            addAmmountText[abilityNumber].text = "+" + tempAbilityAmmount[abilityNumber].ToString();
            upgrade.TakeMoney(upgrade.abilityCost[abilityNumber]);
            moneyText.text = upgrade.moneyAmmount.ToString();
        }
    }

    public void ApplyPushare()
    {
        for (int i = 0; i < costText.Length; i++)
        {
            upgrade.abilityItemAmmount[i] += tempAbilityAmmount[i];
            ammountText[i].text = upgrade.abilityItemAmmount[i].ToString() + "/" + upgrade.maxAbility[i].ToString();
            tempAbilityAmmount[i] = 0;
            addAmmountText[i].text = " ";
        }
    }

    public void ResetPushare()
    {
        for (int i = 0; i < costText.Length; i++)
        {
            tempAbilityAmmount[i] = 0;
            addAmmountText[i].text = " ";
        }
    }
}
