using UnityEngine;

public class SpawnerPoint : MonoBehaviour
{
	public GameObject defaultObject; // Default object to spawn
	public GameObject[] specialItems; // Array of special items to choose from
	public SpawnManager spawnManager;

	public void SpawnDefault()
	{
		Instantiate(defaultObject, transform.position, transform.rotation);
	}

	public void SpawnSpecial()
	{
		if (specialItems.Length > 0)
		{
			int randomIndex = Random.Range(0, specialItems.Length);
			GameObject spawnedObject = Instantiate(specialItems[randomIndex], transform.position, transform.rotation);

			// Check if the spawned object has the SpawnableObject component
			InteractablePrefab spawnableObject = spawnedObject.GetComponent<InteractablePrefab>();

			if (spawnableObject != null)
			{
				// Check the objectType
				if (spawnableObject.ObjectType == "anomaly")
				{
					spawnManager.anomaliesDetected++;
				}
			}

		}
		else
		{
			Debug.LogWarning("No special items available to spawn.");
		}
	}
}