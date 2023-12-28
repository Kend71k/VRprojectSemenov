using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFood : MonoBehaviour
{
    HungrySystem hungrySystem;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // ������� ������
        hungrySystem = player.GetComponent<HungrySystem>(); // �������� ��������� � �������� ������
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food")) // ���������� �� ������ � ����
        {
            hungrySystem.EatFood(); // �������� �����
            Destroy(collision.gameObject); // � ���������� ������ ���
        }
    }
}
