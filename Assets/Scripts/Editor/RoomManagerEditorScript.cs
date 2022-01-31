using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is responsible for creating and joining rooms", MessageType.Info);

        RoomManager roomManager = (RoomManager)target;

        if(GUILayout.Button("Join Oculus choice book room"))
        {
            roomManager.JoinExistingRoom();
        }

        if(GUILayout.Button("Join before Oculus"))
        {
            roomManager.CreateTestBookRoomAndJoin();
        }
    }
}
