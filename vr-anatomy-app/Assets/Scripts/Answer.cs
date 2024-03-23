using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    //private Color originalColor = new Color(0f, 0.7215686f, 1f, 0.3137255f); // Original color (light blue)

    public void _Answer()
    {
        if (isCorrect)
        {
            quizManager.Correct();
        }
        else
        {
            quizManager.Wrong();
        }
    }

}
