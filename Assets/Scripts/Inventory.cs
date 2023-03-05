using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<FlowersInventry> flowers = new List<FlowersInventry>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddFlower(string name)
    {
        /*if(flowers.Find(name))
        {

        }*/
    }
}

public class FlowersInventry
{
    public string Name { get; set; }
    public int Amount { get; set; }

    public delegate bool Predicate<in T>(T obj);
}