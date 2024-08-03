using UnityEngine;
using TMPro; // Required for using TextMeshProUGUI component
using UnityEngine.SceneManagement; // Required for scene management

public class TaskManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI taskText; // Reference to the TextMeshProUGUI component
	[SerializeField] private string[] tasks; // Array of task strings
	[SerializeField] private GameObject[] taskObjects; // Array of task objects
	[SerializeField] private Animator uiAnimator; // Reference to the UI Animator component

	private int currentTaskIndex = 0; // Index to keep track of the current task
	private int tasksCompleted = 0; // Counter to track completed tasks

	void Start()
	{
		// Initialize the task display
		if (tasks.Length > 0)
		{
			UpdateTaskDisplay();
		}
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
				// Trigger the end game UI or transition to another scene
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
	private void EndGame()
	{
		Debug.Log("All tasks completed! Ending the game...");

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

	// Method to reload the scene
	public void ReloadScene()
	{
		// Get the current scene name and reload it
		string sceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(sceneName);
	}
}