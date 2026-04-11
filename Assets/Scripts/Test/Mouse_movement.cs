using System;
using UnityEngine;

public class Mouse_movement : MonoBehaviour
{
    public float moveSpeed = 4f;

    public Vector2 newPos;

    private Rigidbody2D player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //mousePosition esta en coordenadas de camara, se pasan a coords de mundo con "ScreenToWorldPoint"
            newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        transform.position = Vector2.MoveTowards(transform.position,newPos,moveSpeed*Time.deltaTime);
    }
}
