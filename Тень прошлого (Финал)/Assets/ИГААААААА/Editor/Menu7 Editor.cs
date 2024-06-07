using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

[CustomEditor(typeof(Menu7))]
public class Menu7Editor : Editor, IPreprocessBuildWithReport
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Menu7 menuScript = (Menu7)target;
        EditorGUILayout.Space();

        if (GUILayout.Button("Clear Player Name"))
        {
            menuScript.ClearPlayerName();
        }
    }

    public int callbackOrder { get { return 0; } }

    public void OnPreprocessBuild(BuildReport report)
    {
        Menu7 menuScript = (Menu7)target;
        menuScript.ClearPlayerName();
        Debug.Log("Player name has been cleared before building.");
    }
}
