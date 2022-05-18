using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    #region Variables
    public Asteroid asteroidPrefab;

    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public float spawnDistance = 15.0f;
    public int spawnAmount = 1;
    #endregion
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        
        for (int i = 0; i < this.spawnAmount; i++)
        {
            //Randomize the spawnpoint and direction of an Asteroid
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation); 
            asteroid.size = Random.Range(asteroid.minSize, asteroid.mazSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
