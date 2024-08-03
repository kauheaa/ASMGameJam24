using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager Instance { get; private set; }
	public int score { get; private set; }

	public TextMeshProUGUI scoreText;

	private void Start()
	{
		score = 0;
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void OnEnable()
	{
		// Ensure that this method is called when a new scene is loaded
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable()
	{
		// Unsubscribe to avoid memory leaks
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		// Initialize or update UI elements after the scene is loaded
		if (scoreText == null)
		{
			scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
			if (scoreText == null)
			{
				Debug.LogWarning("ScoreText UI element not found in the scene.");
			}
		}
		UpdateScoreText();
	}

	public void AddScore(int amount)
	{
		score += amount;
		UpdateScoreText();
	}

	public void ResetScore()
	{
		score = 0;
		UpdateScoreText();
	}

	private void UpdateScoreText()
	{
		if (scoreText != null)
		{
			scoreText.text = "" + score;
			Debug.Log("Score updated to: " + score);
		}
		else
		{
			Debug.LogWarning("scoreText is null in UpdateScoreText.");
		}
	}
}