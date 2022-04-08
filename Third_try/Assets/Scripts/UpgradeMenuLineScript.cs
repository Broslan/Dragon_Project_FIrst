using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuLineScript : MonoBehaviour
{
    public const int circleAmmount = 6;
    [SerializeField] private Image[] images = new Image[circleAmmount];
    [SerializeField] private Sprite[] sprites = new Sprite[2];

    public void UpdateOrangeCircle(int UpgCount)
    {
        for (int i = 0; i < circleAmmount; i++)
        {
            if(i < UpgCount)
            {
                images[i].sprite = sprites[1];
                images[i].color = new Color32(255, 255, 255, 255);
            }
            else
            {
                images[i].sprite = sprites[0];
                images[i].color = new Color32(255, 255, 255, 255);
            }
        }
    }

    public void AddGreenCircle(int upgNumber)
    {
        upgNumber -= 1;
        images[upgNumber].sprite = sprites[1];
        images[upgNumber].color = new Color32(40, 255, 0, 255);    
    }

    public int CircleAmmount()
    {
        return circleAmmount;
    }
}
