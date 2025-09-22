using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[SerializeField]
public class PlayerModel 
{
    public string playerName;
    public int metal;
    public int crystal;
    public int deuturium;
    public List<PlanetModel> planets;

    public PlayerModel(string name)
    {
        this.playerName = name;
         this.metal = 500;
        this.crystal = 300;
        this.deuturium = 100;

    }  
    public void CollectResources()
    {
        metal += 10;
        crystal += 5;
        deuturium += 2;
    }
}
