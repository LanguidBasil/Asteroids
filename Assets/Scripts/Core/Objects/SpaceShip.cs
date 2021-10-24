using System;
using UnityEngine;

using Project.Core.Conf.SO;
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
        private Action gunfire;

        protected override void OnEnable()
        {
            base.OnEnable();

            if (input == null)
                Debug.Log($"Input is not set on {gameObject.name}");

            gunfire = new Action( () => { myGun.Spawn(); } );
            input.Fire += gunfire;

            rb2d.velocity = Vector2.zero;
        }

        protected virtual void OnDisable()
        {
            input.Fire -= gunfire;
        }

        protected virtual void Update()
        {
            transform.Rotate(new Vector3(0, 0, -input.Move.x * ((SpaceShipSO)SO).RotationSpeed));

            if (input.Move.y == 1)
                direction = Trigonometry.UnityDegreeToVector2(transform.eulerAngles.z);
        }

        protected void FixedUpdate()
        {
            if (input.Move.y == 1 && rb2d.velocity.x * rb2d.velocity.x + rb2d.velocity.y * rb2d.velocity.y < ((SpaceShipSO)SO).MaxSpeed)
                rb2d.AddForce(SO.Speed * 100 * Time.deltaTime * direction);
        }
        
        public void SetInput(IMovementInput input)
        {
            this.input = input;
        }
    }
}
