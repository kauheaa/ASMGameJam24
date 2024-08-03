using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
	public SpawnerPoint[] spawnerPoints; // Array of spawner points
	public int anomaliesDetected = 0;

	private void Start()
	{
		anomaliesDetected = 0;

		if (spawnerPoints.Length == 0)
		{
			Debug.LogError("No spawner points assigned.");
			return;
		}

		// Randomly select one spawner point to spawn a special item
		int specialSpawnerIndex = Random.Range(0, spawnerPoints.Length);

		for (int i = 0; i < spawnerPoints.Length; i++)
		{
			if (i == specialSpawnerIndex)
			{
				spawnerPoints[i].SpawnSpecial();
				Debug.Log("spawn manager found " + anomaliesDetected + " anomalies");
			}
			else
			{
				spawnerPoints[i].SpawnDefault();
			}
		}
		Debug.Log("anomalies detected: " + anomaliesDetected);

	}

	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			ReloadScene();
		}
	}
}