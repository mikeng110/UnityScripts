using System;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            GetPlayerInventory(other.gameObject).IncrementCoins();
            Destroy(transform.root.gameObject);
        }
    }

    private PlayerInventory GetPlayerInventory(GameObject obj)
    {
        PlayerInventory result = obj.GetComponent<PlayerInventory>();

        if (result == null)
        {
            throw new System.NullReferenceException("PlayerInventory Script, Missing From Player Prefab");
        }
        return result;
    }
}
