using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVR : MonoBehaviour
{
    public int damageAmount = 10; // ���������� �����, ����������� �������
    private bool hasExited = false; // ���� ��� ������������ ������ �� �����
    HealthSystem playerHealth;

    private Transform raft;

    private void Start()
    {
        playerHealth = gameObject.GetComponent<HealthSystem>();
    }

    private void Update()
    {
        // ���� ����� ��������� �� �����, ��� ������� ����������� ������ � ������
        if (raft != null)
        {
            Vector3 newPosition = raft.InverseTransformPoint(transform.position);
            transform.position = raft.TransformPoint(newPosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Raft"))
        {
            // ��� ������� ����� ����� ������������ ������ � ���
            raft = other.transform;
            transform.SetParent(raft);
            hasExited = false;
            playerHealth.PlayerOnBoard();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Raft"))
        {
            // ��� ������ � ����� ����� ��������� ������������ ������ � ���
            raft = null;
            transform.SetParent(null);

            hasExited = true;
            // ��������� ������� �� ����� ����
            if (hasExited && playerHealth != null)
            {
                playerHealth.PlayerOutBoard();
            }
        }
    }
}
