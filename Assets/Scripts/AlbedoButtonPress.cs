using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AlbedoButtonPress : MonoBehaviour
{
	public GameObject sphere;
	MeshRenderer sphereRenderer;
	string[] myTextures = new string[4];
	int i;
	void Start()
	{
		sphereRenderer = sphere.GetComponent<MeshRenderer>();
		string[] fileEntries = Directory.GetFiles(Application.dataPath+"/Resources/Textures");
		int k = 0;
		for (int j=0; j<fileEntries.Length; j++)
		{
			if (fileEntries[j].Contains("AO") && !fileEntries[j].Contains("meta"))
			{
				string filename = fileEntries[j].Substring(fileEntries[j].IndexOf("Textures"));
				filename = filename.Replace('\'', '/');
				filename = filename.Replace(".jpg", "");
				myTextures[k] = filename;
				k++;
			}
		}
		i = 0;
	}
     public void OnButtonPress()
	{
		var texture = Resources.Load<Texture2D>(myTextures[i]);
		sphereRenderer.material.SetTexture("_MainTex", texture);
		i = (i+1) % 4;
	}
}
