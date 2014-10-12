using UnityEngine;
using System.Collections;

		/// <summary>
		/// An interface common for all participants in game scene.
		/// </summary>


public interface IGameObject {

	 GameObject Body { get; set;}
	 string Name{ get; set;}
	 int Life{ get; set;}
	 int GiveLife{ get; set;}
	 int TakeLife { get; set;}
	 int Active{ get; set;}
	 int EfectRadius{ get; set;}
	 
	 void PerformBorn();
	 void PerformDeath();
	 void CreateBody();
	 void React();
}
