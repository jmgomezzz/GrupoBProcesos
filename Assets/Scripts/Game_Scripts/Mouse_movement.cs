using System;
using System.Collections;
using UnityEngine;

public class Mouse_movement : MonoBehaviour
{
    public float moveSpeed = 4f;

    public Vector2 newPos;

    private Rigidbody2D player;

    private Animator anim;

    private float posX;
    private float posY;

    [SerializeField] private float threshold = 0.1f;

    [SerializeField] private float animationTransitionDelay = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newPos = transform.position;
        posX = transform.position.x;
        posY = transform.position.y;
        anim = GetComponent<Animator>();
    }
    public void moveInstantly(Vector2 teleportPos)
    {
        newPos = teleportPos;
        transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //mousePosition esta en coordenadas de camara, se pasan a coords de mundo con "ScreenToWorldPoint"
            newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            anim.SetBool("Moving", false);
            StartCoroutine(WaitForChange());
            
        }
        transform.position = Vector2.MoveTowards(transform.position,newPos,moveSpeed*Time.deltaTime);

        posX = transform.position.x;
        posY = transform.position.y;

        if (Math.Abs(posX-newPos.x)<threshold && Math.Abs(posY - newPos.y) < threshold)
        {
            moveInstantly(newPos);
            anim.SetBool("Moving", false);
        }
        
    }

    IEnumerator WaitForChange()
    {
        yield return new WaitForSeconds(animationTransitionDelay);
        checkDirection();
    }
    private void checkDirection()
    {
        //Resetear valores de direccion
        anim.SetBool("Left",false);
        anim.SetBool("Right", false);
        anim.SetBool("Up", false);
        anim.SetBool("Down", false);

        float diffX = Math.Abs(transform.position.x - newPos.x);
        float diffY = Math.Abs(transform.position.y - newPos.y);

        if(newPos.x-transform.position.x <0 && diffX > diffY)
        {
            anim.SetBool("Left", true);
        }
        else if(newPos.x - transform.position.x > 0 && diffX > diffY)
        {
            anim.SetBool("Right", true);
        }
        else if (newPos.y - transform.position.y < 0 && diffX < diffY)
        {
            anim.SetBool("Down", true);
        }
        else if (newPos.y - transform.position.y > 0 && diffX < diffY)
        {
            anim.SetBool("Up", true);
        }

        anim.SetBool("Moving", true);
    }
}
