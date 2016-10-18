using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Statistics : MonoBehaviour {
	public Text fuelText;
	public Text massText;
	public Text powerText;
	public Text altitudeText;

	private float currentFuel;
	private float currentMass;
	private float currentPower;

	void Start() {
		fuelText.text = "Fuel: 0";
		massText.text = "Mass: 0";
		powerText.text = "Power: 0";
		altitudeText.text = "Altitude: 0";
	}

	public void AddPower(float power)  {
		currentPower += power;	
		powerText.text = "Power: " + currentPower;
	}

	public void AddFuel(float fuel) {
		currentFuel += fuel;
		fuelText.text = "Fuel: " + currentFuel;
	}

	public void SubtractFuel(float fuel) {
		currentFuel -= fuel;
		fuelText.text = "Fuel: " + Mathf.Max(0, currentFuel);
	}

	public void AddMass(float mass) {
		currentMass += mass;
		massText.text = "Mass: " + currentMass;
	}

	public void SetAltitude(float altitude) {
		altitudeText.text = "Altitude: " + Mathf.FloorToInt(altitude).ToString ();
	}
}
