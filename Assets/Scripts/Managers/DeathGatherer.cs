using UnityEngine;

using Project.Core.Objects;

namespace Project.Managers
{
    public class DeathGatherer : MonoBehaviour
    {
        [SerializeField]
        private GameFlow gameFlow;

        public void DeathMessage(object sender, DeathArgs args)
        {
            try
            {
                var asteroid = (Asteroid)sender;
                float angleStart = args.Sender.transform.eulerAngles.z - asteroid.Split.AngleBetweenAsteroids * (asteroid.Split.AsteroidsNumber - 1) / 2;
                for (int i = 0; i < asteroid.Split.AsteroidsNumber; i++)
                    gameFlow.CreateAsteroid(asteroid.Split.AsteroidToSpawn, 
                                            args.Sender.transform.position, 
                                            Quaternion.Euler(0, 0, angleStart + (i * asteroid.Split.AngleBetweenAsteroids)));
            }
            catch (System.InvalidCastException)
            {
                Debug.Log($"{sender} is not an Asteroid");
            }
        }
    }
}
