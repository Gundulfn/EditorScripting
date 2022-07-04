using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RandomMonoScript))]
public class CustomizedEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        //Draw RandomMonoScript attributes on Component section
        DrawDefaultInspector();

        RandomMonoScript randomMonoScript = (RandomMonoScript)target;
        
        EditorGUILayout.LabelField("Square Root", randomMonoScript.SquareRoot.ToString());
        EditorGUILayout.HelpBox("This is a help box", MessageType.Info);

        if(GUILayout.Button("Instantiate Ball"))
        {
            randomMonoScript.InstantiateBall();
        }
    }
}