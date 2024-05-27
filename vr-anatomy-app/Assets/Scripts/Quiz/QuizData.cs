using System.Collections.Generic;
using UnityEngine;

public class QuizData : ScriptableObject
{
    Dictionary<string, List<QuestionsAndAnswers>> organQuizzes = new Dictionary<string, List<QuestionsAndAnswers>>();
    public Dictionary<string, List<QuestionsAndAnswers>> getQuizData()
    {
        if (!organQuizzes.ContainsKey("Heart"))
            generateHeartQuiz();

        if (!organQuizzes.ContainsKey("Chest"))
            generateChestQuiz();

        if (!organQuizzes.ContainsKey("Brain"))
            generateBrainQuiz();

        if (!organQuizzes.ContainsKey("Skeleton"))
            generateSkeletonQuiz();

        return organQuizzes;
    }
    public void generateHeartQuiz()
    {
        List<QuestionsAndAnswers> heartQuiz = new List<QuestionsAndAnswers>();

        QuestionsAndAnswers q1 = new QuestionsAndAnswers();
        q1.question = "What is the main function of the heart?";
        q1.answers = new string[] { "Pumping blood", "Digestion", "Breathing", "Thinking" };
        q1.correctAnswer = 0;
        heartQuiz.Add(q1);

        QuestionsAndAnswers q2 = new QuestionsAndAnswers();
        q2.question = "Which chamber of the heart receives oxygen-rich blood from the lungs?";
        q2.answers = new string[] { "Right atrium", "Left atrium", "Right ventricle", "Left ventricle" };
        q2.correctAnswer = 1;
        heartQuiz.Add(q2);

        QuestionsAndAnswers q3 = new QuestionsAndAnswers();
        q3.question = "Which valve separates the right atrium from the right ventricle?";
        q3.answers = new string[] { "Tricuspid valve", "Bicuspid valve", "Pulmonary valve", "Aortic valve" };
        q3.correctAnswer = 0;
        heartQuiz.Add(q3);

        QuestionsAndAnswers q4 = new QuestionsAndAnswers();
        q4.question = "What is the term for the contraction phase of the heart cycle?";
        q4.answers = new string[] { "Systole", "Diastole", "Arrhythmia", "Aneurysm" };
        q4.correctAnswer = 0;
        heartQuiz.Add(q4);

        QuestionsAndAnswers q6 = new QuestionsAndAnswers();
        q6.question = "Which blood vessel carries oxygenated blood from the heart to the body?";
        q6.answers = new string[] { "Aorta", "Pulmonary artery", "Pulmonary vein", "Vena cava" };
        q6.correctAnswer = 0;
        heartQuiz.Add(q6);

        organQuizzes.Add("Heart", heartQuiz);
    }

    public void generateChestQuiz()
    {
        List<QuestionsAndAnswers> chestQuiz = new List<QuestionsAndAnswers>();
        QuestionsAndAnswers q1 = new QuestionsAndAnswers();
        q1.question = "Which of the following organs is located in the chest cavity?";
        q1.answers = new string[] { "Lungs", "Liver", "Kidneys", "Stomach" };
        q1.correctAnswer = 0;
        chestQuiz.Add(q1);

        QuestionsAndAnswers q2 = new QuestionsAndAnswers();
        q2.question = "What is the primary function of the lungs?";
        q2.answers = new string[] { "Gas exchange", "Digestion", "Pumping blood", "Thinking" };
        q2.correctAnswer = 0;
        chestQuiz.Add(q2);

        QuestionsAndAnswers q3 = new QuestionsAndAnswers();
        q3.question = "Which muscle helps in breathing by expanding the chest cavity?";
        q3.answers = new string[] { "Diaphragm", "Biceps", "Quadriceps", "Gluteus Maximus" };
        q3.correctAnswer = 0;
        chestQuiz.Add(q3);

        QuestionsAndAnswers q4 = new QuestionsAndAnswers();
        q4.question = "Which organ produces red blood cells and is located in the chest cavity?";
        q4.answers = new string[] { "Bone marrow", "Liver", "Spleen", "Pancreas" };
        q4.correctAnswer = 0;
        chestQuiz.Add(q4);

        QuestionsAndAnswers q5 = new QuestionsAndAnswers();
        q5.question = "Which of the following is not a part of the respiratory system?";
        q5.answers = new string[] { "Stomach", "Trachea", "Lungs", "Bronchi" };
        q5.correctAnswer = 0;
        chestQuiz.Add(q5);

        organQuizzes.Add("Chest", chestQuiz);
    }

