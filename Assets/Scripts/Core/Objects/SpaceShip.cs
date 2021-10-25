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
        public Gun myGun;
        [Tooltip("Moving input rotates spaceship or spin a gun")]
        public bool inputSpinsGun;

        private IMovementInput input;

        private Vector2 direction;
        private Action gunfire;
        private float gunSpinningTimer;

        protected override void OnEnable()
        {
            base.OnEnable();

            if (input == null)
                Debug.LogWarning($"Input is not set on {gameObject.name}");

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
            if (inputSpinsGun)
                SpinGun(((SpaceShipSO)SO).RotationSpeed);
            else
                RotateSpaceShip(((SpaceShipSO)SO).RotationSpeed);

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

        private void RotateSpaceShip(float rotationSpeed)
        {
            transform.Rotate(new Vector3(0, 0, -input.Move.x * rotationSpeed));
        }

        private void SpinGun(float rotationSpeed)
        {
            //gunSpinningTimer += Time.time * ;
            //float x = Mathf.Cos(rotationSpeed * input.Move.x) - myGun.transform.position.x;
            //float y = Mathf.Sin(rotationSpeed * input.Move.x) - myGun.transform.position.y;
            //myGun.transform.position += new Vector3(x, y, 0);
            myGun.transform.RotateAround(transform.position, new Vector3(0, 0, -input.Move.x), rotationSpeed * Time.deltaTime * 100);
        }
    }
}
