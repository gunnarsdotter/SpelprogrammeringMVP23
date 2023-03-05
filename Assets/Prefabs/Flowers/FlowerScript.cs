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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (inventory != full ){
        Debug.Log(gameObject.name);
        Destroy(gameObject);
        //TODO Add floower to inventorys}
    }
    private void stopParticals()
    {
        startParticals.Stop();
    }
}
