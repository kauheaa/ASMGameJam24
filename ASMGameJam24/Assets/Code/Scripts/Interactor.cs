using UnityEngine;

public class Interactor : MonoBehaviour
{
	[SerializeField] private string type1; // Define the first type
	[SerializeField] private string type2; // Define the second type

	[SerializeField] private LayerMask interactableLayer; // Reference to the layer mask


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

				IInteractable interactable = hit.collider.GetComponent<IInteractable>();

				if (interactable != null)
				{

					// Check for each type and call the corresponding function
					switch (interactable.ObjectType)
					{
						case var t when t == type1:
							HandleType1();
							break;
						case var t when t == type2:
							HandleType2();
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

	private void HandleType1()
	{
		Debug.Log("Clicked Anomaly");
	}

	private void HandleType2()
	{
		Debug.Log("Clicked Non-Anomaly");
	}
}