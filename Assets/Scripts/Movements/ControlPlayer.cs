using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlPlayer : MonoBehaviour
{
    private Movimiento movement;
    private Vector2 entryKeyMovement;
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        movement = GetComponent<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInX = Input.GetAxis("Horizontal");
        bool isMoving = !Mathf.Approximately(moveInX, 0f);
        animator.SetBool("isMoving", isMoving);
        movement.MoveOnX(entryKeyMovement.x);       
    }
    public void toMove(InputAction.CallbackContext input)
    {
        entryKeyMovement = input.ReadValue<Vector2>();
    }
      
    public void toJump(InputAction.CallbackContext input)
    {
        movement.Saltar(input.action.triggered);
    }
}
