using UnityEngine;

using Project.Input;
using Project.Tools;

namespace Project.Core
{
    public class SpaceShip : DestroyableObject
    {
        [SerializeField]
        private Gun myGun;

        private IInputGiver input;

        private Vector2 direction;

        protected override void Awake()
        {
            base.Awake();

            input = GetComponentInChildren<IInputGiver>();

            if (input == null)
                Debug.LogError($"{gameObject.name} can't find IInputGiver in Children");
        }

        protected virtual void Update()
        {
            transform.Rotate(new Vector3(0, 0, -input.Rotation * SO.RotationSpeed));

            if (input.Acceleration)
                direction = Trigonometry.UnityDegreeToVector2(transform.eulerAngles.z);

            if (input.Fire)
                myGun.Fire();
        }

        protected override void FixedUpdate()
        {
            if (input.Acceleration && rb2d.velocity.x * rb2d.velocity.x + rb2d.velocity.y * rb2d.velocity.y < SO.MaxSpeed)
                rb2d.AddForce(SO.Speed * Time.deltaTime * direction);
        }
    }
}
