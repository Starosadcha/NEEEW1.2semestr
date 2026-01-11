using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlayerSave : MonoBehaviour
{
    private PlayerStats playerStats;
    [SerializeField] private TMP_Text messageText;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        if (messageText != null)
            messageText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }
    private void ShowMessage(string msg)
    {
        if (messageText != null)
            StartCoroutine(ShowMessageCoroutine(msg));
    }

    private IEnumerator ShowMessageCoroutine(string msg)
    {
        messageText.text = msg;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f); 
        messageText.gameObject.SetActive(false); 
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.position = new float[]
        {
            transform.position.x,
            transform.position.y,
           transform.position.z
        };
        data.health = playerStats.GetHealth();
        data.coins = CoinManager.Instance.GetCoins();
        SaveSystem.Save(data);
        ShowMessage("Game Saved!");

    }
    public void Load()
    {
        SaveData data = SaveSystem.Load();
        if (data == null)
        {
            return;

        }
        transform.position = new Vector3(
            data.position[0],
            data.position[1],
            data.position[2]
            );
        playerStats.SetHealth(data.health);
        CoinManager.Instance.SetCoins(data.coins);
        ShowMessage("Game Loaded!");
    }
}