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

            flewDistance = 0;
            screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.scaledPixelWidth * 2, 0)).x;
        }

        private void Update()
        {
            flewDistance += Vector2.Distance(transform.position, lastFramePosition);

            if (flewDistance > screenWidth)
                gameObject.SetActive(false);

            lastFramePosition = transform.position;
        }
    }
}