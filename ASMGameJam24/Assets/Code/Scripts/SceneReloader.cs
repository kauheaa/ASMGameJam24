using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    // Method to reload the current scene or move to the "End" scene
    public void ReloadScene()
    {
        // Get the name of the current scene
        string sceneName = SceneManager.GetActiveScene().name;

        // Optional: Interact with ScoreManager before reloading or changing the scene
        if (ScoreManager.Instance != null)
        {
            Debug.Log("Current Score: " + ScoreManager.Instance.score);

            // Check if the score is 5 or more
            if (ScoreManager.Instance.score >= 5)
            {
                // Move to the "End" scene
                SceneManager.LoadScene("End");
                return; // Exit the method to avoid reloading the current scene
            }
        }
        else
        {
            Debug.LogWarning("ScoreManager instance not found.");
        }

        // Reload the current scene if the score is less than 5
        SceneManager.LoadScene(sceneName);
    }
}