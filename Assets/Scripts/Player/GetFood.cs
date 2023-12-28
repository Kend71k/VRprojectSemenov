using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFood : MonoBehaviour
{
    HungrySystem hungrySystem;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Находим игрока
        hungrySystem = player.GetComponent<HungrySystem>(); // Получаем компонент с системой голода
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food")) // Столкнулся ли объект с едой
        {
            hungrySystem.EatFood(); // Вызываем метод
            Destroy(collision.gameObject); // И уничтожаем объект еды
        }
    }
}
