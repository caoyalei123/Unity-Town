using UnityEngine;
using System.Collections;

/**
 * Represents a cash machine location.
 * Cash machines provide cash to units.
 */
public class CashMachineLocation : AccessibleLocation
{
	// The amount of cash this machine currently contains.
	public int cash;
	// The amount of cash given to a unit during an interaction.
	public int cashPerInteraction = 100;
	
	public override void Start()
	{
		base.Start();
	}
	
	public override void Update()
	{
		base.Update();
	}
	
	/**
	 * Increases the cash property of the human unit
	 * and decreases the cash property of this location
	 * by the current cashPerInteraction value.
	 */
	public override void RunHumanInteraction(HumanUnit humanUnit)
	{
		if (this.active)
		{
			if (this.cash >= this.cashPerInteraction)
			{
				humanUnit.cash += this.cashPerInteraction;
				this.cash -= this.cashPerInteraction;
			}
			else
			{
				this.active = false;
			}
		}
	}
}
