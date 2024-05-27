using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuizDataObjects> organQuizDataList; // New: List to store ScriptableObject assets for each organ

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
    public GameObject skeletonQ6Organ;
    public GameObject skeletonQ7Organ;

    private void Start()
    {
        organ = organTitle.text;
        score = 0;
        currentQuestion = 0;

        // Initialize the dictionary
        organQuizzes = new Dictionary<string, List<QuestionsAndAnswers>>();

        // Populate the dictionary with quiz data from ScriptableObjects
        foreach (var quizData in organQuizDataList)
        {
            organQuizzes.Add(quizData.OrganName, new List<QuestionsAndAnswers>(quizData.questionsAndAnswers));
        }
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
        if (quiz.Count == currentQuestion)
        {
            GameOver();
        }
        else
        {
            //currentQuestion = Random.Range(0, quiz.Count);
            //currentQuestion = 0;

            questionText.text = quiz[currentQuestion].question;
            //if (quizPanel.activeInHierarchy == true && quiz[currentQuestion].organ != null)
            //{
            //    quiz[currentQuestion].organ.SetActive(true);
            //}
            string modelName = $"{organ}Q{currentQuestion + 1}";
            GameObject gameObject = IsGameObjectInScene(modelName);
            if (gameObject != null)
            {
                quiz[currentQuestion].organ = gameObject;
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
        //if (quizPanel.activeInHierarchy == true && organQuizzes[organ][currentQuestion].organ != null)
        //{
        //    organQuizzes[organ][currentQuestion].organ.SetActive(false);
        //}
        score++;
        //currentQuestion++;
        ////organQuizzes[organ].RemoveAt(currentQuestion); // Remove question from the quiz
        //generateQuestion(organQuizzes[organ]);
        StartCoroutine(NextQuestionAfterDelay());
    }

    public void Wrong()
    {
        //currentQuestion++;
        ////organQuizzes[organ].RemoveAt(currentQuestion); // Remove question from the quiz
        //generateQuestion(organQuizzes[organ]);
        StartCoroutine(NextQuestionAfterDelay());
    }

    private IEnumerator NextQuestionAfterDelay()
    {
        // Disable all buttons to prevent clicking during the delay
        foreach (GameObject option in options)
        {
            option.GetComponent<Button>().interactable = false;
        }

        yield return new WaitForSeconds(2);

        // Enable all buttons back after the delay
        foreach (GameObject option in options)
        {
            option.GetComponent<Button>().interactable = true;
        }

        if (quizPanel.activeInHierarchy == true && organQuizzes[organ][currentQuestion].organ != null)
        {
            organQuizzes[organ][currentQuestion].organ.SetActive(false);
        }
        currentQuestion++;
        foreach (GameObject option in options)
        {
            option.GetComponent<Answer>().ResetColor(); // Reset color of options
        }
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
        Start();
        resultPanel.SetActive(false);
        quizPanel.SetActive(true);
        StartQuiz();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Back()
    {
        Start();
        resultPanel.SetActive(false);
        portalPanel.SetActive(true);
    }

    GameObject IsGameObjectInScene(string objectName)
    {
        Scene scene = SceneManager.GetSceneByName("Quiz");

        foreach (GameObject go in scene.GetRootGameObjects())
        {
            if (go.name == objectName)
            {
                return go;
            }
        }

        return null;
    }
}
