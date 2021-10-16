using UnityEngine;

using Project.Input;
using Project.Tools;

namespace Project.Core
{
    public class SpaceShip : DestroyableObject
    {
        //public Gun MyGun;

        private int MaxSpeed;
        private IInputGiver Input;

        protected override void Awake()
        {
            base.Awake();

            Input = GetComponentInChildren<IInputGiver>();

            if (Input == null)
                Debug.LogError($"{gameObject.name} can't find IInputGiver in Children");
        }

        protected virtual void Update()
        {
            transform.Rotate(new Vector3(0, 0, -Input.Rotation * SO.RotationSpeed));

            MaxSpeed = Input.Acceleration ? SO.MaxSpeed : SO.Speed;

            //if (Input.Fire)
            //    Gun.Fire();
        }

        protected override void FixedUpdate()
        {
            if (rb2d.velocity.x * rb2d.velocity.x + rb2d.velocity.y * rb2d.velocity.y < MaxSpeed)
                rb2d.AddForce(SO.Speed * Time.deltaTime * 100 * Trigonometry.RotationToVector2(transform.rotation.eulerAngles.z));
        }
    }
}
