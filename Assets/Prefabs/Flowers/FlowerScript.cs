using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{ 
    public ParticleSystem startParticals;
    // Start is called before the first frame update
    void Start()
    {
        startParticals = GetComponent<ParticleSystem>();
        //Play animation
        startParticals.Play();
        Invoke("stopParticals", 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Add floower to inventory
        if (other.GetComponent<Inventory>().AddFlower(gameObject.tag))
        {
            Destroy(gameObject);
        }
    }
    private void stopParticals()
    {
        startParticals.Stop();
    }
}
