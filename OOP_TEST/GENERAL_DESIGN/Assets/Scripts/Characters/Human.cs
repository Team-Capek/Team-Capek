using UnityEngine;
using System.Collections;
using System;

public abstract class Human : MonoBehaviour,IHumanoid {


	private int life;
	private GameObject body ;
	private string name;
	private int giveLife;
	private int takeLife ;
	private int active;
	private int efectRadius;
	private int defence;
	
	
	public override GameObject Body { get; set;} //<---da se napishe validaciq
	public override int GiveLife{ get; set;}  //<---da se napishe validaciq
	public override bool Active{ get; set;}  //<---da se napishe validaciq
	public override int EfectRadius{ get; set;}  //<---da se napishe validaciq



	public Human(string name,int life, int defence)
	{


	}

	public override string Name
	{
		get{return this.name;}
		set
		{
			if(value ==null || value=="")
			{
				throw new ArgumentOutOfRangeException("Out of range properties!");
			}
			this.name=value;
		}
	} 




	public override int TakeLife
	{
		get{return this.takeLife;}
		set
		{
			if(value >0)
			{
				throw new ArgumentOutOfRangeException("Out of range properties!");
			}
			this.takeLife=value;
		}
	} 

	public override int Defence
	{
		get{return this.Defence;}
		set
		{
			if(value<0)
			{
				throw new ArgumentOutOfRangeException("Out of range properties!");
			}
			this.defence =value;
		}

	}
	

	public override int Life
	{
		get
		{
			return Life;
		}
		set
		{
			if(value<0)
			{
				PerformDeath();
				life=0;
			}
			this.life=value;
		}
	}

	public override void PerformBorn();
	public override void PerformDeath();

	public override  void CreateBody()
	{
		body = new GameObject(); //"New_Plane_Fom_Script"
		body.AddComponent<MeshFilter> ();
		body.GetComponent<MeshFilter>().mesh= PrimitiveType.Cube;
		body.AddComponent<MeshRenderer> ();
		body.GetComponent<MeshRenderer> ().materials[0]  = new Material (Shader.Find("Diffuse")) ;
		body.AddComponent<CapsuleCollider> ();
		body.GetComponent<CapsuleCollider> ().isTrigger = this.Active;
	}

	public override abstract void React(); 

}
