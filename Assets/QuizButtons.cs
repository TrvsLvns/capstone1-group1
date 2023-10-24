using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizButtons : MonoBehaviour
{
    public QuizManager quizManager;

    public void answer(int buttonID)
    {
        quizManager.answer = buttonID;
    }
}