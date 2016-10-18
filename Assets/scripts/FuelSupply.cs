using UnityEngine;
using System.Collections;

public class FuelSupply : MonoBehaviour {
	
	private float availableFuel;

	public bool HasFuel () {
		return availableFuel > 0;
	}

	public void ConsumeFuel(float amount) {
		availableFuel -= amount;
	}

	public void AddFuelFromModule(int fuel) {
		availableFuel += fuel;
	}
}
