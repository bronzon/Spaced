using UnityEngine;
using System.Collections;

public class PropulsionModule : Module {
	public float power;
	public float fuelEfficiency;

	private Rigidbody rbody;
	private FuelSupply fuelSupply;

	public override string GetDescription () {
		return "Power: " + power + "\r\n" + "Efficiency: " + fuelEfficiency + "\r\n" + "Mass: " + mass;
	}

	public override void Launch ()	{
		StartCoroutine (RunEngine ());			
	}

	void Start() {
		rbody = GetComponent<Rigidbody> ();
		fuelSupply = FindObjectOfType<FuelSupply> ();
		FindObjectOfType<Statistics> ().AddMass (mass);
		FindObjectOfType<Statistics> ().AddPower(power);
	}


	IEnumerator RunEngine () {
		GetComponentInChildren<ParticleSystem> ().Play ();

		while (fuelSupply.HasFuel()) {
			fuelSupply.ConsumeFuel (power * fuelEfficiency);
			rbody.AddForce (Vector3.up*power);
			yield return new WaitForEndOfFrame ();
		}

		GetComponentInChildren<ParticleSystem> ().Stop ();
	}
}
