using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungrySystem : MonoBehaviour
{
    public float maxHunger = 100f; // Максимальное значение голода
    public float hungerDecreaseRate = 0.3f; // Скорость уменьшения голода в секунду
    public float hungerIncreaseAmount = 20f; // Количество голода, восполняемое при поедании еды
    public Image screenHungry; // UI-изображение наложения на экран

    private float currentHunger; // Текущее значение голода

    private void Start()
    {
        currentHunger = maxHunger;
    }

    private void Update()
    {
        DecreaseHunger();
        UpdateScreenColor();
    }

    private void DecreaseHunger()
    {
        currentHunger -= hungerDecreaseRate * Time.deltaTime;

        if (currentHunger < 0f)
        {
            currentHunger = 0f;
            // Смерть от голода при голоде до нуля
            Destroy(gameObject);
        }
    }

    public void EatFood()
    {
        currentHunger += hungerIncreaseAmount;

        if (currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
        }
    }

    private void UpdateScreenColor()
    {
        float normalizedHunger = currentHunger / maxHunger;
        screenHungry.color = new Color(1f, 1f, 1f, 1f - normalizedHunger);
    }
}
