using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletResource;
    public float minRotation;
    public float maxRotation;
    public int numberOfBullets;
    public bool isRandom;

    enum SpawnerType {Normal, Spin}

    [SerializeField] private SpawnerType spawnerType;

    public float cooldown;
    float timer;
    public float bulletSpeed;
    public Vector2 bulletVelocity;

    float[] rotations;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = cooldown;
        rotations = new float[numberOfBullets];
        if(!isRandom)
        {
            DistributedRotations();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            SpawnBullets();
            timer = cooldown;
        }
        timer -= Time.deltaTime;
    }

    public float[]RandomRotations()
    {
        for(int i = 0; i <numberOfBullets; i++)
        {
            rotations[i] = Random.Range(minRotation, maxRotation);
        }
        return rotations;
    }
    
    public float[] DistributedRotations()
    {
        for(int i = 0; i< numberOfBullets;i++)
        {
            var fraction = (float)i / ((float)numberOfBullets - 1);
            var difference = maxRotation - minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[i] = fractionOfDifference + minRotation;
        }
        foreach (var r in rotations) print(r);
        return rotations;
    }
    public GameObject[] SpawnBullets()
    {
        if(isRandom)
        {
            RandomRotations();
        }
        

        GameObject[] spawnedBullets = new GameObject[numberOfBullets];
        for (int i = 0; i < numberOfBullets; i++)
        {
            spawnedBullets[i] = Instantiate(bulletResource, transform);
            var b = spawnedBullets[i].GetComponent<Bullet>();
            b.rotation = rotations[i];
            b.speed = bulletSpeed;
            b.velocity = bulletVelocity;
            if (spawnerType == SpawnerType.Spin)
            {
                minRotation += 10;
                //maxRotation += 1;
                b.rotation  += minRotation;
            }
        }
        
        return spawnedBullets;
    }
}
