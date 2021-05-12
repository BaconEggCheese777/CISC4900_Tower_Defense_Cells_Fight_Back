using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{

    public static PurchaseManager current;
    public static int playerMoney;
    private float timeOfPreviousBasicIncome;

    private void Awake()
    {
        current = this;
        playerMoney = 10000;
    }

    void Start()
    {   
        /*      These causes a NullReference error. Note to Calvin if you want to fix.
         *      
        GameEvents.current.onIncreaseMoney += (int money) => this.playerMoney += money;
        GameEvents.current.onDecreaseMoney += (int money) =>
        {
            this.playerMoney -= money;
        };

        this.timeOfPreviousBasicIncome = 0;
        */
    }

    void Update()
    {
        float incomeInterval = 1;
        if (Time.time - timeOfPreviousBasicIncome > incomeInterval)
        {
            timeOfPreviousBasicIncome = Time.time;
        }
    }

    public static bool tryBuy(int price)
    {
        if (playerMoney >= price)
        {
            playerMoney -= price;
            return true;
        }
        else
        {
            return false;
        }
    }
}
