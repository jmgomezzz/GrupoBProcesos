using System;
using UnityEngine;

public class Key_Logic : MonoBehaviour
{
    public bool isPressed = false;
    public Open_Door1 door;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPressed)
        {
            Debug.Log("absolutely specular");

            this.GetComponent<Collider2D>().enabled = false;
            isPressed = true;
            door.plateTriggered();
        }
    }

    public void resetState()
    {
        this.GetComponent<Collider2D>().enabled = true;
        isPressed = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
