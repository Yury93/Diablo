using UnityEngine;


public class MovementController
{
    private CharacterController charController;
    private float speedMove;
    private Transform myTransform;
    private Vector3 newPosition;

    public MovementController(CharacterController characterController, float speedMove)
    {
        this.charController = characterController;
        this.speedMove = speedMove;
    }

    public bool LocatePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool MoveToPosition(Transform myTransform, float distanceToTarget)
    {
        this.myTransform = myTransform;

        Vector3 direction = newPosition - myTransform.position;
        if (direction.magnitude > distanceToTarget)
        {
            direction.y = 0;
            direction.Normalize();
            charController.Move(direction * speedMove * Time.deltaTime);
            RotateToPosition(direction);
            return true;
        }
        else
        {
            StopMoving();
            return false;
        }
    }
    private void StopMoving()
    {
        Debug.Log("Stop");
    }
    private void RotateToPosition(Vector3 lookDirection)
    {
        myTransform.rotation = Quaternion.LookRotation(lookDirection);
    }
}

