using UnityEngine;

public class RetrieveSaveData : MonoBehaviour
{
    private SaveData saveData; // Stores loaded data

    private void Start()
    {
        LoadGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    void SaveGame()
    {
        saveData = new SaveData(3, 75.5f, "Player");
        DataSave.SaveData(saveData, "playerSave");
        Debug.Log("Game Saved!");
    }

    void LoadGame()
    {
        if (DataSave.SaveExists("playerSave"))
        {
            saveData = DataSave.LoadData<SaveData>("playerSave");
            Debug.Log($"Loaded Player: {saveData.playerName}, Level: {saveData.level}, Health: {saveData.health}");
        }
        else
        {
            Debug.Log("No save data found!");
        }
    }

    public int GetPlayerLevel()
    {
        return saveData != null ? saveData.level : 0; // Default to 0 if no data
    }

    public float GetPlayerHealth()
    {
        return saveData != null ? saveData.health : 0f;
    }

    public string GetPlayerName()
    {
        return saveData != null ? saveData.playerName : "Unknown";
    }
}
