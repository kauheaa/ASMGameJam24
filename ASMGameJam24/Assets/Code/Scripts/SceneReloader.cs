using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
	// Method to reload the current scene
	public void ReloadScene()
	{
		// Get the name of the current scene
		string sceneName = SceneManager.GetActiveScene().name;

		// Optional: Interact with ScoreManager before reloading
		if (ScoreManager.Instance != null)
		{
			Debug.Log("Current Score: " + ScoreManager.Instance.score);
		}
		else
		{
			Debug.LogWarning("ScoreManager instance not found.");
		}

		// Reload the current scene
		SceneManager.LoadScene(sceneName);
	}
}