using UnityEngine;
using System.Collections;

public class Engine {

	//This class will be singelton. Only one instance of it can be instantiniate
	//Define paricipant of the game
	public Hero hero;

	//------------------------------singelten implematation begin



	private static Engine engine;

	static Engine()
	{
		engine = new Engine ();
	}

	public static Engine GetEngine{

		get
		{

			return engine;
		}
	}

	private Engine(){}

	//-----------------------------singelton implemantation end

	public void Run()
	{

		hero = new Hero ("Arkadash", Shared.HERO_HUMAN_LIFE, Shared.HERO_HUMAN_DEFENCE,
		             true, Shared.HERO_HUMAN_TAKELIFE);
		hero.CreateBody ();


	}

}
