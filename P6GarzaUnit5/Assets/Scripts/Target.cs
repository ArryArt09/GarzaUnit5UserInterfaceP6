using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;

    public ParticleSystem explosionParticle;

    private GameManager gameManager;
    public int valueWorth = 5;
    public int Nutrition = 1;

    // Move values
    public float theTorque = 10;
    public float speedRand = 12;

    // Cordinate Locations
    public float xRange = 4;
    public float ySpawnPos = -6;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        //Up Force
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //Spin
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        //X slider for where it spawns
        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    // Value shennanagins shurnanagons, surenanaguns, (bro)chure-ana-(a)gains
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(speedRand, (speedRand + 4));
    }
    float RandomTorque()
    {
        return Random.Range(-theTorque, theTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(valueWorth);
            gameManager.UpdateLives(Nutrition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        
    }
}
