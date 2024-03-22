using UnityEngine;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void _Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer!");
            quizManager.Correct();
        }
        else
        {
            Debug.Log("Wrong Answer!");
            quizManager.Wrong();
        }
    }
}
