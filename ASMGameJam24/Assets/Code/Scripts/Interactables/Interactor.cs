using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Interactor : MonoBehaviour
{
	[SerializeField] private string type1; // Define the first type
	[SerializeField] private string type2; // Define the second type
	[SerializeField] private string type3; // Define the second type
	[SerializeField] private LayerMask interactableLayer; // Reference to the layer mask
	[SerializeField] private TaskManager taskManager; // Reference to the TaskManager script

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			// Calculate the center of the screen
			Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

			// Generate a ray from the camera to the center of the screen
			Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

			// Draw the ray in the scene view for visualization
			Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 5);

			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
			{
				// Get the hit object's parent if it has one
				Transform hitTransform = hit.collider.transform;
				if (hitTransform.parent != null)
				{
					hitTransform = hitTransform.parent;
				}

				IInteractable interactable = hitTransform.GetComponent<IInteractable>();

				if (interactable != null)
				{
					// Check for each type and call the corresponding function
					switch (interactable.ObjectType)
					{
						case var t when t == type1:
							HandleType1(interactable);
							break;
						case var t when t == type2:
							HandleType2(interactable);
							break;
						case var t when t == type3:
							HandleType3(interactable);
							break;
						default:
							Debug.Log("Unknown type");
							break;
					}
				}
				else
				{
					Debug.Log("No IInteractable component found on hit object.");
				}
			}
			else
			{
				Debug.Log("Raycast did not hit any object.");
			}
		}
	}

	private void HandleType1(IInteractable interactable)
	{
		Debug.Log("Clicked Anomaly");
		taskManager.anomaliesClicked++;
		taskManager.Dialogue();
		taskManager.EndGame();
		Debug.Log("taskManager got anomalies clicked " + taskManager.anomaliesClicked);
	}

	private void HandleType2(IInteractable interactable)
	{
		Debug.Log("Clicked Non-Anomaly");

		// Call the NextTask method on the TaskManager if the clicked object is the current task object
		if (taskManager != null)
		{
			MonoBehaviour monoInteractable = interactable as MonoBehaviour;
			GameObject clickedObject = monoInteractable.gameObject;

			if (taskManager.IsCurrentTask(clickedObject) && !interactable.HasBeenClicked)
			{

				interactable.HasBeenClicked = true;
				// Play the animation

				
				Animator animator = clickedObject.GetComponent<Animator>();
				if (animator != null)
				{
					animator.SetTrigger("Complete"); // Ensure the trigger name matches the one used in Animator
					Debug.Log("animation not playing??");
				}
			}
		}
		else
		{
			Debug.LogWarning("TaskManager reference is missing.");
		}
	}

	private void HandleType3(IInteractable interactable)
	{
		// Get the MonoBehaviour of the interactable
		MonoBehaviour monoInteractable = interactable as MonoBehaviour;
		if (monoInteractable != null)
		{
			// Get the GameObject of the interactable
			GameObject clickedObject = monoInteractable.gameObject;

			// Get the AudioSource component from the target object
			AudioSource audioSource = clickedObject.GetComponent<AudioSource>();

			if (audioSource != null)
			{
				// Play a specific sound from the AudioSource
				// Assuming you want to play the first clip, you can adjust as needed
				// Example: audioSource.clip = yourSpecificAudioClip;
				audioSource.Play();
				Debug.Log("Playing sound from AudioSource.");
			}
			else
			{
				Debug.LogWarning("AudioSource component not found on the target object.");
			}
		}
		else
		{
			Debug.LogWarning("Interactable is not a MonoBehaviour.");
		}
	}
}