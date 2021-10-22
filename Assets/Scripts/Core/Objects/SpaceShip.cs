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

        protected override void OnEnable()
        {
            base.OnEnable();

            rb2d.velocity = Vector2.zero;
        }

        protected void Start()
        {
            input.Fire += () => { myGun.Spawn(); };
        }

        protected virtual void Update()
        {
            transform.Rotate(new Vector3(0, 0, -input.Move.x * SO.RotationSpeed));

            if (input.Move.y == 1)
                direction = Trigonometry.UnityDegreeToVector2(transform.eulerAngles.z);
        }

        protected void FixedUpdate()
        {
            if (input.Move.y == 1 && rb2d.velocity.x * rb2d.velocity.x + rb2d.velocity.y * rb2d.velocity.y < SO.MaxSpeed)
                rb2d.AddForce(SO.Speed * 100 * Time.deltaTime * direction);
        }
        
        public void SetInput(IMovementInput input)
        {
            this.input = input;
        }
    }
}
