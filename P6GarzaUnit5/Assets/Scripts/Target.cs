using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    public float speedRand = 12;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        //Up Force
        targetRb.AddForce(Vector3.up * Random.Range(speedRand,(speedRand+4)), ForceMode.Impulse);
        //Spin
        targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);
        //X slider for where it spawns
        transform.position = new Vector3(Random.Range(-4, 4), -6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
