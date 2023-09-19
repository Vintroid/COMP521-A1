using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    // How fast the character will move along the map
    [SerializeField] public float speed;
    [SerializeField] public GameObject cam;
    [SerializeField] public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        // Updating the player's position depending on keyboard inputs and speed.
        // Camera transform is used so that player movement follow camera movement.
        // Y component of camera is subtracted so that the player does not ascend or descend while moving.
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(rb.transform.position + (cam.transform.forward - new Vector3(0,cam.transform.forward.y,0)) * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(rb.transform.position - (cam.transform.forward - new Vector3(0, cam.transform.forward.y, 0)) * Time.deltaTime * speed);
        }

        // Rotating player with keys A & D.
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(rb.transform.position + cam.transform.right* Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.A)) 
        {
            rb.MovePosition(rb.transform.position - cam.transform.right* Time.deltaTime * speed);
        }
    }
}
