using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "UpgradeMem", order = 52)]
public class Upgrade : ScriptableObject
{
    private const int gunAmmount = 6;
    private const int abilityAmmount = 1;

    public int[] dmgUpgCount = new int[gunAmmount];
    [SerializeField] private float[] dmgPerUpg = new float[gunAmmount];
    public int[] dmgUpgCost = new int[gunAmmount];
    public int[] dmgUpgCostInPercent = new int[gunAmmount];
    //private int[] dmgUpgCostTemp = { 0, 0, 0, 0, 0, 0 }; // 0 ammount = gunAmmount
    [Space]
    public int[] atkSpeedUpgCount = new int[gunAmmount];
    [SerializeField] private float[] atkSpeedPerUpg = new float[gunAmmount];
    public int[] atkSpeedUpgCost = new int[gunAmmount];
    public int[] atkSpeedUpgCostInPercent = new int[gunAmmount];
    [Space]
    [SerializeField] private float[] baseAtkSpeed = new float[gunAmmount];
    [Space]
    public int[] abilityItemAmmount = new int[abilityAmmount];
    public int[] abilityCost = new int[abilityAmmount];
    public int[] maxAbility = new int[abilityAmmount];
    //[Space]
    //public int[,] upgCount = new int[gunAmmount, lineAmmount]; //make combined mass
    //private const int lineAmmount = 2;
    [Space]
    public int moneyAmmount = 1000;
    public int tempMoneyTaken = 0;

    #region Mod_Call
    public float DmgMod(int gunNumber)
    {
        if (dmgUpgCount[gunNumber] == 0)
        {
            return 1f;
        }
        else
        {
            return 1f + (float)(dmgUpgCount[gunNumber]) * dmgPerUpg[gunNumber];
        }
    }

    public float AtkSpeedMod(int gunNumber)
    {
        if (atkSpeedUpgCount[gunNumber] == 0)
        {
            return 1f;
        }
        else
        {
            return 1f + (float)(atkSpeedUpgCount[gunNumber]) * atkSpeedPerUpg[gunNumber];
        }
    }

    public float GetAtkSpeed(int gunNumber)
    {
        return baseAtkSpeed[gunNumber] / AtkSpeedMod(gunNumber);
    }
    #endregion
    public void TakeMoney(int moneyTakken)
    {
        moneyAmmount -= moneyTakken;
        tempMoneyTaken += moneyTakken;
    }

    public void ApplyMoney()
    {
        tempMoneyTaken = 0;
    }

    public void ResetMoney()
    {
        
        moneyAmmount += tempMoneyTaken;
        tempMoneyTaken = 0;
    }



    //public void BuyDmg(int gunNumber)
    //{
    //    if(moneyAmmount >= dmgUpgCost[gunNumber])
    //    {
    //        moneyAmmount -= dmgUpgCost[gunNumber];
    //        tempMoneyTaken += dmgUpgCost[gunNumber];

    //        dmgUpgCost[gunNumber] *= dmgUpgCostInPercent[gunNumber];
    //        dmgUpgCost[gunNumber] /= 100;
    //        dmgUpgCostTemp[gunNumber]++;

    //        dmgUpgCount[gunNumber]++;
    //    }
    //}
    //public void BuyAtkSpeed(int gunNumber)
    //{
    //    if (moneyAmmount >= atkSpeedUpgCost[gunNumber])
    //    {
    //        moneyAmmount -= atkSpeedUpgCost[gunNumber];
    //        atkSpeedUpgCost[gunNumber] *= atkSpeedUpgCostInPercent[gunNumber];
    //        atkSpeedUpgCost[gunNumber] /= 100;
    //        atkSpeedUpgCount[gunNumber]++;
    //    }
    //}

}
