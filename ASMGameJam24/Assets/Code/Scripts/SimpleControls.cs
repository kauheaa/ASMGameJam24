using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class SimpleControls : MonoBehaviour
{
	[SerializeField] public ScoreManager scoreManager;
	public GameObject helpPanel; // Reference to the panel you want to toggle
	void Update()
	{
		// Check if the "Esc" key is pressed
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			// Close the game
			Application.Quit();
			// If running in the editor, stop playing the scene
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#endif
		}

		// Check if the "R" key is pressed
		if (Input.GetKeyDown(KeyCode.R))
		{

			scoreManager.ResetScore();
			// Load the scene called "Level"
			SceneManager.LoadScene("Level");
		}

		if (Input.GetKeyDown(KeyCode.Tab))
		{
			helpPanel.SetActive(true);
		}

		if (Input.GetKeyUp(KeyCode.Tab))
		{
			helpPanel.SetActive(false);
		}
	}
}