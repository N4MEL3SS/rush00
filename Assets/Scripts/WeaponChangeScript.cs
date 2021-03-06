using System;
using UnityEngine;


public class WeaponChangeScript : MonoBehaviour
{
	public string currentWeaponType = "Null";
	public bool inTrigger = false;

	private void Update()
	{
		WeaponManager();
	}

	public void WeaponManager()
	{
		if (Input.GetMouseButtonDown(1) &&!inTrigger)
			DropWeapon(currentWeaponType);
	}

	public void DropWeapon(string weapon)
	{
		if (currentWeaponType != "Null")
		{
			Instantiate(Resources.Load("Prefabs/Weapons" + weapon), transform.position, Quaternion.identity);
			if (!inTrigger)
				currentWeaponType = "0-Empty";
		}
	}
	
}
