using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int coins;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
    }

    public void IncrementCoins()
    {
        coins++;
        Debug.Log($"Nr of coins {coins}");
    }
}
