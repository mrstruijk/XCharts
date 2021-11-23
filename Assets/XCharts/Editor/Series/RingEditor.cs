/************************************************/
/*                                              */
/*     Copyright (c) 2018 - 2021 monitor1394    */
/*     https://github.com/monitor1394           */
/*                                              */
/************************************************/

namespace XCharts
{
    [SerieEditor(typeof(Ring))]
    public class RingEditor : SerieEditor<Ring>
    {
        public override void OnCustomInspectorGUI()
        {
            PropertyTwoFiled("m_Center");
            PropertyTwoFiled("m_Radius");
            PropertyField("m_StartAngle");
            PropertyField("m_RingGap");
            PropertyField("m_RoundCap");
            PropertyField("m_Clockwise");
            PropertyField("m_TitleStyle");

            PropertyField("m_ItemStyle");
            PropertyField("m_IconStyle");
            PropertyField("m_Label");
            PropertyField("m_LabelLine");
            PropertyField("m_Emphasis");
            PropertyField("m_Animation");
        }
    }
}