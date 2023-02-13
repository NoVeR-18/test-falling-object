using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : FallingObject
{
    [SerializeField]
    private AudioClip _coin;
    [SerializeField]
    private int _cost = 1;


    void Start()
    {
        _speed = 7;
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Player")
        {
            triggerCollider.GetComponent<CoinController>().AddCoin(_cost);
            //CoinController.CoinScore += _cost;
            Destroy(gameObject);
        }
    }
}
