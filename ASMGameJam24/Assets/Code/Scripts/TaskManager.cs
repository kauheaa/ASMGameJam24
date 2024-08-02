using UnityEngine;
using TMPro; // Required for using TextMeshProUGUI component

public class TaskManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI taskText; // Reference to the TextMeshProUGUI component
	[SerializeField] private string[] tasks; // Array of task strings
	[SerializeField] private GameObject finalUIElement; // Reference to the final UI element to show after all tasks are completed

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
		if (tasks.Length > 0 && currentTaskIndex < tasks.Length - 1)
		{
			// Move to the next task
			currentTaskIndex++;
			// Increment tasks completed counter
			tasksCompleted++;
			// Update the task display
			UpdateTaskDisplay();

			// Log the number of tasks completed (for debugging)
			Debug.Log("Tasks Completed: " + tasksCompleted);
		}
		else
		{
			// All tasks are completed, show the final UI element
			if (finalUIElement != null)
			{
				finalUIElement.SetActive(true);
			}
			Debug.Log("All tasks completed.");
		}
	}
}