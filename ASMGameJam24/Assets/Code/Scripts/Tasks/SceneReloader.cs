using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
	// Method to reload the current scene
	public void ReloadScene()
	{
		// Get the name of the current scene
		string sceneName = SceneManager.GetActiveScene().name;

		// Reload the current scene
		SceneManager.LoadScene(sceneName);
	}
} 