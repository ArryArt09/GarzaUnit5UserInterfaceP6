using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float Variable = 6.9f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -Variable)
        {
            transform.position = new Vector3(20, -Variable, transform.position.z);
        }
    }
}
