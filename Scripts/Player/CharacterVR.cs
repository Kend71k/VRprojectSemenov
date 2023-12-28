using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVR : MonoBehaviour
{
    public int damageAmount = 10; // Количество урона, получаемого игроком
    private bool hasExited = false; // Флаг для отслеживания выхода из плота
    HealthSystem playerHealth;

    private Transform raft;

    private void Start()
    {
        playerHealth = gameObject.GetComponent<HealthSystem>();
    }

    private void Update()
    {
        // Если игрок находится на плоте, его позиция обновляется вместе с плотом
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
            // При касании плота игрок перемещается вместе с ней
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
            // При выходе с плота игрок перестает перемещаться вместе с ней
            raft = null;
            transform.SetParent(null);

            hasExited = true;
            // Проверяем покинул ли игрок плот
            if (hasExited && playerHealth != null)
            {
                playerHealth.PlayerOutBoard();
            }
        }
    }
}
