using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowersInventry
{
    private TextMeshProUGUI FlowerText;
    private int amount;
    public string Name { get; set; }
    public int Value { get; }
    public int getAmount()
    {
        return amount;
    }
    public void setAmount(int value)
    {
        amount = value;
        FlowerText.text = value.ToString();
    }
    
    public FlowersInventry(string name, int value, TextMeshProUGUI flowerText, int a = 0)
    {
        Name = name;
        Value = value;
        amount = a;
        FlowerText = flowerText;
        FlowerText.text = "0";
    }
}
public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI MonyeText;
    public TextMeshProUGUI FlowerText1;
    public TextMeshProUGUI FlowerText2;
    public TextMeshProUGUI SellText;
    private List<FlowersInventry> flowers = new List<FlowersInventry>();
    private int maxItem = 5;
    private int money = 0;
    private bool sellActive = false;
    // Start is called before the first frame update
    void Start()
    {
        flowers.Add(new FlowersInventry("Flower1", 2, FlowerText1));
        flowers.Add(new FlowersInventry("Flower2", 5, FlowerText2));
        money = 0;
        SellText.text = "";
    }
    private void Update()
    {
        if (Input.GetKeyDown("space") && sellActive)
        {
            sellFlowers();
        }
    }
    public bool AddFlower(string name)
    {
        FlowersInventry flower = flowers.Find(x => x.Name.Contains(name));
        if(flower != null)
        {
            if(flower.getAmount() < maxItem)
            {
                flower.setAmount(flower.getAmount() +1);
                return true;
            }
        }
        return false;

    }
    public void sellFlowers()
    {
        foreach(var flower in flowers)
        {
            money += flower.Value*flower.getAmount();
            updateMonyText(money);
            flower.setAmount(0);
        }
    }
    public void updateMonyText(int money)
    {
            MonyeText.text = "Amount: " + money;
    }
    public void updateSellText(bool active)
    {
        if (active)
        {

            SellText.text = "Press Space to sell";
            sellActive = true;
        }
        else
        {
            SellText.text = "";
            sellActive = false;
        }
    }

    
}
