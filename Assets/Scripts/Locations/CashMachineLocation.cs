using UnityEngine;
using System.Collections;

/**
 * Represents a cash machine location.
 * Cash machines provide cash to units.
 */
public class CashMachineLocation : AccessibleLocation
{
	public int cash;
	
	public override void Start()
	{
		base.Start();
	}
	
	public override void Update()
	{
		base.Update();
	}
	
	public override void RunHumanInteraction(HumanUnit humanUnit)
	{
		humanUnit.cash += 100;
		this.cash -= 100;
	}
}
