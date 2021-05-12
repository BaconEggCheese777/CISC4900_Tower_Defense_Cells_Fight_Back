using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySell_Button : MonoBehaviour
{
    private int upgradeCost1 = 1000;
    private int upgradeCost2 = 2000;
    private int upgradeCost3 = 4000;

    public GameObject moneysign;
    public GameObject turret1;
    public GameObject turret2;
    public GameObject turret3;
    public GameObject turret4;
    public GameObject turret5;
    public GameObject insufficientFundsText;

    public GameObject boneWithSpots;
    public int turretSpotCount = 1;

    private Transform mouseXY;

    private void Awake()
    {
        insufficientFundsText = GameObject.Find("NoMoneyText");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnSellPreview()
    {
        Instantiate(moneysign, Input.mousePosition, transform.rotation);
    }

    public void spawnTurretPreview1()
    {
        Instantiate(turret1, Input.mousePosition, transform.rotation);
        transform.parent.gameObject.SetActive(false);
    }

    public void spawnTurretPreview2()
    {
        Instantiate(turret2, Input.mousePosition, transform.rotation);
        transform.parent.gameObject.SetActive(false);
    }

    public void spawnTurretPreview3()
    {
        Instantiate(turret3, Input.mousePosition, transform.rotation);
        transform.parent.gameObject.SetActive(false);
    }

    public void spawnTurretPreview4()
    {
        Instantiate(turret4, Input.mousePosition, transform.rotation);
        transform.parent.gameObject.SetActive(false);
    }

    public void spawnTurretPreview5()
    {
        Instantiate(turret5, Input.mousePosition, transform.rotation);
        transform.parent.gameObject.SetActive(false);
    }

    public void buyTurretSpot()
    {   
        switch(turretSpotCount)     // based on how many turret spots the player has already
        {
            case 1:
                if (PurchaseManager.tryBuy(upgradeCost1))
                {
                    boneWithSpots.transform.GetChild(2).gameObject.SetActive(true);
                    turretSpotCount++;
                }
                else
                {
                    StartCoroutine(flashInsufficientFundsText());
                }
                break;
            case 2:
                if (PurchaseManager.tryBuy(upgradeCost2))
                {
                    boneWithSpots.transform.GetChild(1).gameObject.SetActive(true);
                    turretSpotCount++;
                }
                else
                {
                    StartCoroutine(flashInsufficientFundsText());
                }
                break;
            case 3:
                if (PurchaseManager.tryBuy(upgradeCost3))
                {
                    boneWithSpots.transform.GetChild(0).gameObject.SetActive(true);
                    turretSpotCount++;
                }
                else
                {
                    StartCoroutine(flashInsufficientFundsText());
                }
                break;
        }
        
    }

    IEnumerator flashInsufficientFundsText()
    {
        Debug.Log("Trying");
        insufficientFundsText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(2);
        insufficientFundsText.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
        // I chose this method of displaying the text because non-instanced prefabs cannot 
        // reference any instanced GameObjects. Otherwise, I would've used gameObject.setActive()
    }
}
