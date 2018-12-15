using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public Button PlayButton, OptionsButton, HSButton, OptionsBack, HighscoreBack, Store, StoreSkins, StorePowerUps, StoreCurrency;
    public GameObject MMenuContain, OptionsContain, HighscoreContain, StoreContain, StoreSkinsContain, StorePowerUpsContain, StoreCurrencyContain;

    // Use this for initialization
    void Start()
    {
        MMenuContain.SetActive(true); //Shows Main Menu as default
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(false);

    }

    public void OptionsClick()
    {
        MMenuContain.SetActive(false);
        OptionsContain.SetActive(true); //Shows Options Menu
        HighscoreContain.SetActive(false);
    }

    public void HSClick()
    {
        MMenuContain.SetActive(false);
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(true); //Shows Highscore Menu
    }

    public void BackClick()
    {
        MMenuContain.SetActive(true); //Shows Main Menu
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(false);
        StoreContain.SetActive(false);
    }

    public void StoreClick()
    {
        MMenuContain.SetActive(false);
        OptionsContain.SetActive(false);
        HighscoreContain.SetActive(false);
        StoreContain.SetActive(true);//Shows Store
        StoreSkinsContain.SetActive(false);
        StorePowerUpsContain.SetActive(false);
    }

    public void StorePowerUpsClick()
    {
        StoreSkinsContain.SetActive(false);
        StorePowerUpsContain.SetActive(true);//Show powerup store
        StoreCurrencyContain.SetActive(false);
    }

    public void StoreSkinsClick()
    {
        StoreSkinsContain.SetActive(true);//Show skin store
        StorePowerUpsContain.SetActive(false);
        StoreCurrencyContain.SetActive(false);
    }

    public void StoreCurrencyClick()
    {
        StoreSkinsContain.SetActive(false);
        StorePowerUpsContain.SetActive(false);
        StoreCurrencyContain.SetActive(true); //Show currency store
    }

    public void GotoNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GotoGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
