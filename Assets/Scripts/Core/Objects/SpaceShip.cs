using UnityEngine;

using Project.Core.Spawners;
using Project.Input;
using Project.Tools;

namespace Project.Core.Objects
{
    public class SpaceShip : DestroyableObject
    {
        [SerializeField]
        private Gun myGun;

        private IMovementInput input;

        private Vector2 direction;

        protected virtual void Update()
        {
            transform.Rotate(new Vector3(0, 0, -input.Navigation.x * SO.RotationSpeed));

            if (input.Navigation.y == 1)
                direction = Trigonometry.UnityDegreeToVector2(transform.eulerAngles.z);

            if (input.Fire)
                myGun.Fire();
        }

        protected override void FixedUpdate()
        {
            if (input.Navigation.y == 1 && rb2d.velocity.x * rb2d.velocity.x + rb2d.velocity.y * rb2d.velocity.y < SO.MaxSpeed)
                rb2d.AddForce(SO.Speed * Time.deltaTime * direction);
        }
        
        public void SetInput(IMovementInput input)
        {
            this.input = input;
        }
    }
}
