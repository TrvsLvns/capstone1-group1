using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class QuizManager : MonoBehaviour
{
    public string _difficulty;
    public List<QuestionAndAnswers> QnA_Easy;
    public List<QuestionAndAnswers> QnA_Intermediate;
    public List<QuestionAndAnswers> QnA_Hard;
    public GameObject[] options;
    public int currentQuestion = -1;
    public int answer = 0;
    public int remainingQuestions;

    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI DifficultyTxt;
    public TextMeshProUGUI RemainingQuestionsTxt;

    public MenuManager menuManager;
    public ShopManager shopManager;

    public void setDifficulty(string difficulty)
    {
        _difficulty = difficulty;
        DifficultyTxt.text = difficulty;
        countRemainingQuestions();
        RemainingQuestionsTxt.text = "Remaining Questions: " + remainingQuestions;
    }

    public void resetQuestions()
    {
        if (_difficulty == "Easy")
        {
            for (int i = 0; i < QnA_Easy.Count; i++)
            {
                QnA_Easy[i].answered = false;
            }
            remainingQuestions = QnA_Easy.Count;
        }
        else if (_difficulty == "Intermediate")
        {
            for (int i = 0; i < QnA_Intermediate.Count; i++)
            {
                QnA_Intermediate[i].answered = false;
            }
            remainingQuestions = QnA_Intermediate.Count;
        }
        else if (_difficulty == "Hard")
        {
            for (int i = 0; i < QnA_Hard.Count; i++)
            {
                QnA_Hard[i].answered = false;
            }
            remainingQuestions = QnA_Hard.Count;
        }
        RemainingQuestionsTxt.text = "Remaining Questions: " + remainingQuestions;
    }

    public void countRemainingQuestions()
    {
        remainingQuestions = 0;
        if (_difficulty == "Easy")
        {
            for (int i = 0; i < QnA_Easy.Count; i++)
            {
                if (QnA_Easy[i].answered == false)
                {
                    remainingQuestions++;
                }
            }
        }
        else if (_difficulty == "Intermediate")
        {
            for (int i = 0; i < QnA_Intermediate.Count; i++)
            {
                if (QnA_Intermediate[i].answered == false)
                {
                    remainingQuestions++;
                }
            }
        }
        else if (_difficulty == "Hard")
        {
            for (int i = 0; i < QnA_Hard.Count; i++)
            {
                if (QnA_Hard[i].answered == false)
                {
                    remainingQuestions++;
                }
            }
        }
    }

    public void startQuestions()
    {
        if (remainingQuestions > 0)
        {
            generateQuestion();
            menuManager.showScreen(MenuManager.MenuScreenType.canvas_three_submit);
        }
    }

    public void onSubmit()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<QuizButtons>().submitted = true;
        }
        menuManager.showScreen(MenuManager.MenuScreenType.canvas_three_continue);
        if (_difficulty == "Easy")
        {
            var colors = options[QnA_Easy[currentQuestion].CorrectAnswer].GetComponent<Button>().colors;
            colors.normalColor = Color.green;
            options[QnA_Easy[currentQuestion].CorrectAnswer].GetComponent<Button>().colors = colors;
            if (QnA_Easy[currentQuestion].CorrectAnswer != answer)
            {
                var color = options[answer].GetComponent<Button>().colors;
                color.normalColor = Color.red;
                options[answer].GetComponent<Button>().colors = color;
            }
            else
            {
                shopManager.points += 1;
            }
            QnA_Easy[currentQuestion].answered = true;
        }
        else if (_difficulty == "Intermediate")
        {
            var colors = options[QnA_Intermediate[currentQuestion].CorrectAnswer].GetComponent<Button>().colors;
            colors.normalColor = Color.green;
            options[QnA_Intermediate[currentQuestion].CorrectAnswer].GetComponent<Button>().colors = colors;
            if (QnA_Intermediate[currentQuestion].CorrectAnswer != answer)
            {
                var color = options[answer].GetComponent<Button>().colors;
                color.normalColor = Color.red;
                options[answer].GetComponent<Button>().colors = color;
            }
            else
            {
                shopManager.points += 2;
            }
            QnA_Intermediate[currentQuestion].answered = true;
        }
        else if (_difficulty == "Hard")
        {
            var colors = options[QnA_Hard[currentQuestion].CorrectAnswer].GetComponent<Button>().colors;
            colors.normalColor = Color.green;
            options[QnA_Hard[currentQuestion].CorrectAnswer].GetComponent<Button>().colors = colors;
            if (QnA_Hard[currentQuestion].CorrectAnswer != answer)
            {
                var color = options[answer].GetComponent<Button>().colors;
                color.normalColor = Color.red;
                options[answer].GetComponent<Button>().colors = color;
            }
            else
            {
                shopManager.points += 3;
            }
            QnA_Hard[currentQuestion].answered = true;
        }
        remainingQuestions--;
    }

    public void onContinue()
    {
        for (int i = 0; i < options.Length; i++)
        {
            var colors = options[i].GetComponent<Button>().colors; 
            colors.normalColor = Color.white;
            options[i].GetComponent<Button>().colors = colors;
        }

        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<QuizButtons>().submitted = false;
        }

        if (remainingQuestions > 0)
        {
            startQuestions();
        }
        else
        {
            RemainingQuestionsTxt.text = "Remaining Questions: " + remainingQuestions;
            menuManager.showScreen(MenuManager.MenuScreenType.canvas_two);
        }
    }

    void generateQuestion()
    {
        if (_difficulty == "Easy")
        {
            do
            {
                currentQuestion = Random.Range(0, QnA_Easy.Count);
            } while (currentQuestion < 0 || QnA_Easy[currentQuestion].answered != false) ;
            QuestionTxt.text = QnA_Easy[currentQuestion].Question;
        }
        else if (_difficulty == "Intermediate")
        {
            do
            {
                currentQuestion = Random.Range(0, QnA_Intermediate.Count);
            } while (currentQuestion < 0 || QnA_Intermediate[currentQuestion].answered != false) ;
            QuestionTxt.text = QnA_Intermediate[currentQuestion].Question;
        }
        else if (_difficulty == "Hard")
        {
            do
            {
                currentQuestion = Random.Range(0, QnA_Hard.Count);
            } while (currentQuestion < 0 || QnA_Hard[currentQuestion].answered != false);
            QuestionTxt.text = QnA_Hard[currentQuestion].Question;
        } 
            setAnswers();
    }

    void setAnswers()
    {
        if (_difficulty == "Easy")
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA_Easy[currentQuestion].Answers[i];
            }
        }
        else if (_difficulty == "Intermediate")
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA_Intermediate[currentQuestion].Answers[i];
            }
        }
        else if (_difficulty == "Hard")
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA_Hard[currentQuestion].Answers[i];
            }
        }
    }
}