    public void generateBrainQuiz()
    {
        List<QuestionsAndAnswers> brainQuiz = new List<QuestionsAndAnswers>();

        QuestionsAndAnswers q1 = new QuestionsAndAnswers();
        q1.question = "Which part of the brain is responsible for higher cognitive functions such as thinking and decision-making?";
        q1.answers = new string[] { "Cerebrum", "Cerebellum", "Brainstem", "Hippocampus" };
        q1.correctAnswer = 0;
        brainQuiz.Add(q1);

        QuestionsAndAnswers q2 = new QuestionsAndAnswers();
        q2.question = "Which part of the brain is responsible for coordinating muscle movements and maintaining balance?";
        q2.answers = new string[] { "Cerebellum", "Cerebrum", "Brainstem", "Thalamus" };
        q2.correctAnswer = 0;
        brainQuiz.Add(q2);

        QuestionsAndAnswers q3 = new QuestionsAndAnswers();
        q3.question = "Which part of the brain regulates basic functions such as breathing and heart rate?";
        q3.answers = new string[] { "Brainstem", "Cerebrum", "Hippocampus", "Pituitary gland" };
        q3.correctAnswer = 0;
        brainQuiz.Add(q3);

        QuestionsAndAnswers q4 = new QuestionsAndAnswers();
        q4.question = "Which part of the brain is associated with the formation of new memories?";
        q4.answers = new string[] { "Hippocampus", "Cerebellum", "Amygdala", "Thalamus" };
        q4.correctAnswer = 0;
        brainQuiz.Add(q4);

        QuestionsAndAnswers q5 = new QuestionsAndAnswers();
        q5.question = "Which part of the brain is responsible for relaying sensory information to the cerebral cortex?";
        q5.answers = new string[] { "Thalamus", "Hypothalamus", "Pons", "Medulla oblongata" };
        q5.correctAnswer = 0;
        brainQuiz.Add(q5);

        organQuizzes.Add("Brain", brainQuiz);
    }

    public void generateSkeletonQuiz()
    {
        List<QuestionsAndAnswers> skeletonQuiz = new List<QuestionsAndAnswers>();

        QuestionsAndAnswers q1 = new QuestionsAndAnswers();
        q1.question = "What is the largest bone in the human body?";
        q1.answers = new string[] { "Femur", "Humerus", "Tibia", "Fibula" };
        q1.correctAnswer = 0;
        skeletonQuiz.Add(q1);

        QuestionsAndAnswers q2 = new QuestionsAndAnswers();
        q2.question = "What is the primary function of the rib cage?";
        q2.answers = new string[] { "To protect the heart and lungs", "To support the arms", "To aid in digestion", "To facilitate movement" };
        q2.correctAnswer = 0;
        skeletonQuiz.Add(q2);

        QuestionsAndAnswers q3 = new QuestionsAndAnswers();
        q3.question = "Which bone is commonly known as the collarbone?";
        q3.answers = new string[] { "Scapula", "Clavicle", "Sternum", "Mandible" };
        q3.correctAnswer = 1;
        skeletonQuiz.Add(q3);

        QuestionsAndAnswers q4 = new QuestionsAndAnswers();
        q4.question = "What type of joint is the shoulder joint?";
        q4.answers = new string[] { "Hinge joint", "Ball-and-socket joint", "Pivot joint", "Saddle joint" };
        q4.correctAnswer = 1;
        skeletonQuiz.Add(q4);

        QuestionsAndAnswers q5 = new QuestionsAndAnswers();
        q5.question = "Which part of the skeleton protects the brain?";
        q5.answers = new string[] { "Rib cage", "Pelvis", "Spine", "Skull" };
        q5.correctAnswer = 3;
        skeletonQuiz.Add(q5);

        organQuizzes.Add("Skeleton", skeletonQuiz);
    }


    // Initialize the dictionary and populate quizzes for each organ
    //QuizData quizData = ScriptableObject.CreateInstance<QuizData>();
    //organQuizzes = quizData.getQuizData();
    //QuestionsAndAnswers heartQ6 = new QuestionsAndAnswers();
    //heartQ6.question = "What is the selected part?";
    //heartQ6.answers = new string[] { "Superior vena cava", "Aorta", "Pulmonary artery", "Pulmonary vein" };
    //heartQ6.correctAnswer = 1;
    //heartQ6.organ = heartPart1;
    //organQuizzes["Heart"].Add(heartQ6);

    //QuestionsAndAnswers skeletonQ6 = new QuestionsAndAnswers();
    //skeletonQ6.question = "The vertebral column composed of: ";
    //skeletonQ6.answers = new string[] { "30 vertebrae", "31 vertebrae", "32 vertebrae", "33 vertebrae" };
    //skeletonQ6.correctAnswer = 3;
    //skeletonQ6.organ = skeletonQ6Organ;
    //organQuizzes["Skeleton"].Add(skeletonQ6);

    //QuestionsAndAnswers skeletonQ7 = new QuestionsAndAnswers();
    //skeletonQ7.question = "This bone is: ";
    //skeletonQ7.answers = new string[] { "Humerus", "Clavicle", "Scapula", "Raius" };
    //skeletonQ7.correctAnswer = 2;
    //skeletonQ7.organ = skeletonQ7Organ;
    //organQuizzes["Skeleton"].Add(skeletonQ7);
}
