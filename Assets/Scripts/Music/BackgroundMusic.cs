using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;

    private void Awake()
    {
        // Check if an instance of BackgroundMusic already exists
        if (instance == null)
        {
            // If not, assign this instance and mark it to not be destroyed when changing scenes
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Start playing the music if it hasn't started yet
            GetComponent<AudioSource>().Play();
        }
        else
        {
            // If an instance already exists, destroy this new one to avoid overlapping
            Destroy(gameObject);
        }
    }

    // Called second
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Called third
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        if (scene.buildIndex == 0) // Here, we check if it's the first scene
        {
            instance = null;
            Destroy(gameObject); // Destroy BackgroundMusic
        }
        Debug.Log(mode);
    }

    // Called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
