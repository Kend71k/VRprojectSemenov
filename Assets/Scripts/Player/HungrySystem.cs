using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungrySystem : MonoBehaviour
{
    public float maxHunger = 100f; // ������������ �������� ������
    public float hungerDecreaseRate = 0.3f; // �������� ���������� ������ � �������
    public float hungerIncreaseAmount = 20f; // ���������� ������, ������������ ��� �������� ���
    public Image screenHungry; // UI-����������� ��������� �� �����

    private float currentHunger; // ������� �������� ������

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
            // ������ �� ������ ��� ������ �� ����
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
