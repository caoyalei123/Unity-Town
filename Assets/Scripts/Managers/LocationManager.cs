using UnityEngine;
using System.Collections;

public class LocationManager : MonoBehaviour
{
	private GameObject[] shops;
	private GameObject[] cashMachines;
	
	public void Awake()
	{
		shops = GameObject.FindGameObjectsWithTag(TagConstants.SHOPS);
		cashMachines = GameObject.FindGameObjectsWithTag(TagConstants.CASH_MACHINES);
		
		Debug.Log("Started with " + getCashMachineCount() + " cash machines.");
	}
	
	public void Start()
	{
	
	}
	
	public void Update ()
	{
	
	}
	
	public GameObject[] getShops()
	{
		return this.shops;
	}
	
	public GameObject[] getCashMachines()
	{
		return this.cashMachines;
	}
	
	// TODO
	public GameObject getClosestShop(Vector3 position)
	{
		return null;
	}
	
	// TODO
	public GameObject getClosestCashMachine(Vector3 position)
	{
		return null;
	}
	
	public GameObject getRandomShop()
	{
		int index = Random.Range(0, (this.shops.Length - 1));
		
		return this.shops[index];
	}
	
	public int getShopCount()
	{
		return this.shops.Length;
	}
	
	public int getCashMachineCount()
	{
		return this.cashMachines.Length;
	}
}