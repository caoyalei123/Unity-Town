using UnityEngine;
using System.Collections;

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
	
	public override void runHumanInteraction(HumanUnit humanUnit)
	{
		humanUnit.cash += 100;
		this.cash -= 100;
	}
}