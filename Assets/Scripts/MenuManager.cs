using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public QuizManager quizManager;

    [SerializeField]
    Canvas _canvas_0;
    [SerializeField]
    Canvas _canvas_1;
    [SerializeField]
    Canvas _canvas_2;
    [SerializeField]
    Canvas _canvas_3;
    [SerializeField]
    Canvas _canvas_4;

    [SerializeField]
    GameObject _backgroundPanel;

    public ShopManager shopManager;
    public TextMeshProUGUI MenuPointsTxt;
    public TextMeshProUGUI ShopPointsTxt;
    public TextMeshProUGUI HealthCostTxt;
    public TextMeshProUGUI DamageCostTxt;

    [SerializeField]
    Button _continueButton;
    [SerializeField]
    Button _submitButton;

    public enum MenuScreenType
    {
        canvas_zero,
        canvas_one,
        canvas_two,
        canvas_three_submit,
        canvas_three_continue,
        canvas_four,
        close
    }

    [HideInInspector]
    public MenuScreenType menuScreenType;

    public void showScreen(MenuScreenType type)
    {
        menuScreenType = type;
        switch (type)
        {
            case MenuScreenType.canvas_zero:
                MenuPointsTxt.text = "Points: " + shopManager.points;
                _canvas_0.gameObject.SetActive(true);
                _canvas_1.gameObject.SetActive(false);
                _canvas_2.gameObject.SetActive(false);
                _canvas_3.gameObject.SetActive(false);
                _canvas_4.gameObject.SetActive(false);
                _submitButton.gameObject.SetActive(false);
                _continueButton.gameObject.SetActive(false);
                break;
            case MenuScreenType.canvas_one:
                _canvas_0.gameObject.SetActive(false);
                _canvas_1.gameObject.SetActive(true);
                _canvas_2.gameObject.SetActive(false);
                _canvas_3.gameObject.SetActive(false);
                _canvas_4.gameObject.SetActive(false);
                _submitButton.gameObject.SetActive(false);
                _continueButton.gameObject.SetActive(false);
                break;
            case MenuScreenType.canvas_two:
                _canvas_0.gameObject.SetActive(false);
                _canvas_1.gameObject.SetActive(false);
                _canvas_2.gameObject.SetActive(true);
                _canvas_3.gameObject.SetActive(false);
                _canvas_4.gameObject.SetActive(false);
                _submitButton.gameObject.SetActive(false);
                _continueButton.gameObject.SetActive(false);
                break;
            case MenuScreenType.canvas_three_submit:
                _canvas_0.gameObject.SetActive(false);
                _canvas_1.gameObject.SetActive(false);
                _canvas_2.gameObject.SetActive(false);
                _canvas_3.gameObject.SetActive(true);
                _canvas_4.gameObject.SetActive(false);
                _submitButton.gameObject.SetActive(true);
                _continueButton.gameObject.SetActive(false);
                break;
            case MenuScreenType.canvas_three_continue:
                _canvas_0.gameObject.SetActive(false);
                _canvas_1.gameObject.SetActive(false);
                _canvas_2.gameObject.SetActive(false);
                _canvas_3.gameObject.SetActive(true);
                _canvas_4.gameObject.SetActive(false);
                _submitButton.gameObject.SetActive(false);
                _continueButton.gameObject.SetActive(true);
                break;
            case MenuScreenType.canvas_four:
                ShopPointsTxt.text = "Points: " + shopManager.points;
                HealthCostTxt.text = "Cost: " + shopManager.getHealthCost();
                DamageCostTxt.text = "Cost: " + shopManager.getDamageCost();
                _canvas_0.gameObject.SetActive(false);
                _canvas_1.gameObject.SetActive(false);
                _canvas_2.gameObject.SetActive(false);
                _canvas_3.gameObject.SetActive(false);
                _canvas_4.gameObject.SetActive(true);
                _submitButton.gameObject.SetActive(false);
                _continueButton.gameObject.SetActive(false);
                break;
            default:
                _canvas_0.gameObject.SetActive(false);
                _canvas_1.gameObject.SetActive(false);
                _canvas_2.gameObject.SetActive(false);
                _canvas_3.gameObject.SetActive(false);
                _canvas_4.gameObject.SetActive(false);
                _submitButton.gameObject.SetActive(false);
                _continueButton.gameObject.SetActive(false);
                _backgroundPanel.gameObject.SetActive(false);
                break;
        }
    }

    public void Start()
    {
        showScreen(MenuScreenType.close);
    }

    public void exitClicked()
    {
        showScreen(MenuScreenType.close);
        Time.timeScale = 1f;
    }

    public void difficultyClicked(string difficulty)
    {
        quizManager.setDifficulty(difficulty);
        showScreen(MenuScreenType.canvas_two);
    }

    public void backToZero()
    {

        showScreen(MenuScreenType.canvas_zero);
    }

    public void backToOne()
    {
        
        showScreen(MenuScreenType.canvas_one);
    }

    public void onCollision()
    {
        Time.timeScale = 0f;
        _backgroundPanel.gameObject.SetActive(true);
        showScreen(MenuScreenType.canvas_zero);
    }

    public void openQuiz()
    {
        showScreen(MenuScreenType.canvas_one);
    }

    public void openShop()
    {
        showScreen(MenuScreenType.canvas_four);
    }
}