using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelScript))]

public class LevelScriptEditor : Editor
{
   public override void OnInspectorGUI()
   {
	   LevelScript myTarget = (LevelScript)target;
	   
	   //myTarget.experience = EditorGUILayout.IntField("Experience", myTarget.experience);
	   DrawDefaultInspector();
	   EditorGUILayout.LabelField("Level", myTarget.level.ToString());
   }
}
