using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideRock : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Rock") // �������������� � ����� ����, ���� �� ���������� �� ������
        {
            GameObject raft = GameObject.FindGameObjectWithTag("Raft");
            MoveRaft moveRaft = raft.GetComponent<MoveRaft>();
            moveRaft.StopMoving();
            // �������������� ������
            raft.transform.Rotate(Vector3.up, 180f);
            raft.transform.Translate(Vector3.down * 1f);
        }
    }
}
