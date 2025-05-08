using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class life_counter : MonoBehaviour    //score_manager
{
    public static life_counter instance;
    public TMP_Text score_text;
    int score = 0;

    public GameObject player;
    public GameObject heartPrefab;   // Reference to the heart prefab
    public Transform heartsParent;   // The parent object where hearts will be instantiated
    public win_lose_screens loseScreen;
    public int life = 5;


    private void Awake()
    {
        instance = this;
    }
    public void updateUI()
    {
        score_text.text = "Points: " + score.ToString();
        updateHearts();
    }
    public void updateHearts()
    {
        // Clear previous hearts
        foreach (Transform child in heartsParent)
        {
            Destroy(child.gameObject);
        }

        // Add new hearts based on the current life
        for (int i = 0; i < life; i++)
        {
            Instantiate(heartPrefab, heartsParent);  // Create a new heart in the parent container
        }
    }

    void Start()
    {
        updateUI();
    }

    public void addPoints()
    {
        score++;
        updateUI();
    }

    public void addLife()
    {
        life++;
        updateUI();
    }

    public void subLife()
    {
        life--;
        updateUI();
        if (life <= 0)
        {
            loseScreen.ShowLoseScreen();
            // Destroy(player);
        }
    }

}
