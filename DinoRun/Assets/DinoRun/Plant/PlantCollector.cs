using UnityEngine;
using TMPro; // For TextMeshPro support

public class PlantCollector : MonoBehaviour
{
    [Header("Score Settings")]
    public int scorePerPlant = 10; // Points awarded for each plant
    private int totalScore = 0; // Current total score

    [Header("UI Settings")]
    public TextMeshProUGUI scoreText; // Assign this in the Inspector

    [Header("Collection Settings")]
    public string plantTag = "Plant"; // Tag assigned to plant prefabs

    private void Start()
    {
        UpdateScoreUI(); // Initialize the UI score
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Check if the object has the correct tag
        if (other.CompareTag(plantTag)) {
            CollectPlant(other.gameObject);
        }}

    private void CollectPlant(GameObject plant)
    {
        // Increase the score
        totalScore += scorePerPlant;

        // Update the score UI
        UpdateScoreUI();

        // Destroy the plant
        Destroy(plant);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {totalScore}";
        }
    }
}


