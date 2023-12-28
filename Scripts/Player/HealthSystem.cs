using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f; // ������������ �������� ��������
    private float currentHealth; // ������� �������� ��������

    private float cooldownHealing = 5f; // ����������� �� ������������� �������
    private float damageCooldown = 1.5f; // ����������� �� ��������� �����
    private bool takingDamage = false; // ���� ��� ������������ ��������� �����
    private bool outBoard = false; // ���� ��� ������������ ������ �� �����

    public Image screenHealth; // UI-����������� ��������� �� �����

    void Start()
    {
        currentHealth = maxHealth; // ��������� ���������� �������� ��������
    }

    void Update()
    {
        if (currentHealth < maxHealth && !takingDamage)
        {
            currentHealth += Time.deltaTime * 10; // ���������� �������� �� ��������
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ����������� �������� �������� � �������� �� 0 �� maxHealth
        }

        float healthPercentage = currentHealth / maxHealth; // ���������� �������� ��������

        // ��������� ����� ������ � ����������� �� �������� ��������
        screenHealth.color =  new Color(1, 0, 0, 1 - healthPercentage);

        cooldownHealing -= Time.deltaTime;
        if (cooldownHealing <= 0 && takingDamage == true)
        {
            takingDamage = false;
        }

        damageCooldown -= Time.deltaTime;
        if (outBoard && damageCooldown <= 0)
        {
            TakeDamage(10f);
        }
    }

    // ���������� ����� ��� ��������� �����
    public void TakeDamage(float damage)
    {
        Debug.Log("������� ����");
        takingDamage = true;
        cooldownHealing = 5f;
        damageCooldown = 1.5f;
        currentHealth -= damage;
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    // ���������� �� "OutBoard"
    public void PlayerOutBoard()
    {
        outBoard = true;
    }

    public void PlayerOnBoard()
    {
        outBoard = false;
    }
}
