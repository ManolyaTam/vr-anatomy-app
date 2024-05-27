using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizData", menuName = "ScriptableObjects/QuizData", order = 1)]
public class QuizDataObjects : ScriptableObject
{
    public string OrganName;
    public List<QuestionsAndAnswers> questionsAndAnswers;
}
