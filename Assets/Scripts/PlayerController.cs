using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    [SerializeField] private float speed = 8.0f;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0, v);
        playerRigidBody.velocity = movement * speed;
    }

    // -----------------------------------------------------------------------------
    // Custom methods
    // -----------------------------------------------------------------------------
    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
