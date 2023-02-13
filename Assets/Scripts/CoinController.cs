using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public int CoinScore = 0;

    [SerializeField]
    private Text Score;
    [SerializeField]
    private Text BestScore;

    private void Start()
    {
        UpdateText();
    }
    public void AddCoin(int count)
    {
        CoinScore += count;
        Score.text = CoinScore.ToString();
    }
    private void UpdateText()
    {
        BestScore.text = "Best Score: " + PlayerPrefs.GetInt("Score").ToString();
    }

    public void GoToMenu()
    {
        if (CoinScore > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", CoinScore);
        }
        UpdateText();
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Asteroid").Concat(GameObject.FindGameObjectsWithTag("Coin")).ToArray();
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }

}
