using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace XCharts.Runtime
{
    /// <summary>
    ///     The style of area.
    ///     ||区域填充样式。
    /// </summary>
    [Serializable]
    public class AreaStyle : ChildComponent, ISerieComponent, ISerieDataComponent
    {
        /// <summary>
        ///     Origin position of area.
        ///     ||图形区域的起始位置。默认情况下，图形会从坐标轴轴线到数据间进行填充。如果需要填充的区域是坐标轴最大值到数据间，或者坐标轴最小值到数据间，则可以通过这个配置项进行设置。
        /// </summary>
        public enum AreaOrigin
        {
            /// <summary>
            ///     to fill between axis line to data.
            ///     ||填充坐标轴轴线到数据间的区域。
            /// </summary>
            Auto,
            /// <summary>
            ///     to fill between min axis value (when not inverse) to data.
            ///     ||填充坐标轴底部到数据间的区域。
            /// </summary>
            Start,
            /// <summary>
            ///     to fill between max axis value (when not inverse) to data.
            ///     ||填充坐标轴顶部到数据间的区域。
            /// </summary>
            End
        }


        [SerializeField] private bool m_Show = true;
        [SerializeField] private AreaOrigin m_Origin;
        [FormerlySerializedAs("m_Color")] [SerializeField] private Color32 m_areaColor;
        [SerializeField] private Color32 m_ToColor;
        [SerializeField] [Range(0, 1)] private float m_Opacity = 0.6f;
        [SerializeField] [Since("v3.2.0")] private bool m_InnerFill;
        [SerializeField] [Since("v3.6.0")] private bool m_ToTop = true;

        /// <summary>
        ///     the origin of area.
        ///     ||区域填充的起始位置。
        /// </summary>
        public AreaOrigin origin
        {
            get => m_Origin;
            set
            {
                if (PropertyUtil.SetStruct(ref m_Origin, value))
                {
                    SetVerticesDirty();
                }
            }
        }

        /// <summary>
        ///     the color of area,default use serie color.
        ///     ||区域填充的颜色，如果toColor不是默认值，则表示渐变色的起点颜色。
        /// </summary>
        public Color32 AreaColor
        {
            get => m_areaColor;
            set
            {
                if (PropertyUtil.SetColor(ref m_areaColor, value))
                {
                    SetVerticesDirty();
                }
            }
        }

        /// <summary>
        ///     Gradient color, start color to toColor.
        ///     ||渐变色的终点颜色。
        /// </summary>
        public Color32 toColor
        {
            get => m_ToColor;
            set
            {
                if (PropertyUtil.SetColor(ref m_ToColor, value))
                {
                    SetVerticesDirty();
                }
            }
        }

        /// <summary>
        ///     Opacity of the component. Supports value from 0 to 1, and the component will not be drawn when set to 0.
        ///     ||图形透明度。支持从 0 到 1 的数字，为 0 时不绘制该图形。
        /// </summary>
        public float opacity
        {
            get => m_Opacity;
            set
            {
                if (PropertyUtil.SetStruct(ref m_Opacity, value))
                {
                    SetVerticesDirty();
                }
            }
        }

        /// <summary>
        ///     Whether to fill only polygonal areas. Currently, only convex polygons are supported.
        ///     ||是否只填充多边形区域。目前只支持凸多边形。
        /// </summary>
        public bool innerFill
        {
            get => m_InnerFill;
            set
            {
                if (PropertyUtil.SetStruct(ref m_InnerFill, value))
                {
                    SetVerticesDirty();
                }
            }
        }

        /// <summary>
        ///     Whether to fill the gradient color to the top. The default is true, which means that the gradient color is filled
        ///     to the top.
        ///     If it is false, the gradient color is filled to the actual position.
        ///     ||渐变色是到顶部还是到实际位置。默认为true到顶部。
        /// </summary>
        public bool toTop
        {
            get => m_ToTop;
            set
            {
                if (PropertyUtil.SetStruct(ref m_ToTop, value))
                {
                    SetVerticesDirty();
                }
            }
        }

        /// <summary>
        ///     Set this to false to prevent the areafrom showing.
        ///     ||是否显示区域填充。
        /// </summary>
        public bool show
        {
            get => m_Show;
            set
            {
                if (PropertyUtil.SetStruct(ref m_Show, value))
                {
                    SetVerticesDirty();
                }
            }
        }


        public Color32 GetColor()
        {
            if (Mathf.Approximately(m_Opacity, 1))
            {
                return m_areaColor;
            }

            var localColor = m_areaColor;
            localColor.a = (byte) (localColor.a * m_Opacity);

            return localColor;
        }


        public Color32 GetColor(Color32 themeColor)
        {
            var localColor = themeColor;
            
            if (!ChartHelper.IsClearColor(localColor))
            {
                return GetColor();
            }

            localColor.a = (byte) (localColor.a * opacity);

            return localColor;
        }
    }
}