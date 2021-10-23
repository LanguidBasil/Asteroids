using UnityEngine;

namespace Project.Core.Objects
{
    public class Bullet : DestroyableObject
    {
        private Vector2 lastFramePosition;
        private float flewDistance;
        private float screenWidth;

        protected override void OnEnable()
        {
            base.OnEnable();

            lastFramePosition = transform.position;
            flewDistance = 0;
            screenWidth = SO.SceneInfo.CameraBoundsExtents.x * 2;
        }

        private void Update()
        {
            float deltaMove = Vector2.Distance(transform.position, lastFramePosition);
            if (deltaMove < SO.SceneInfo.CameraBoundsExtents.y)
                flewDistance += deltaMove;

            if (flewDistance > screenWidth)
                gameObject.SetActive(false);

            lastFramePosition = transform.position;
        }
    }
}