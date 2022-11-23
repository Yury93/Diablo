using UnityEngine;

namespace FightSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterController charController;
        [SerializeField] private float moveSpeed;
        private MovementController movementController;
        private void Start()
        {
            charController = GetComponent<CharacterController>();
            movementController = new MovementController(charController);
        }
        private void Update()
        {
            movementController.LocatePosition(transform, 1, moveSpeed);
        }
    }
}