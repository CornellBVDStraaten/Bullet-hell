using Enemies;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    /* Wave */
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] private GameObject startWaveButton;
    [SerializeField] int wave = 1;
    [SerializeField] int scoreUntilNextWave = 5;
    private bool waveActive = true;
    private int currentWaveScore = 0;

    /* Score */
    [SerializeField] TextMeshProUGUI scoreText;
    private int score = 0;

    /* Getters */
    public bool IsWaveActive() => waveActive;
    public int GetWave() => wave;

    // Ensure Singleton Pattern
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        UpdateScoreText();
    }
    public void AddScore(int amount)
    {
        score += amount;
        currentWaveScore += amount;
        UpdateScoreText();

        if (currentWaveScore == scoreUntilNextWave) {
            EndCurrentWave();
        }
    }

    public void EndCurrentWave()
    {
        DeleteEnemies();

        waveActive = false;
        currentWaveScore = 0;
        scoreUntilNextWave += 5;

        if (startWaveButton != null)
            startWaveButton.SetActive(true);
    }

    public void DeleteEnemies()
    {
        BaseEnemy[] enemies = FindObjectsByType<BaseEnemy>(FindObjectsSortMode.None);
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);
        }
    }

    public void StartNextWave()
    {
        wave++;
        UpdateWaveText();
        
        waveActive = true;
        if (startWaveButton != null)
            startWaveButton.SetActive(false);
    }
    
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    
    void UpdateWaveText()
    {
        waveText.text = "Wave: " + wave.ToString();
    }
}
