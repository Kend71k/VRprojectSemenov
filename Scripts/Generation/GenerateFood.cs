using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFood : MonoBehaviour
{
    // ������� ���, ������� ����� ��������
    public GameObject foodOne;
    public GameObject foodTwo;
    public GameObject foodThree;

    // ���������� ������ � ��������� ������� ���� ������
    public Vector3 spawnAreaCenter;
    public Vector3 spawnAreaSize;

    // �������� ����� ������� ������ �������
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
                    SpawnObject(foodOne, 0f);  // ����� ������� � �����
                    break;
                case 2:
                    SpawnObject(foodTwo, spawnAreaCenter.y); // ����� ���� �1
                    break;
                case 3:
                    SpawnObject(foodThree, spawnAreaCenter.y); // ����� ���� �2
                    break;
                default:
                    break;
            }
            spawnCooldown = 10f;
        }
    }

    void SpawnObject(GameObject objectPrefab, float y) 
    {
        // ���������� ��������� ���������� ������ ������������ ���� ������
        float spawnPosX = Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2);
        float spawnPosZ = Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2);

        // ������� ������ �� ���������� �����������
        GameObject newObject = Instantiate(objectPrefab, new Vector3(spawnPosX, y, spawnPosZ), Quaternion.Euler(0, 0, 0));

        // ���������� ������ ������ � ������� ������
        newObject.transform.forward = Vector3.right;
    }
}
