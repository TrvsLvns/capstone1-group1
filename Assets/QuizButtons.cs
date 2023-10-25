using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizButtons : MonoBehaviour
{
    public QuizManager quizManager;
    public bool submitted = false;

    public void answer(int buttonID)
    {
        if (submitted == false)
        {
            quizManager.answer = buttonID;
        }
    }
}