using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int gameScore = 0;
    private int userHealth = 60;

    private TextMeshProUGUI gameScoreText;
    private TextMeshProUGUI playerHealthText;
    // Start is called before the first frame update
    void Start()
    {
        //populate references
        gameScoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        playerHealthText = GameObject.Find("Health Text").GetComponent<TextMeshProUGUI>();
        updateScore(0);
        updateHealth(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateScore(int s)
    {
        gameScore += s;
        gameScoreText.text = "Score: " + gameScore;
        Debug.Log("Score UPDATED");
    }
    public void updateHealth(int h)
    {
        userHealth += h;
        playerHealthText.text = "Health: " + userHealth;
    }
    
    public int getPlayerHealth() {
        return userHealth;
    }
}
