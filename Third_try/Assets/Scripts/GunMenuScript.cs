using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunMenuScript : MonoBehaviour
{
    private enum LineType { Dmg, AtkSpeed }
    const int lineAmmount = 2;
    [SerializeField] private int menuNumber = 0;
    [SerializeField] private Upgrade upgrade;
    [SerializeField] private UpgradeMenuLineScript[] lineUpg = new UpgradeMenuLineScript[lineAmmount];

    private int[] UpgCount = new int[lineAmmount];
    private int[] StartUpgCount = new int[lineAmmount];
    //private int[] UpgCost = new int[lineAmmount];
    private int[] TempUpgCost = new int[lineAmmount];
    private int[] сostPerUpg = new int[lineAmmount]; //dont change

    [SerializeField] private TextMeshProUGUI moneyText;

    void Start()
    {
        moneyText.text = upgrade.moneyAmmount.ToString();
        UpgCount[(int)LineType.Dmg] = upgrade.dmgUpgCount[menuNumber];
        UpgCount[(int)LineType.AtkSpeed] = upgrade.atkSpeedUpgCount[menuNumber];

        ResetTempCost();

        сostPerUpg[(int)LineType.Dmg] = upgrade.dmgUpgCostInPercent[menuNumber];
        сostPerUpg[(int)LineType.AtkSpeed] = upgrade.atkSpeedUpgCostInPercent[menuNumber];

        for (int lineType = 0; lineType < lineAmmount; lineType++)
        {
            StartUpgCount[lineType] = UpgCount[lineType];
            lineUpg[lineType].UpdateOrangeCircle(UpgCount[lineType]);
            //TempUpgCost[lineType] = UpgCost[lineType];
        }
        
    }

    public void UpgBtnPush(int lineType) //покупаю апгрейд на линиии Linetype
    {
        //Debug.Log("In Button Push#" + lineType);
        //Debug.Log(UpgCount[lineType] + " < " + lineUpg[lineType].CircleAmmount() + " && " + upgrade.moneyAmmount + " <= "+ TempUpgCost[lineType]);
        if (UpgCount[lineType] < lineUpg[lineType].CircleAmmount() && upgrade.moneyAmmount >= TempUpgCost[lineType])
        {
            //Debug.Log("In Button Push If");
            upgrade.TakeMoney(TempUpgCost[lineType]);
            lineUpg[lineType].AddGreenCircle(++UpgCount[lineType]);
            TempUpgCost[lineType] *= сostPerUpg[lineType];
            TempUpgCost[lineType] /= 100;
        }
        moneyText.text = upgrade.moneyAmmount.ToString(); 
    }

    public void ResetLines() //нужно будет вызывать
    {
        for (int lineType = 0; lineType < lineAmmount; lineType++)
        {
            UpgCount[lineType] = StartUpgCount[lineType];
            lineUpg[lineType].UpdateOrangeCircle(UpgCount[lineType]);
        }
        ResetTempCost();
        //moneyText.text = upgrade.moneyAmmount.ToString(); //лучше перенести в общее меню
    }

    public void ApplyLines()
    {
        for (int lineType = 0; lineType < lineAmmount; lineType++)
        {
            StartUpgCount[lineType] = UpgCount[lineType];
            lineUpg[lineType].UpdateOrangeCircle(UpgCount[lineType]);
        }
        ApplyUpgCount();
        //upgrade.ApplyMoney(); //here Temp
        ApplyTempCost();
    }

    #region Apply-Reset
    private void ApplyUpgCount()
    {
        upgrade.dmgUpgCount[menuNumber] = UpgCount[(int)LineType.Dmg];
        upgrade.atkSpeedUpgCount[menuNumber] = UpgCount[(int)LineType.AtkSpeed];
    }

    private void ResetTempCost()//нужно будет вызывать
    {
        TempUpgCost[(int)LineType.Dmg] = upgrade.dmgUpgCost[menuNumber];
        TempUpgCost[(int)LineType.AtkSpeed] = upgrade.atkSpeedUpgCost[menuNumber];
        //upgrade.ResetMoney(); //лучше перенести в общее меню
    }

    private void ApplyTempCost() //нужно будет вызывать
    {
        upgrade.dmgUpgCost[menuNumber] = TempUpgCost[(int)LineType.Dmg];
        upgrade.dmgUpgCost[menuNumber] = TempUpgCost[(int)LineType.AtkSpeed];
    }

    #endregion
}
