using System.Collections;
using UnityEngine;

public class Player_movement : MonoBehaviour { 
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
}


                    