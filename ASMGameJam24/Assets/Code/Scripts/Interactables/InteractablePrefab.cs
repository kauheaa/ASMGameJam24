using System.Collections;
using UnityEngine;

public class InteractablePrefab : MonoBehaviour, IInteractable
{
	[SerializeField] private string objectType; // The type of the object
	[SerializeField] private Animator animator; // Reference to the Animator component

	public string ObjectType => objectType;
	public bool HasBeenClicked { get; set; } = false; // Property to track if the object has been clicked

	// Method to handle interaction (could be extended if needed)
	public void Interact()
	{
		// Implement interaction logic here if needed
	}

	// Method to play animation and handle task completion
	public void PlayAnimationAndCompleteTask(TaskManager taskManager)
	{
		if (animator != null)
		{
			// Trigger the complete animation
			animator.SetTrigger("Complete");

			// Optionally: You can start a coroutine here if needed
		}
		else
		{
			Debug.LogWarning("Animator component is missing.");
		}
	}

	// Method to be called by animation event
	public void OnAnimationComplete()
	{
		// Notify TaskManager of task completion
		TaskManager taskManager = FindObjectOfType<TaskManager>();
		if (taskManager != null)
		{
			taskManager.NextTask();
		}
		else
		{
			Debug.LogWarning("TaskManager is not found in the scene.");
		}
	}
}