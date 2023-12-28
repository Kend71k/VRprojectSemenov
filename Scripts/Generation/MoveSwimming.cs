using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSwimming : MonoBehaviour
{
    public float speed = 0.5f;     // скорость передвижения
    public Vector3 direction = Vector3.forward;    // направление движения

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rock")
            Destroy(gameObject);
    }
}
