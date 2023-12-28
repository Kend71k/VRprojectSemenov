using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutBoard : MonoBehaviour
{
    public int damageAmount = 10; // Количество урона, получаемого игроком
    private bool hasExited = false; // Флаг для отслеживания выхода из плота
    HealthSystem playerHealth;

    private void OnTriggerExit(Collider gameObject)
    {
        // Проверяем, если игрок вышел за пределы плота
        if (gameObject.CompareTag("Player") && !hasExited)
        {
            hasExited = true;

            // Получаем компонент здоровья игрока
            playerHealth = gameObject.GetComponent<HealthSystem>();
            if (hasExited && playerHealth != null)
            {
                playerHealth.PlayerOutBoard();
            }
        }
    }

    private void OnTriggerEnter(Collider gameObject)
    {
        // Проверяем, если игрок зашел обратно на плот
        if (gameObject.CompareTag("Player") && hasExited)
        {
            hasExited = false;
            playerHealth.PlayerOnBoard();
        }
    }
}
