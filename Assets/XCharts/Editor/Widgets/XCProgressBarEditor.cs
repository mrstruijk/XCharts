﻿/******************************************/
/*                                        */
/*     Copyright (c) 2018 monitor1394     */
/*     https://github.com/monitor1394     */
/*                                        */
/******************************************/

using UnityEditor;
using UnityEngine;
using System.Text;

namespace XCharts
{
    [CustomEditor(typeof(XCProgressBar), false)]
    public class XCProgressBarEditor : Editor
    {

        [MenuItem("XCharts/ProgressBar", priority = 200)]
        [MenuItem("GameObject/XCharts/ProgressBar", priority = 200)]
        public static void AddPyramidChart()
        {
            XChartsEditor.AddChart<XCProgressBar>("ProgressBar");
        }

        protected SerializedProperty m_Script;
        protected SerializedProperty m_Value;
        protected SerializedProperty m_BackgroundColor;
        protected SerializedProperty m_StartColor;
        protected SerializedProperty m_EndColor;
        protected SerializedProperty m_CornerRadius;

        protected virtual void OnEnable()
        {
            m_Script = serializedObject.FindProperty("m_Script");
            m_Value = serializedObject.FindProperty("m_Value");
            m_BackgroundColor = serializedObject.FindProperty("m_BackgroundColor");
            m_StartColor = serializedObject.FindProperty("m_StartColor");
            m_EndColor = serializedObject.FindProperty("m_EndColor");
            m_CornerRadius = serializedObject.FindProperty("m_CornerRadius");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            OnStartInspectorGUI();
            serializedObject.ApplyModifiedProperties();
        }

        protected virtual void OnStartInspectorGUI()
        {
            EditorGUILayout.PropertyField(m_Script);
            EditorGUILayout.PropertyField(m_BackgroundColor);
            EditorGUILayout.PropertyField(m_StartColor);
            EditorGUILayout.PropertyField(m_EndColor);
            EditorGUILayout.PropertyField(m_Value);
            EditorGUILayout.PropertyField(m_CornerRadius);
        }
    }
}