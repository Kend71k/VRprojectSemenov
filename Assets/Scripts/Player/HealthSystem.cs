using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f; // Максимальное значение здоровья
    private float currentHealth; // Текущее значение здоровья

    private float cooldownHealing = 5f; // перезарядка на возобновление лечения
    private float damageCooldown = 1.5f; // Перезарядка на нанесение урона
    private bool takingDamage = false; // Флаг для отслеживания получения урона
    private bool outBoard = false; // Флаг для отслеживания выхода из плота

    public Image screenHealth; // UI-изображение наложения на экран

    void Start()
    {
        currentHealth = maxHealth; // Установка начального значения здоровья
    }

    void Update()
    {
        if (currentHealth < maxHealth && !takingDamage)
        {
            currentHealth += Time.deltaTime * 10; // Увеличение здоровья со временем
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ограничение значения здоровья в пределах от 0 до maxHealth
        }

        float healthPercentage = currentHealth / maxHealth; // Вычисление процента здоровья

        // Изменение цвета экрана в зависимости от значения здоровья
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

    // Вызываемый метод для нанесения урона
    public void TakeDamage(float damage)
    {
        Debug.Log("получаю урон");
        takingDamage = true;
        cooldownHealing = 5f;
        damageCooldown = 1.5f;
        currentHealth -= damage;
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    // Вызываются из "OutBoard"
    public void PlayerOutBoard()
    {
        outBoard = true;
    }

    public void PlayerOnBoard()
    {
        outBoard = false;
    }
}
