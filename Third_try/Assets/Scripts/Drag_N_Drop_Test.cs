using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Drag_N_Drop_Test : MonoBehaviour
{
    private Camera cam;
    private Vector3 dragOffSet;
    [SerializeField] private GameObject abilityPrefab;
    [SerializeField] private float abilityCooldown;
    [SerializeField] private float abilityTimer;
    [SerializeField] private Slider sliderComponent;
    [SerializeField] private GameObject sliderObject;
    [SerializeField] private Upgrade upgradeinfo;
    [SerializeField] private TextMeshProUGUI ammountText;
    private Image image;
    private bool onCooldown = false;
    private bool isDepleted = false;
    [Space]
    [SerializeField] private int abilityNumber = 0; // номер способности
    


    private void Awake()
    {
        cam = Camera.main;
        image = GetComponent<Image>();
        ammountText.text = upgradeinfo.abilityItemAmmount[abilityNumber].ToString();
        IsDepleted();
    }

    private void FixedUpdate()
    {
        if (!isDepleted)  //проверяю стоит ли делать проверку на наличие кулдауна в зависимости от наличия способности
        {
            if (onCooldown) //проверка на кулдаун
            {
                if(abilityTimer > 0f) // отсчёт кулдауна
                {
                    abilityTimer -= Time.fixedDeltaTime;
                    sliderComponent.value = (abilityCooldown - abilityTimer) / abilityCooldown;
                }
                else
                {
                    AbilityReady();
                }
            }
        }

    }
    //функции для ивентов кликов
    public void OnMouseDown_my()
    {
        dragOffSet = transform.position - GetMousePosition();
    }

    public void OnMouseDrag_my()
    {
        transform.position = GetMousePosition() + dragOffSet;
    }
    public void OnMouseUp_my()
    {
        Instantiate(abilityPrefab, GetMousePositionToWorld(), Quaternion.identity);
        transform.position = transform.parent.position;
        AbilityUsed();
        upgradeinfo.abilityItemAmmount[abilityNumber]--;
        ammountText.text = upgradeinfo.abilityItemAmmount[abilityNumber].ToString();
        IsDepleted();
    }
    // ... 

    Vector3 GetMousePosition()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 0;
        return mousePos;
    }

    Vector3 GetMousePositionToWorld()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    void AbilityUsed() // использую когда использовал способность
    {
        abilityTimer = abilityCooldown;
        image.raycastTarget = false;
        onCooldown = true;
        image.color = new Color32(255, 255, 255, 155);
        sliderObject.SetActive(true);
    }

    void AbilityReady() // возращаю способность в кактивное состояние
    {
        image.raycastTarget = true;
        onCooldown = false;
        image.color = new Color32(255, 255, 255, 255);
        sliderObject.SetActive(false);
    }

    void IsDepleted() // проверка на наличие способности
    {
        if (upgradeinfo.abilityItemAmmount[abilityNumber] <= 0)
        {
            isDepleted = true;
            image.raycastTarget = false;
            image.color = new Color32(255, 255, 255, 155);
            sliderObject.SetActive(false);
        }
    }


}
