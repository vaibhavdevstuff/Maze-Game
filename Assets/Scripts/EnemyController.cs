using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float moveSpeed = 5f;

    private float moveX;
    private float moveZ;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (playerController == null)
        {
            Debug.LogError("Player Controller on found on " + this.gameObject.name, this.gameObject);
        }
        else
        {
            //Enemy have to move invertly of player
            moveSpeed = playerController.MoveSpeed * -1;
        }
    }

    private void Update()
    {
        UpdateInput();
        UpdateMovement();
    }

    private void UpdateInput()
    {
        if (GameManager.Instance.GameEnd) return;

        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
    }

    private void UpdateMovement()
    {
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);

        rb.velocity = moveSpeed * moveDirection;
    }






}//class
