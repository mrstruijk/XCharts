/************************************************/
/*                                              */
/*     Copyright (c) 2018 - 2021 monitor1394    */
/*     https://github.com/monitor1394           */
/*                                              */
/************************************************/

namespace XCharts
{
    [SerieEditor(typeof(Candlestick))]
    public class CandlestickEditor : SerieEditor<Candlestick>
    {
        public override void OnCustomInspectorGUI()
        {
            PropertyField("m_XAxisIndex");
            PropertyField("m_YAxisIndex");
            PropertyFieldLimitMin("m_MinShow", 0);
            PropertyFieldLimitMin("m_MaxShow", 0);
            PropertyFieldLimitMin("m_MaxCache", 0);
            PropertyField("m_BarWidth");
            PropertyField("m_Clip");
            PropertyField("m_ShowAsPositiveNumber");
            PropertyField("m_Large");
            PropertyField("m_LargeThreshold");

            PropertyField("m_ItemStyle");
            PropertyField("m_IconStyle");
            PropertyField("m_Label");
            PropertyField("m_LabelLine");
            PropertyField("m_Emphasis");
            PropertyField("m_Animation");
        }
    }
}