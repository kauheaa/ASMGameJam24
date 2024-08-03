using UnityEngine;

public class SpawnerPoint : MonoBehaviour
{
	public GameObject defaultObject; // Default object to spawn
	public GameObject[] specialItems; // Array of special items to choose from

	public void SpawnDefault()
	{
		Instantiate(defaultObject, transform.position, transform.rotation);
	}

	public void SpawnSpecial()
	{
		if (specialItems.Length > 0)
		{
			int randomIndex = Random.Range(0, specialItems.Length);
			Instantiate(specialItems[randomIndex], transform.position, transform.rotation);
		}
		else
		{
			Debug.LogWarning("No special items available to spawn.");
		}
	}
}