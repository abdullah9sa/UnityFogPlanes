using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FogGenerator))]
public class FogGeneratorEditor : Editor {
    public override void OnInspectorGUI() {

        FogGenerator fg = target as FogGenerator;
        base.OnInspectorGUI();


        if(GUILayout.Button("GenerateFog"))
        {
            fg.GenerateFog();
        }
        
                if(GUILayout.Button("Clear All"))
        {
            fg.Clear();
        }
    }
}