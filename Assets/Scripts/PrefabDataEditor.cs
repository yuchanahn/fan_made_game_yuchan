using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PrefabData))]
public class PrefabDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PrefabData prefabData = (PrefabData)target;

        if (prefabData.prefabProbabilities != null && prefabData.prefabProbabilities.Length > 0)
        {
            float totalProbability = 0f;
            foreach (var prefabProbability in prefabData.prefabProbabilities)
            {
                totalProbability += prefabProbability.probability;
            }

            EditorGUILayout.LabelField("Total Probability: " + totalProbability);

            for (int i = 0; i < prefabData.prefabProbabilities.Length; i++)
            {
                GUILayout.BeginHorizontal();
                EditorGUILayout.ObjectField("Prefab", prefabData.prefabProbabilities[i].prefab, typeof(GameObject), false);
                EditorGUILayout.FloatField("Probability", prefabData.prefabProbabilities[i].probability);

                if (totalProbability > 0)
                {
                    float percentage = (prefabData.prefabProbabilities[i].probability / totalProbability) * 100;
                    EditorGUILayout.LabelField("Chance: " + percentage.ToString("F2") + "%");
                }
                else
                {
                    EditorGUILayout.LabelField("Chance: 0%");
                }
                GUILayout.EndHorizontal();
            }
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(prefabData);
        }
    }
}
