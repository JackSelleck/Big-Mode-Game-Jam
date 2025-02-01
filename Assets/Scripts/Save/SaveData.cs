using UnityEngine;

[System.Serializable] // This allows the class to be saved as JSON
public class SaveData : MonoBehaviour
{
    public int level;
    public float health;
    public string playerName;

    public GameObject paper1;
    public GameObject paper2;
    public GameObject paper3;
    public GameObject paper4;
    public GameObject paper5;

    public SaveData(int level, float health, string playerName)
    {
        this.level = level;
        this.health = health;
        this.playerName = playerName;
    }

}
