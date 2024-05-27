using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    private Color originalColor;
    private Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        originalColor = buttonImage.color; // Save the original color
    }

    public void _Answer()
    {
        if (isCorrect)
        {
            buttonImage.color = HexToColor("#00b200"); // Correct answer 
            quizManager.Correct();
        }
        else
        {
            buttonImage.color = Color.red; // Wrong answer
            quizManager.Wrong();
        }
    }

    public void ResetColor()
    {
        buttonImage.color = originalColor;
    }

    private Color HexToColor(string hex)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        else
        {
            Debug.LogWarning("Invalid hex string");
            return Color.white; 
        }
    }
}
