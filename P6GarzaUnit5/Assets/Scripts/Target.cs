using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;

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
}
