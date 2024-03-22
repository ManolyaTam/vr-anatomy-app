using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI questionText;

    public GameObject quizPanel;
    public GameObject resultPanel;

    public TextMeshProUGUI scoreText;
    int totalQuestions;
    int score;

    public GameObject retryButton;


    private void Start()
    {
        //QnA = new List<QuestionsAndAnswers>();
        //QuestionsAndAnswers q1 = new QuestionsAndAnswers();
        ////QuestionsAndAnswers q2 = new QuestionsAndAnswers();
        //q1.question = "This is X";
        //q1.answers = new string[4];
        //q1.answers[0] = "X";
        //q1.answers[1] = "Y";
        //q1.answers[2] = "Z";
        //q1.answers[3] = "W";
        //q1.correctAnswer = 0;
        //q2.question = "This is Y";
        //q2.answers = new string[] { "X", "Y", "Z", "W" };
        //q2.correctAnswer = 1;

        //QnA.Add(q1);
        //QnA.Add(q2);

        totalQuestions = QnA.Count;
        resultPanel.SetActive(false);
        generateQuestion();
    }

    private void generateQuestion()
    {
        if (QnA.Count == 0)
        {
            Debug.Log("No More Questions");
            GameOver();
        }
        else
        {
            currentQuestion = Random.Range(0, QnA.Count);

            questionText.text = QnA[currentQuestion].question;
            SetAnswers();
        }
    }

    private void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].answers[i];

            if (QnA[currentQuestion].correctAnswer == i)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }
    public void Correct()
    {
        //if (QnA.Count > 0 && currentQuestion < QnA.Count)
        //{
            // When we answer right 
            score++;
            QnA.RemoveAt(currentQuestion);
            generateQuestion();
        //}
        //else
        //{
        //    GameOver();
        //}
    }

    public void Wrong()
    {
        // When we answer wrong 
        //if (QnA.Count > 0 && currentQuestion < QnA.Count)
        //{
            QnA.RemoveAt(currentQuestion);
            generateQuestion();
        //}
        //else
        //{
        //    GameOver();
        //}
    }

    void GameOver()
    {
        quizPanel.SetActive(false);
        resultPanel.SetActive(true);

        scoreText.text = score + "/" + totalQuestions;

        if (score < totalQuestions)
        {
            retryButton.SetActive(true);
        }
        else
        {
            retryButton.SetActive(false);
        }
    }

    public void Retry()
    {
        //using UnityEngine.SceneManagement;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Reset score and question count
        //score = 0;
        //totalQuestions = QnA.Count;

        //// Show quiz panel and hide result panel
        //resultPanel.SetActive(false);
        //quizPanel.SetActive(true);

        //// Generate a new question
        //generateQuestion();
    }
}
