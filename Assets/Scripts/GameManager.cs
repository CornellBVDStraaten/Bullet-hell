using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
    
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
