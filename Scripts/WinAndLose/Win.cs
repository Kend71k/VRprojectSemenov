using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, пересек ли объект область и тег совпадает
        {
            SceneManager.LoadScene("ScreenWin"); // Загружаем указанную сцену
        }
    }
}
