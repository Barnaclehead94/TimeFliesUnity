using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_movementGrid : MonoBehaviour
{
    Vector3 up = new Vector3(0f, 0.5f, 0f),
    right = new Vector3(0, 90, 0),
    down = new Vector3(0, 180, 0),
    left = new Vector3(0, 270, 0),
    currentDirection = Vector3.zero;

    Vector3 nextPos, destination, direction;

    float speed = 5f;
    bool canMove;
    float rayLength = 1f;
    



    // Start is called before the first frame update
    void Start()
    {
        currentDirection = up;
        nextPos = Vector3.forward;
        destination = new Vector3(0,0.5f,0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();   

    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            nextPos = Vector3.forward;
            currentDirection = up;
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            nextPos = Vector3.back;
            currentDirection = down;
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {           
            nextPos = Vector3.left;
            currentDirection = left;
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            nextPos = Vector3.right;
            currentDirection = right;
            canMove = true;
        }



            if (Vector3.Distance(destination, transform.position) <= 0.0001f)
            {
                transform.localEulerAngles = currentDirection;
            if (canMove)
            {
                if (Valid())
                {
                    destination = transform.position + nextPos;
                    currentDirection = nextPos;
                    canMove = false;
                }
                
            }
            
            }

    }

    bool Valid()
    {
        Ray myRay = new Ray(transform.position + new Vector3(0, 0, 0), transform.forward);

        RaycastHit myHit;

        Debug.DrawRay(myRay.origin, myRay.direction, Color.red);

        if (Physics.Raycast(myRay, out myHit, rayLength))
        {
            if(myHit.collider.tag == "Wall")
            {
                return false;
            }
        }
        return true;
    }




}


