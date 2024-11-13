using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_rigidBody;

    [SerializeField]
    private int movementForce;

    [SerializeField]
    private int jumpForce;

    [SerializeField]
    private int rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        //cube flips for some reason
        m_rigidBody.AddForce(transform.forward * movementForce);


        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotationSpeed, 0 * Time.deltaTime);
            //Debug.Log("Left");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotationSpeed, 0 * Time.deltaTime);
            //Debug.Log("Right");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            m_rigidBody.AddForce(transform.up * jumpForce);
        }
        else
        {
            return;
        }
    }
}
