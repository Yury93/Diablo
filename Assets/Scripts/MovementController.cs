using UnityEngine;


namespace FightSystem
{
    public class MovementController
    {
        private CharacterController charController;
        private float speedMove;
        private Transform myTransform;
        private Vector3 newPosition;
        public StateMove GetStateMove { get; private set; }
        public enum StateMove
        {
            moving,
            stopMoving
        }
        public MovementController(CharacterController characterController)
        {
            this.charController = characterController;
        }

        public void LocatePosition(Transform myTransform, float distanceToTarget, float speed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    this.speedMove = speed;
                    newPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    GetStateMove = StateMove.moving;
                }

            }
            if (GetStateMove == StateMove.moving)
            {
                this.myTransform = myTransform;
                MoveToPosition(distanceToTarget);
            }
        }
        public void LocatePositionTarget(Transform myTransform,Vector3 target, float distanceToTarget, float speed)
        {
            newPosition = target;
            if (GetStateMove == StateMove.moving)
            {
                this.myTransform = myTransform;
                MoveToPosition(distanceToTarget);
            }
        }
        private bool MoveToPosition(float distanceToTarget)
        {
            Vector3 direction = newPosition - myTransform.position;
            if (direction.magnitude >= distanceToTarget)
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
            GetStateMove = StateMove.stopMoving;
            Debug.Log("Stop");
        }
        public void RotateToPosition(Vector3 lookDirection)
        {
            myTransform.rotation = Quaternion.RotateTowards(myTransform.rotation, Quaternion.LookRotation(lookDirection), 1f);
        }
    }
}