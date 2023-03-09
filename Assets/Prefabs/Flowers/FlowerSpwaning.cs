using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpwaning : MonoBehaviour
{
    public GameObject[] flowers;
    public float spawnPosMax = 5.0f;
    public float spawnPosMin = -5.0f;
    public float startDelay = 5;
    public float spawnInterval = 1.5f;
    private int maxValue = 15; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("respanFlower", startDelay, spawnInterval);
    }
    private void respanFlower( )
    {
        if (this.gameObject.transform.childCount < maxValue) { 
            Vector3 spawnPos = new Vector3(Random.Range(spawnPosMin, spawnPosMax), 0.0f, Random.Range(spawnPosMin, spawnPosMax));
            int indexFlower = Random.Range(0, flowers.Length);
            var flower = Instantiate(flowers[indexFlower], spawnPos, flowers[indexFlower].transform.rotation);
            flower.transform.parent = this.gameObject.transform;
        }
    }
}
