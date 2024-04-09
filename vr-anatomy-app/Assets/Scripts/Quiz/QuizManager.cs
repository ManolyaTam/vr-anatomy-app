using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    private Dictionary<string, List<QuestionsAndAnswers>> organQuizzes; // Dictionary to store quizzes for each organ
    
    public GameObject[] options;
    private int currentQuestion;

    public TextMeshProUGUI questionText;

    public GameObject portalPanel;
    public GameObject quizPanel;
    public GameObject resultPanel;

    public TextMeshProUGUI scoreText;
    int totalQuestions;
    int score;

    public GameObject retryButton;

    public TextMeshProUGUI organTitle;
    private string organ;

    public GameObject heartPart1;

    private void Start()
    {
        organ = organTitle.text;
        score = 0;

        // Initialize the dictionary and populate quizzes for each organ
        QuizData quizData = ScriptableObject.CreateInstance<QuizData>();
        organQuizzes = quizData.getQuizData();
        QuestionsAndAnswers q5 = new QuestionsAndAnswers();
        q5.question = "What is the selected part?";
        q5.answers = new string[] { "Superior vena cava", "Aorta", "Pulmonary artery", "Pulmonary vein" };
        q5.correctAnswer = 1;
        q5.organ = heartPart1;
        organQuizzes["Heart"].Add(q5);
    }
    public void StartQuiz()
    {
        // Get the quiz for the specified organ
        //organ = GetComponent<ToggleOrganName>().organTitle;
        organ = organTitle.text;
        List<QuestionsAndAnswers> quiz = organQuizzes[organ];
        totalQuestions = quiz.Count;
        resultPanel.SetActive(false);
        generateQuestion(quiz);
    }

    private void generateQuestion(List<QuestionsAndAnswers> quiz)
    {
        if (quiz.Count == 0)
        {
            GameOver();
        }
        else
        {
            currentQuestion = Random.Range(0, quiz.Count);

            questionText.text = quiz[currentQuestion].question;
            if (quizPanel.activeInHierarchy == true && quiz[currentQuestion].organ != null)
            {
                quiz[currentQuestion].organ.SetActive(true);
            }
            SetAnswers(quiz);
        }
    }

    private void SetAnswers(List<QuestionsAndAnswers> quiz)
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = quiz[currentQuestion].answers[i];

            if (quiz[currentQuestion].correctAnswer == i)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }

    public void Correct()
    {
        organQuizzes[organ][currentQuestion].organ?.SetActive(false);
        score++;
        organQuizzes[organ].RemoveAt(currentQuestion); // Remove question from the quiz
        generateQuestion(organQuizzes[organ]);
    }

    public void Wrong()
    {
        organQuizzes[organ][currentQuestion].organ?.SetActive(false);
        organQuizzes[organ].RemoveAt(currentQuestion); // Remove question from the quiz
        generateQuestion(organQuizzes[organ]);
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
        // Bug here: when a question with image appears the first one, the image doesn't apear with it
        // One more: this button sometimes return back to the portal like Back()
        Start();
        resultPanel.SetActive(false);
        quizPanel.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Back()
    {
        Start();
        resultPanel.SetActive(false);
        portalPanel.SetActive(true);
    }
}
