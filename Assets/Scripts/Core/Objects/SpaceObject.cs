using UnityEngine;

using Project.Core.Conf;
using Project.Tools;

namespace Project.Core.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class SpaceObject : MonoBehaviour
    {
        public SpaceObjectSO SO;

        protected Rigidbody2D rb2d;

        protected virtual void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        protected virtual void FixedUpdate()
        {
            if (rb2d.velocity.x * rb2d.velocity.x + rb2d.velocity.y * rb2d.velocity.y < SO.Speed)
                rb2d.AddForce(SO.Speed * Time.deltaTime * Trigonometry.UnityDegreeToVector2(transform.eulerAngles.z));
        }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            DestroyableObject desObj = collision.gameObject.GetComponent<DestroyableObject>();
            if (desObj != null)
                desObj.DecreaseHealth(SO.DamageOnCollide);
        }

        protected void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.name == SO.SceneInfo.CameraBoundsGameObjectName)
            {
                switch (SO.eOnExitCameraBounds)
                {
                    case ActionOnExitCameraBounds.Disable:
                        gameObject.SetActive(false);
                        break;
                    case ActionOnExitCameraBounds.Teleport:
                        if (Mathf.Abs(transform.position.x) > SO.SceneInfo.CameraBoundsExtents.x)
                            transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
                        if (Mathf.Abs(transform.position.y) > SO.SceneInfo.CameraBoundsExtents.y)
                            transform.position = new Vector3(transform.position.x, transform.position.y * -1, transform.position.z);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
