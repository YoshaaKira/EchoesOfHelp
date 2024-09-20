using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Rigidbody2D playerRB;

    [SerializeField] private float movementSpeed = 10f;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerRB = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = playerInputActions.Movement.Move.ReadValue<Vector2>();
        playerRB.velocity = moveInput * movementSpeed;
    }
}
