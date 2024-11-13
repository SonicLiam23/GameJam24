using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_rigidBody;

    public const int DefaultMovementSpeed = 100;

    [SerializeField]
    public int movementSpeed;

    [SerializeField]
    private int jumpForce, ChangeLaneSpeed;

    [SerializeField]
    private int rotationSpeed;

    int Lane;
    bool MoveLeft, MoveRight;
    // Start is called before the first frame update
    void Start()
    {
        MoveLeft = false; MoveRight = false;
        Lane = 0;
        m_rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        MoveLR();
    }


    void MoveForward()
    {
        //cube flips for some reason
        m_rigidBody.velocity = Vector3.forward * movementSpeed;
        
        


    }

    void MoveLR()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Lane != -1)
        {
            Lane--;
            MoveLeft = true;
            //Debug.Log("Left");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && Lane != 1)
        {
            Lane++;
            MoveRight = true;
            //Debug.Log("Right");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            m_rigidBody.AddForce(transform.up * jumpForce);
        }



        
        if (MoveLeft)
        {
            Vector3 NewPos = transform.position;
            NewPos.x -= 20;
            float step = ChangeLaneSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, NewPos, step);

            if (transform.position.x <= Lane * 20)
            {
                MoveLeft = false;
            }
        }
        else if (MoveRight)
        {
            Vector3 NewPos = transform.position;    
            NewPos.x += 20;
            float step = ChangeLaneSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, NewPos, step);

            if (transform.position.x >= Lane * 20)
            {
                MoveRight = false;
            }
        }
    }
}
