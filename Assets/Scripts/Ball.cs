using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    private Vector2 firstPos;
    private Vector2 secondPos;
    private Vector2 currentPos;
    public float moveSpeed;
    public float currentGround1Number;
    public float currentGround2Number;
    public float currentGround3Number;
    private GameManager gm;
    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }
    void Update()
    {
        Swipe();
        if (currentGround1Number == 40)
        {
            gm.LevelUpdate();
        }
        else if (currentGround2Number == 38)
        {
            gm.LevelUpdate();
        }
        else if(currentGround3Number == 46)
        {
            gm.LevelUpdate();
        }
    }
    private void Swipe()
    {
        /*if (Input.GetMouseButton(0))
        {
            firstPos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));           
        }
        else 
        {
            secondPos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            currentPos = new Vector2(
                secondPos.x - firstPos.x,
                secondPos.y - firstPos.y
                );
        }*/
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentPos = new Vector2(
                secondPos.x - firstPos.x,
                secondPos.y - firstPos.y
                );
        }
        currentPos.Normalize();

        if(currentPos.y<0 && currentPos.x>-0.5f && currentPos.x < 0.5f)
        {
            rb.velocity = Vector3.back * moveSpeed;
        }
        else if (currentPos.y > 0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            rb.velocity = Vector3.forward * moveSpeed;
        }
        else if (currentPos.x < 0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            rb.velocity = Vector3.left * moveSpeed;
        }
        else if (currentPos.x > 0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            rb.velocity = Vector3.right * moveSpeed;
        }

        /*if (Input.GetMouseButton(0))
        {
            if (Mathf.Abs(Input.GetAxis("Mouse X")) > Mathf.Abs(Input.GetAxis("Mouse Y")))
            {
                if (Input.GetAxis("Mouse X") < -0.1f)
                {
                    //Left
                    rb.velocity = Vector3.left * moveSpeed;
                }
                else if (Input.GetAxis("Mouse X") > 0.1f)
                {
                    //Right
                    rb.velocity = Vector3.right * moveSpeed;
                }
            }
            else
            {
                if (Input.GetAxis("Mouse Y") > 0.1f && Input.GetAxis("Mouse Y") > 0.1f)
                {
                    //Forward
                    rb.velocity = Vector3.forward * moveSpeed;
                }
                else if (Input.GetAxis("Mouse Y") < -0.1f)
                {
                    //Back
                    rb.velocity = Vector3.back * moveSpeed;
                }
            }
        
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<MeshRenderer>().material.color != Color.red)
        {
            if (other.gameObject.tag == "Ground")
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                currentGround1Number++;
            }
        }
        if(other.gameObject.GetComponent<MeshRenderer>().material.color != Color.green)
        {
            if (other.gameObject.tag == "Ground2")
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                currentGround2Number++;
            }
        }
        if (other.gameObject.GetComponent<MeshRenderer>().material.color != Color.blue)
        {
            if (other.gameObject.tag == "Ground3")
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                currentGround3Number++;
            }
            
        }



    }
}
