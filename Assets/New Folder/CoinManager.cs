using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    [SerializeField] private int coins;
    [SerializeField] private TMP_Text coinsText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    public int GetCoins()
    {
        return coins;
    }

    public void SetCoins(int value)
    {
        coins = value;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (coinsText != null)
            coinsText.text = coins.ToString();
    }
}