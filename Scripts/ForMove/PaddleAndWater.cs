using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAndWater : MonoBehaviour
{
    public GameObject raft;
    private GameObject paddle;

    MoveRaft moveRaft;

    private bool paddleUsing = false;
    private void Start()
    {
        moveRaft = raft.GetComponent<MoveRaft>();
        paddle = GameObject.FindGameObjectWithTag("Paddle");
    }

    private void Update()
    {
        if (paddleUsing)
        {
            if (Vector3.Distance(paddle.gameObject.transform.position, raft.transform.position) < 5f) // ѕроверка на рассто€ние от плота
            {
                // ѕровер€ем с какой стороны от плота работают веслом
                if (paddle.gameObject.transform.position.x < raft.transform.position.x)
                    moveRaft.MoveRight();
                else
                    moveRaft.MoveLeft();
            }
            else
            {
                moveRaft.StopManeuver();
                paddleUsing = false;
            }
        }
        if (Vector3.Distance(paddle.gameObject.transform.position, raft.transform.position) < 5f && (paddle.gameObject.transform.position.y - gameObject.transform.position.y) < 0.1f)
        {
            if (paddle.gameObject.transform.position.x < raft.transform.position.x)
                moveRaft.MoveRight();
            else
                moveRaft.MoveLeft();
        }
        else
        {
            moveRaft.StopManeuver();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // ѕровер€ем соприкосновение с веслом
        if (collision.gameObject.CompareTag("Paddle"))
        {
            paddle = collision.gameObject;
            paddleUsing = true;
            //if (Vector3.Distance(collision.gameObject.transform.position, raft.transform.position) < 3f) // ѕроверка на рассто€ние от плота
            //{
            //    // ѕровер€ем с какой стороны от плота работают веслом
            //    if (collision.gameObject.transform.position.x < raft.transform.position.x)
            //        moveRaft.MoveRight();
            //    else
            //        moveRaft.MoveLeft();
            //}
            //else
            //    moveRaft.StopManeuver();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            moveRaft.StopManeuver();
            paddleUsing = false;
        }
    }
}
