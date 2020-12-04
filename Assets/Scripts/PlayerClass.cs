using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    private int numberOfFlowers = 0;
    private int basketValue = 0;
    private int flowerType = 0;

    public int BasketValue
    {
        get
        {
            return basketValue;
        }
    }

    public int NumberOfFlowers
    {
        get
        {
            return numberOfFlowers;
        }
    }

    public int FlowerType
    {
        get
        {
            return flowerType;
        }

        set
        {
            flowerType = value;
        }
    }

    public void AddToBasket(int value)
    {
        basketValue += value;
        numberOfFlowers++;
    }

    public void ClearBasket()
    {
        basketValue = 0;
        numberOfFlowers = 0;
        flowerType = 0;
    }

    public void DisplayBasket()
    {
        Debug.Log("Chomper has " + numberOfFlowers + " flower(s) worth "
                  + flowerType + " each, with " + basketValue + " in total.");
    }
}
