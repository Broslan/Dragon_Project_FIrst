using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheWallScript : MonoBehaviour
{
    [SerializeField] private Upgrade infoUpgrade;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Slider slider;
    [SerializeField] private PauseScript pauseScript;
    public float health;
    public float maxHealth;
    
    private void Start()
    {
        health = maxHealth;
        slider.value = 1;
        TxtUpd();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        slider.value = (float)health/ (float)maxHealth;
        if (health <= 0)
        {
            pauseScript.OnDefeat();
        }
    }

    public void TxtUpd()
    {
        moneyText.text = infoUpgrade.moneyAmmount.ToString();
    }
}
