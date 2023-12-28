using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutBoard : MonoBehaviour
{
    public int damageAmount = 10; // ���������� �����, ����������� �������
    private bool hasExited = false; // ���� ��� ������������ ������ �� �����
    HealthSystem playerHealth;

    private void OnTriggerExit(Collider gameObject)
    {
        // ���������, ���� ����� ����� �� ������� �����
        if (gameObject.CompareTag("Player") && !hasExited)
        {
            hasExited = true;

            // �������� ��������� �������� ������
            playerHealth = gameObject.GetComponent<HealthSystem>();
            if (hasExited && playerHealth != null)
            {
                playerHealth.PlayerOutBoard();
            }
        }
    }

    private void OnTriggerEnter(Collider gameObject)
    {
        // ���������, ���� ����� ����� ������� �� ����
        if (gameObject.CompareTag("Player") && hasExited)
        {
            hasExited = false;
            playerHealth.PlayerOnBoard();
        }
    }
}
