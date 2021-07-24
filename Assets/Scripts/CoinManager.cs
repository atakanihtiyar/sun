using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public delegate void ManipulateCoin(int coin);
    public static ManipulateCoin onEarnCoin;

    public static Text coinText;
    public static int coin;

    private void Start()
    {
        coinText = GetComponent<Text>();
    }

    public static void OnEarnScore(int coinToAdd)
    {
        onEarnCoin?.Invoke(coinToAdd);

        coin += coinToAdd;
        coinText.text = "" + coin;
    }
}
