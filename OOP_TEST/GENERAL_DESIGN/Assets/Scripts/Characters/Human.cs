using UnityEngine;
using System.Collections;
using System;

public abstract class Human : IHumanoid { //dali da nasledqwa monobehaviour
	
	
	private int life;
	private GameObject body ;
	private string nameOf;
	private int giveLife;
	private int takeLife ;
	private int activeOf;
	private int efectRadius;
	private int defence;
	
	
	public  GameObject Body { get; set;} //<---da se napishe validaciq
	public  int GiveLife{ get; set;}  //<---da se napishe validaciq
	public  bool Active{ get; set;}  //<---da se napishe validaciq
	public  int EfectRadius{ get; set;}  //<---da se napishe validaciq

	
	
	public Human(string name,int life, int defence, bool active, int takeLife)
	{
		this.Name = name;
		this.Life = life;
		this.Defence = defence;
		this.Active = active;
		this.TakeLife = takeLife;
		
	}
	
	public  string Name
	{
		get{return this.nameOf;}
		set
		{
			if(value ==null || value=="")
			{
				throw new ArgumentOutOfRangeException("Out of range properties!");
			}
			this.nameOf=value;
		}
	} 
	
	
	
	
	public  int TakeLife
	{
		get{return this.takeLife;}
		set
		{
			if(value <0)
			{
				throw new ArgumentOutOfRangeException("Out of range properties!");
			}
			this.takeLife=value;
		}
	} 
	
	public  int Defence
	{
		get{return this.defence;}
		set
		{
			if(value<0)
			{
				throw new ArgumentOutOfRangeException("Out of range properties!");
			}
			this.defence =value;
		}
		
	}
	
	
	public  int Life
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
	
	public virtual void PerformBorn(){}
	public virtual void PerformDeath(){}
	
	public virtual  void CreateBody()
	{

		Mesh m = new Mesh() ;
		m.name = "ScriptedMesh";
		m = CommonMthods. DrawPlaneMesh (1, 1, m);
		//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

		body = new GameObject("OBOOBOBO"); //"New_Plane_Fom_Script"
		body=GameObject.CreatePrimitive(PrimitiveType.Cube);
	//	body.AddComponent<MeshFilter> ();
	//	body.GetComponent<MeshFilter> ().mesh=m;
		body.AddComponent<MeshRenderer> ();
		body.GetComponent<MeshRenderer> ().materials[0]  = new Material (Shader.Find("Diffuse")) ;
		body.AddComponent<CapsuleCollider> ();
		body.GetComponent<CapsuleCollider> ().isTrigger = this.Active;
		body.transform.rotation = Quaternion.Euler(60, 145, 30);
	}
	
	public virtual  void React(){}
	
}
