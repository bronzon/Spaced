using UnityEngine;
using System.Collections;

public class PropulsionModule : Module {
	public int power;
	public float fuelEfficiency;

	public override string GetDescription () {
		return "Power: " + power + "\r\n" + "Efficiency: " + fuelEfficiency + "\r\n" + "Mass: " + mass;
	}
}
