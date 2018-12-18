using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    //Currencys
    public Text coinsCurrency;
    public Text batcoinsCurrency;
    public float coins;
    public float batcoins;

    //PowerUps

    public Text ResPowerUpsText;
    public float ResPowerUps;
    public Text TimePowerText;
    public float TimePower;

    //Skins Costs button text
    public Text skin1CoinsText;
    public Text skin1BatsText;
    public Text skin2CoinsText;
    public Text skin2BatsText;

    //Skins cost floats can be private
    public float skin1Coins = 5000;
    public float skin1Bats = 500;
    public float skin2Coins = 7500;
    public float skin2Bats = 750;

    //PurchaseButtons
    public Button skin1CoinButton;
    public Button skin1BatButton;
    public Button skin2CoinButton;
    public Button skin2BatButton;

    //PurchasePowerUps
    public Text ResCoinsText;
    public Text ResBatsText;
    public float ResCoins = 1000;
    public float ResBats = 50;
    public Text TimeCoinsText;
    public Text TimeBatsText;
    public float TimeCoins = 1000;
    public float TimeBats = 50;

    public Button ResCoinButton;
    public Button ResBatsButton;
    public Button TimeCoinButton;
    public Button TimeBatsButton;

    //SkinBoughtBools

    float Skin1Bought = 0;
    float Skin2Bought = 0;

    GameObject DatabaseManager;

    void Awake()
    {
        //Sets the button text values to the correct amount
        skin1CoinsText.text = skin1Coins + " Coins";
        skin1BatsText.text = skin1Bats + " BatCoins";
        skin2CoinsText.text = skin2Coins + " Coins";
        skin2BatsText.text = skin2Bats + " BatCoins";
        ResCoinsText.text = ResCoins + " Coins";
        ResBatsText.text = ResBats + " BatCoins";
        TimeCoinsText.text = TimeCoins + " Coins";
        TimeBatsText.text = TimeBats + " BatCoins";
    }

    private void Start()
    {
        DatabaseManager = GameObject.Find("DatabaseManager");

        Skin1Bought = DatabaseManager.GetComponent<Database>().skin1unlocked;
        Skin2Bought = DatabaseManager.GetComponent<Database>().skin2unlocked;
    }

    void Update()
    {
        coinsCurrency.text = "Coins: " + coins;
        batcoinsCurrency.text = "BatCoins: " + batcoins;
        ResPowerUpsText.text = "Resurrection Tokens: " + ResPowerUps;
        TimePowerText.text = "Time Tokens: " + TimePower;
        if (Skin1Bought == 1)
        {
            skin1CoinButton.interactable = false;
            skin1BatButton.interactable = false;
            skin1BatsText.text = "Purchased";
            skin1CoinsText.text = "Purchased";
        }
        if (Skin2Bought == 1)
        {
            skin2CoinButton.interactable = false;
            skin2BatButton.interactable = false;
            skin2BatsText.text = "Purchased";
            skin2CoinsText.text = "Purchased";
        }

    }

    public void PurchaseSkin1Coins()
    {
        if (coins < skin1Coins)
        {
            skin1CoinsText.text = "Insufficient Coins";
        }
        else
        {
            coins = coins - skin1Coins;
            Skin1Bought = 1;
        }

    }
    public void PurchaseSkin1Bat()
    {
        if (batcoins < skin1Bats)
        {
            skin1BatsText.text = "Insufficient BatCoins";
        }
        else
        {
            batcoins = batcoins - skin1Bats;
            Skin1Bought = 1;
            DatabaseManager.GetComponent<Database>().buySkin1();
        }
    }
    public void PurchaseSkin2Coins()
    {
        if (coins < skin2Coins)
        {
            skin2CoinsText.text = "Insufficient Coins";
        }
        else
        {
            coins = coins - skin2Coins;
            Skin2Bought = 1;
            DatabaseManager.GetComponent<Database>().buySkin2();
        }

    }
    public void PurchaseSkin2Bat()
    {
        if (batcoins < skin2Bats)
        {
            skin2BatsText.text = "Insufficient BatCoins";
        }
        else
        {
            batcoins = batcoins - skin2Bats;
            Skin2Bought = 1;
        }
    }


    public void PurchaseResCoins()
    {
        if (coins < ResCoins)
        {
            ResCoinsText.text = "Insufficient Coins";
        }
        else
        {
            coins = coins - ResCoins;
            ResCoinsText.text = "Purchased";
            ResPowerUps++;
           
        }
    }

    public void PurchaseResBats()
    {
        if (batcoins < ResBats)
        {
            ResBatsText.text = "Insufficient BatCoins";
        }
        else
        {
            batcoins = batcoins - ResBats;
            ResBatsText.text = "Purchased";
            ResPowerUps++;

        }
    }

    public void PurchaseTimeCoins()
    {
        if (coins < TimeCoins)
        {
            TimeCoinsText.text = "Insufficient Coins";
        }
        else
        {
            coins = coins - TimeCoins;
            TimeCoinsText.text = "Purchased";
            TimePower++;

        }
    }

    public void PurchaseTimeBats()
    {
        if (batcoins < ResBats)
        {
            TimeBatsText.text = "Insufficient BatCoins";
        }
        else
        {
            batcoins = batcoins - TimeBats;
            TimeBatsText.text = "Purchased";
            TimePower++;

        }
    }





    public void CurrencyPack1()
    {
        batcoins = batcoins + 500;
    }
    public void CurrencyPack2()
    {
        batcoins = batcoins + 2000;
    }
    public void CurrencyPack3()
    {
        batcoins = batcoins + 5000;
    }



}
