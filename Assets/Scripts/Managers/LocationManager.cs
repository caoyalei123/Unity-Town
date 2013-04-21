using UnityEngine;
using System.Collections;

/**
 * Provides access to all existing locations.
 */
public class LocationManager : MonoBehaviour
{
	private GameObject[] shops;
	private GameObject[] cashMachines;
	
	public void Awake()
	{
		this.shops = GameObject.FindGameObjectsWithTag(TagConstants.SHOPS);
		this.cashMachines = GameObject.FindGameObjectsWithTag(TagConstants.CASH_MACHINES);
		
		Debug.Log("Started with " + this.GetCashMachineCount() + " cash machines.");
	}
	
	public void Start()
	{
	
	}
	
	public void Update()
	{
	
	}
	
	public GameObject[] GetShops()
	{
		return this.shops;
	}
	
	public GameObject[] GetCashMachines()
	{
		return this.cashMachines;
	}
	
	// TODO
	public GameObject GetClosestShop(Vector3 position)
	{
		return null;
	}
	
	// TODO
	public GameObject GetClosestCashMachine(Vector3 position)
	{
		return null;
	}
	
	public GameObject GetRandomShop()
	{
		int index = Random.Range(0, (this.shops.Length - 1));
		
		return this.shops[index];
	}
	
	public int GetShopCount()
	{
		return this.shops.Length;
	}
	
	public int GetCashMachineCount()
	{
		return this.cashMachines.Length;
	}
}
