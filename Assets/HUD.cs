using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    int kills;
    public Text killsLabel;
    int lives;
    public Text livesLabel;
    int currency;
    public Text currencyLabel;

    public GameObject gameover;
    bool isGameover = false;

    void Start()
    {
        kills = 0;
        killsLabel.text = "0";
        lives = 10;
        livesLabel.text = "10";
        currency = 300;
        currencyLabel.text = "$300";
    }

    public void AddKill(int reward = 0)
    {
        if (isGameover)
            return;

        kills++;
        killsLabel.text = kills.ToString();
        ModifyCurrency(reward);
    }

    public void RemoveLife()
    {
        if (isGameover)
            return;

        lives--;
        livesLabel.text = lives.ToString();

        if (lives <= 0)
        {
            isGameover = true;
            gameover.SetActive(true);
        }
    }

    public int GetCurrency()
    {
        return currency;
    }

    public void ModifyCurrency(int change)
    {
        currency += change;
        currencyLabel.text = "$" + currency.ToString();
    }

    public void Reload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}