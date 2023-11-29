using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI ShopPointsTxt;
    public TextMeshProUGUI HealthCostTxt;
    public TextMeshProUGUI DamageCostTxt;

    public int points;
    private int healthCost = 1;
    private int damageCost = 1;

    public int getHealthCost()
    {
        return healthCost;
    }

    public int getDamageCost()
    {
        return damageCost;
    }

    public void increaseHealth()
    {
        if (points >= healthCost) 
        {
            //Call function to increase health
            points -= healthCost;
            healthCost += 1;
            ShopPointsTxt.text = "Points: " + points;
            HealthCostTxt.text = "Cost: " + healthCost;
        }
    }

    public void increaseDamage()
    {
        if (points >= damageCost)
        {
            //Call function to increase gun damage
            points -= damageCost;
            damageCost += 1;
            ShopPointsTxt.text = "Points: " + points;
            DamageCostTxt.text = "Cost: " + damageCost;
        }
    }
}
