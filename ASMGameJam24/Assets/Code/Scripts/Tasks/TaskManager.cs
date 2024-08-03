using UnityEngine;
using TMPro; // Required for using TextMeshProUGUI component
using UnityEngine.SceneManagement; // Required for scene management

public class TaskManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI taskText; // Reference to the TextMeshProUGUI component
	[SerializeField] private string[] tasks; // Array of task strings
	[SerializeField] private GameObject[] taskObjects; // Array of task objects
	[SerializeField] private Animator uiAnimator; // Reference to the UI Animator component
	public SpawnManager spawnManager;
	public int anomaliesDetected = 0;
	public int anomaliesClicked = 0;

	private int currentTaskIndex = 0; // Index to keep track of the current task
	private int tasksCompleted = 0; // Counter to track completed tasks

	[SerializeField] private GameObject uiPanel;
	[SerializeField] private TextMeshProUGUI dialogue;


	// Method to update the text displayed
	public void UpdateText(string newText)
	{
		if (dialogue != null)
		{
			dialogue.text = newText;
		}
		else
		{
			Debug.LogWarning("TextMeshProUGUI reference is missing.");
		}
	}

	public void Dialogue()
	{
		UpdateText("Huh, I guess I'm not awake yet after all...");
	}

	void Start()
	{

		anomaliesDetected = spawnManager.anomaliesDetected;
		Debug.Log("TaskManager got " + anomaliesDetected + " anomalies");

		// Initialize the task display
		if (tasks.Length > 0)
		{
			UpdateTaskDisplay();
		}
		UpdateText("");
	}

	// Method to update the task display
	private void UpdateTaskDisplay()
	{
		if (taskText != null && tasks.Length > 0)
		{
			taskText.text = tasks[currentTaskIndex];
		}
	}

	// Method to change to the next task
	public void NextTask()
	{
		if (tasks.Length > 0)
		{
			// Move to the next task
			currentTaskIndex++;
			tasksCompleted++;

			if (currentTaskIndex < tasks.Length)
			{
				// Update the task display if there are more tasks
				UpdateTaskDisplay();
			}
			else
			{
				EndGame();
			}

			// Log the number of tasks completed (for debugging)
			Debug.Log("Tasks Completed: " + tasksCompleted);
		}
	}

	// Method to check if a specific object is the current task object
	public bool IsCurrentTask(GameObject obj)
	{
		if (currentTaskIndex < taskObjects.Length)
		{
			return taskObjects[currentTaskIndex] == obj;
		}
		return false;
	}

	// Method to handle the end of the game
	public void EndGame()
	{
		Debug.Log("Reloading scene...");
		if (anomaliesDetected != 0)
		{
			if (anomaliesClicked != 0)
			{
				ScoreManager.Instance.AddScore(1);
			}
			else
			{
				ScoreManager.Instance.ResetScore();
			}
		}
		else
		{
			ScoreManager.Instance.AddScore(1);
		}

		// Play the animation
		if (uiAnimator != null)
		{
			uiAnimator.SetTrigger("LevelCompleted");
		}
		else
		{
			Debug.LogWarning("UI Animator is not assigned.");
		}
	}

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	// Method to reload the scene
	public void ReloadScene()
	{
		// Get the current scene name and reload it
		string sceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(sceneName);
	}
}