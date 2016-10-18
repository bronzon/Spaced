using UnityEngine;
using System.Collections;

public class FuelModule : Module {
	public int fuelCapacity;

	public override void Launch () {}

	public override string GetDescription () {
		return "Fuel Capacity: " + fuelCapacity + "\r\n" + "Mass: " + mass;
	}

	// Use this for initialization
	void Start () {
		FindObjectOfType<FuelSupply> ().AddFuelFromModule (fuelCapacity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
