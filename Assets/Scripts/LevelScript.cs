using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public int experience;
	public float life;
	
	public int level
	{
		get {return experience/750;}
	}
}
