using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterController charController;
    [SerializeField] private float moveSpeed;
    private MovementController movementController;
    private void Start()
    {
        movementController = new MovementController(charController, moveSpeed);
    }
    public IEnumerator MoveToPosition()
    {
        while(movementController.LocatePosition())
        {

        }

        yield return null;
    }

}
