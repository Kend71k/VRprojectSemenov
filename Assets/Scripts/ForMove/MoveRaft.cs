using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRaft : MonoBehaviour
{
    public float speed = 1f;     // скорость передвижения

    public float speedBoost = 1f;

    public Vector3 rotation = new Vector3(0, 0, 0);
    public Vector3 direction = Vector3.forward;    // направление движения

    GameObject[] rocks; // Получаем список всех объектов с тегом "Rock"

    private bool turning = false;
    private bool isSunk = false;
    private bool stopTurnSunking = false;

    private void Start()
    {
        rocks = GameObject.FindGameObjectsWithTag("Rock");
    }

    private void Update()
    {
        // Проходимся по каждому объекту и проверяем расстояние между ним и текущим объектом
        if (!isSunk)
        {
            foreach (GameObject rock in rocks)
            {
                float distance = Vector3.Distance(transform.position, rock.transform.position);

                // Если расстояние меньше указанной величины, переворачиваем объект
                if (distance < rock.transform.localScale.x*0.9f)
                {
                    StopMoving();
                    break; // Прерываем цикл, чтобы не проверять оставшиеся объекты
                }
            }
        }
        transform.Translate(direction * speed * speedBoost * Time.deltaTime);
        transform.Rotate(rotation * Time.deltaTime);
        // если перестали использовать весло, то разворачиваем плот ровно к берегу
        if (!turning)
        {
            if (transform.rotation.y < 0)
                rotation = new Vector3(0, 10, 0);
            else if (transform.rotation.y > 0)
                rotation = new Vector3(0, -10, 0);
            else
                rotation = new Vector3(0, 0, 0);
        }
        if (!stopTurnSunking && transform.rotation == Quaternion.Euler(-70, 0, 0))
        {
            direction = new Vector3(0, -0.2f, -1);
            speed = 1f;
            speedBoost = 0.5f;
            stopTurnSunking = true;
            rotation = new Vector3(0, 0, 0);
        }
        if (transform.position.y <= -2)
            Destroy(gameObject);
    }

    // Если гребем веслом с правой стороны
    public void MoveLeft()
    {
        if (!isSunk)
        {
            turning = true;
            rotation = new Vector3(0, -10, 0);
            direction = new Vector3(-0.5f, 0, 2);
            speedBoost = 4f;
        }

    }

    // Если гребем веслом с левой стороны
    public void MoveRight()
    {
        if (!isSunk)
        {
            turning = true;
            rotation = new Vector3(0, 10, 0);
            direction = new Vector3(0.5f, 0, 2);
            speedBoost = 4f;
        }

    }
    
    // Если перестали грести
    public void StopManeuver()
    {
        if (!isSunk)
        {
            turning = false;
            direction = new Vector3(0, 0, 1);
            speedBoost = 2f;
        }

    }

    public void StopMoving()
    {
        isSunk = true;
        Debug.Log("Я остановился");
        direction = Vector3.down;
        speed = 0.5f;
        speedBoost = 0.5f;
        rotation = new Vector3(-10, 0, 0);
        turning = true;
    }

    // Чтобы объекты передвигались вместе с плотом
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Rock") // Переворачиваем и топим плот, если он столкнулся со скалой
        //{
        //    Debug.Log("Столкновение");
        //    StopMoving();
        //    // Переворачиваем объект
        //    transform.Rotate(Vector3.up, 180f);
        //    transform.Translate(Vector3.down * 1f);
        //}
        //else
        collision.transform.parent = transform;
    }

    // Чтобы объекты перестали передвигаться вместе с плотом, если спрыгнули с него
    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Rock") // Проверка на столкновение со скалой
    //    {
    //        StopMoving();
    //        // Переворачиваем объект
    //        transform.Rotate(Vector3.up, 180f);
    //        transform.Translate(Vector3.down * 1f);
    //    }

    //}
}
