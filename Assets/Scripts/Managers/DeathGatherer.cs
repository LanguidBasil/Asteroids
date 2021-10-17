using UnityEngine;

using Project.Core.Objects;

namespace Project.Managers
{
    public class DeathGatherer : MonoBehaviour
    {
        [SerializeField]
        private GameFlow gameFlow;
        [SerializeField]
        private Scorer scorer;

        public void DeathMessage(object sender, DeathArgs args)
        {
            scorer.AddScore(args.SO.XP);

            SpawnPlayer(sender as SpaceShip, args);
            SpawnAsteroids(sender as Asteroid, args);
        }

        private void SpawnPlayer(SpaceShip player, DeathArgs args)
        {
            if (player == null)
                return;

            scorer.AddLife(-1);
            if (scorer.Lifes > 0)
                gameFlow.CreatePlayer(Vector3.zero, Quaternion.identity);
        }

        private void SpawnAsteroids(Asteroid asteroid, DeathArgs args)
        {
            if (asteroid == null)
                return;

            float angleStart = args.Sender.transform.eulerAngles.z - asteroid.Split.AngleBetweenAsteroids * (asteroid.Split.AsteroidsNumber - 1) / 2;
            for (int i = 0; i < asteroid.Split.AsteroidsNumber; i++)
                gameFlow.CreateAsteroid(asteroid.Split.AsteroidToSpawn,
                                        args.Sender.transform.position,
                                        Quaternion.Euler(0, 0, angleStart + (i * asteroid.Split.AngleBetweenAsteroids)));
        }
    }
}
