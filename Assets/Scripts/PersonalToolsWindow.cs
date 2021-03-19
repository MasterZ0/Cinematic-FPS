using UnityEditor;
using UnityEngine;
using System;

public class PersonalToolsWindow : EditorWindow
{
    [MenuItem("Window/Personal Tools")]
    public static void ShowWindow()
    {
        GetWindow<PersonalToolsWindow>("Personal Tools");
    }
    public void OnGUI()
    {
        if (GUILayout.Button("Round Transform"))
        {
            RoundItems();
        }

        if(Selection.transforms.Length > 1) {

            GUILayout.Label($"{Selection.gameObjects[0].name} looking -> {Selection.gameObjects[1].name}");
        }

        if (GUILayout.Button("Look At")) {
            LookAt();
        }
    }
   
    void RoundItems()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Undo.RecordObject(obj, "rounded");

            Vector3 pos = obj.transform.localPosition;       
            pos.x = (float) Math.Round(pos.x * 2, MidpointRounding.AwayFromZero)/2;
            pos.y = (float)Math.Round(pos.y * 2, MidpointRounding.AwayFromZero)/2;
            pos.z = (float)Math.Round(pos.z * 2, MidpointRounding.AwayFromZero)/2;
            obj.transform.localPosition = pos;
        }
    }

    void LookAt() {
        Vector3 oldRotation = Selection.transforms[0].eulerAngles;
        Selection.transforms[0].LookAt(Selection.transforms[1]);
        Vector3 newRotation = Selection.transforms[0].eulerAngles;

        Debug.Log($"Updated GameObject '{Selection.transforms[0].name}' rotation\nOld: {oldRotation}, Current; {newRotation}");
    }
}
