using UnityEngine;

namespace WelcomeToHell
{
    public class ClickToMove : MonoBehaviour
    {
        [SerializeField] private CharacterController charController;
        [SerializeField] private float speed;
        private Vector3 position;
        
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                LocatePosition();
            }
            MoveToPosition();
        }
        private void LocatePosition()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit))
            {
                position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }
        private void MoveToPosition()
        {
            Quaternion angle = Quaternion.LookRotation(position - transform.position, Vector3.forward);
            angle.x = 0;
            angle.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, angle, Time.deltaTime * 10);
            charController.Move(Vector3.forward * speed * Time.deltaTime);
        }
    }
}