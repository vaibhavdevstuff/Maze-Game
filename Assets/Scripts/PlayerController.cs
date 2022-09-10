using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;

    [SerializeField] Transform[] spawnPosition;

    private float moveX;
    private float moveZ;

    Rigidbody rb;

    public float MoveSpeed { get { return moveSpeed; } }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        SetRandomSpawnPosition();
    }

    private void SetRandomSpawnPosition()
    {
        Vector3 spawnPos = spawnPosition[Random.Range(0, spawnPosition.Length)].position;

        transform.position = spawnPos;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WinArea"))
        {
            GameManager.Instance.GameWin();
        }
    }




















}
