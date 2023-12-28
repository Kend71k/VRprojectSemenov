using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFood : MonoBehaviour
{
    // Префабы еды, которую будем спавнить
    public GameObject foodOne;
    public GameObject foodTwo;
    public GameObject foodThree;

    // Координаты центра и примерные размеры зоны спавна
    public Vector3 spawnAreaCenter;
    public Vector3 spawnAreaSize;

    // Задержка перед спавном нового объекта
    private float spawnCooldown = 10f;


    private void Update()
    {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
        {
            int randomNumber = Random.Range(1, 4);
            switch (randomNumber)
            {
                case 1: 
                    SpawnObject(foodOne, 0f);  // Спавн бутылки с водой
                    break;
                case 2:
                    SpawnObject(foodTwo, spawnAreaCenter.y); // Спавн рыбы №1
                    break;
                case 3:
                    SpawnObject(foodThree, spawnAreaCenter.y); // Спавн рыбы №2
                    break;
                default:
                    break;
            }
            spawnCooldown = 10f;
        }
    }

    void SpawnObject(GameObject objectPrefab, float y) 
    {
        // Генерируем случайные координаты внутри ограниченной зоны спавна
        float spawnPosX = Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2);
        float spawnPosZ = Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2);

        // Спавним объект на полученных координатах
        GameObject newObject = Instantiate(objectPrefab, new Vector3(spawnPosX, y, spawnPosZ), Quaternion.Euler(0, 0, 0));

        // Направляем объект вперед в сторону игрока
        newObject.transform.forward = Vector3.right;
    }
}
