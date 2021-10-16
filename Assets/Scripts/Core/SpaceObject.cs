using UnityEngine;

using Project.Tools;

namespace Project.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class SpaceObject : MonoBehaviour
    {
        [SerializeField]
        protected SpaceObjectSO SO;

        protected Rigidbody2D rb2d;

        protected virtual void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        protected virtual void FixedUpdate()
        {
            if (rb2d.velocity.x * rb2d.velocity.x + rb2d.velocity.y * rb2d.velocity.y < SO.Speed)
                rb2d.AddForce(SO.Speed * Time.deltaTime * Trigonometry.NormalDegreeToVector2(transform.eulerAngles.z));
        }
    }
}
