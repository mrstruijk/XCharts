using System;
using UnityEngine;


namespace XCharts.Runtime
{
    /// <summary>
    ///     Settings related to axis line.
    ///     ||坐标轴轴线。
    /// </summary>
    [Serializable]
    public class AxisLine : BaseLine
    {
        [SerializeField] private bool m_OnZero;
        [SerializeField] private bool m_ShowArrow;
        [SerializeField] private ArrowStyle m_Arrow = new();

        /// <summary>
        ///     When mutiple axes exists, this option can be used to specify which axis can be "onZero" to.
        ///     ||X 轴或者 Y 轴的轴线是否在另一个轴的 0 刻度上，只有在另一个轴为数值轴且包含 0 刻度时有效。
        /// </summary>
        public bool onZero
        {
            get => m_OnZero;
            set
            {
                if (PropertyUtil.SetStruct(ref m_OnZero, value))
                {
                    SetVerticesDirty();
                }
            }
        }

        /// <summary>
        ///     Whether to show the arrow symbol of axis.
        ///     ||是否显示箭头。
        /// </summary>
        public bool showArrow
        {
            get => m_ShowArrow;
            set
            {
                if (PropertyUtil.SetStruct(ref m_ShowArrow, value))
                {
                    SetVerticesDirty();
                }
            }
        }

        /// <summary>
        ///     the arrow of line.
        ///     ||轴线箭头。
        /// </summary>
        public ArrowStyle arrow
        {
            get => m_Arrow;
            set
            {
                if (PropertyUtil.SetClass(ref m_Arrow, value))
                {
                    SetVerticesDirty();
                }
            }
        }

        public static AxisLine defaultAxisLine
        {
            get
            {
                var axisLine = new AxisLine
                {
                    m_Show = true,
                    m_OnZero = true,
                    m_ShowArrow = false,
                    m_Arrow = new ArrowStyle(),
                    m_LineStyle = new LineStyle(LineStyle.Type.None)
                };

                return axisLine;
            }
        }


        public AxisLine Clone()
        {
            var axisLine = new AxisLine();
            axisLine.show = show;
            axisLine.onZero = onZero;
            axisLine.showArrow = showArrow;
            axisLine.arrow = arrow.Clone();

            return axisLine;
        }


        public void Copy(AxisLine axisLine)
        {
            base.Copy(axisLine);
            onZero = axisLine.onZero;
            showArrow = axisLine.showArrow;
            arrow.Copy(axisLine.arrow);
        }
    }
}