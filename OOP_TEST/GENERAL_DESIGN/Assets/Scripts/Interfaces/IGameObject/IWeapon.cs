using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IWeapon : IGameObject {

	IList<IGameObject> Charger{ get; set;} // ho many bullets does it has
	GameObject Spawn { get; set;} // shooter ditektion

}
