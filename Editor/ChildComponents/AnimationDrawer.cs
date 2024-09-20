using UnityEditor;
using UnityEngine;
using XCharts.Runtime;
using AnimationInfo = XCharts.Runtime.AnimationInfo;


namespace XCharts.Editor
{
    [CustomPropertyDrawer(typeof(AnimationInfo), true)]
    public class AnimationInfoDrawer : BasePropertyDrawer
    {
        public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
        {
            base.OnGUI(pos, prop, label);

            if (MakeComponentFoldout(prop, "m_Enable", true))
            {
                ++EditorGUI.indentLevel;
                PropertyField(prop, "m_Delay");
                PropertyField(prop, "m_Duration");
                --EditorGUI.indentLevel;
            }
        }
    }


    [CustomPropertyDrawer(typeof(AnimationChange), true)]
    public class AnimationChangeDrawer : BasePropertyDrawer
    {
        public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
        {
            base.OnGUI(pos, prop, label);

            if (MakeComponentFoldout(prop, "m_Enable", true))
            {
                ++EditorGUI.indentLevel;
                PropertyField(prop, "m_Duration");
                --EditorGUI.indentLevel;
            }
        }
    }


    [CustomPropertyDrawer(typeof(AnimationAddition), true)]
    public class AnimationAdditionDrawer : BasePropertyDrawer
    {
        public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
        {
            base.OnGUI(pos, prop, label);

            if (MakeComponentFoldout(prop, "m_Enable", true))
            {
                ++EditorGUI.indentLevel;
                PropertyField(prop, "m_Duration");
                --EditorGUI.indentLevel;
            }
        }
    }


    [CustomPropertyDrawer(typeof(AnimationInteraction), true)]
    public class AnimationInteractionDrawer : BasePropertyDrawer
    {
        public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
        {
            base.OnGUI(pos, prop, label);

            if (MakeComponentFoldout(prop, "m_Enable", true))
            {
                ++EditorGUI.indentLevel;
                PropertyField(prop, "m_Duration");
                PropertyField(prop, "m_Width");
                PropertyField(prop, "m_Radius");
                PropertyField(prop, "m_Offset");
                --EditorGUI.indentLevel;
            }
        }
    }


    [CustomPropertyDrawer(typeof(AnimationStyle), true)]
    public class AnimationDrawer : BasePropertyDrawer
    {
        public override string ClassName => "Animation";


        public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
        {
            base.OnGUI(pos, prop, label);

            if (MakeComponentFoldout(prop, "m_Enable", true))
            {
                ++EditorGUI.indentLevel;
                PropertyField(prop, "m_Type");
                PropertyField(prop, "m_UnscaledTime");
                PropertyField(prop, "m_FadeIn");
                PropertyField(prop, "m_FadeOut");
                PropertyField(prop, "m_Change");
                PropertyField(prop, "m_Addition");
                PropertyField(prop, "m_Interaction");
                --EditorGUI.indentLevel;
            }
        }
    }
}