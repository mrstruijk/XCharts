/************************************************/
/*                                              */
/*     Copyright (c) 2018 - 2021 monitor1394    */
/*     https://github.com/monitor1394           */
/*                                              */
/************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace XCharts
{
    [UnityEngine.Scripting.Preserve]
    internal sealed class ParallelAxisHander : AxisHandler<ParallelAxis>
    {
        private Orient m_Orient;
        protected override Orient orient { get { return m_Orient; } }

        public override void InitComponent()
        {
            InitParallelAxis(component);
        }

        public override void Update()
        {
            UpdateContext(component);
            UpdateAxisMinMaxValue(component.index, component);
            //UpdatePointerValue(component);
        }

        public override void DrawBase(VertexHelper vh)
        {
            UpdateContext(component);
            DrawParallelAxisSplit(vh, component);
            DrawParallelAxisLine(vh, component);
            DrawParallelAxisTick(vh, component);
        }

        private void UpdateContext(ParallelAxis axis)
        {
            var parallel = chart.GetChartComponent<ParallelCoord>(axis.parallelIndex);
            if (parallel == null)
                return;

            m_Orient = parallel.orient;
            axis.context.parallel = parallel;
            var axisCount = chart.GetChartComponentNum<ParallelAxis>();

            if (m_Orient == Orient.Horizonal)
            {
                var each = parallel.context.height / (axisCount - 1);
                axis.context.x = parallel.context.x;
                axis.context.y = parallel.context.y + (axis.index) * each;
                axis.context.width = parallel.context.width;
            }
            else
            {
                var each = parallel.context.width / (axisCount - 1);
                axis.context.x = parallel.context.x + (axis.index) * each;
                axis.context.y = parallel.context.y;
                axis.context.width = parallel.context.height;
            }
            axis.context.orient = m_Orient;
            axis.context.height = 0;
            axis.context.position = new Vector3(axis.context.x, axis.context.y);
        }

        private void InitParallelAxis(ParallelAxis axis)
        {
            var theme = chart.theme;
            var xAxisIndex = axis.index;
            axis.painter = chart.painter;
            axis.refreshComponent = delegate ()
            {
                UpdateContext(axis);
                InitAxis(axis, null, chart, this,
                    m_Orient,
                    axis.context.x,
                    axis.context.y,
                    axis.context.width,
                    axis.context.height);
            };
            axis.refreshComponent();
        }

        internal override void UpdateAxisLabelText(Axis axis)
        {
            base.UpdateAxisLabelText(axis);
            if (axis.IsTime() || axis.IsValue())
            {
                for (int i = 0; i < axis.context.labelObjectList.Count; i++)
                {
                    var label = axis.context.labelObjectList[i];
                    if (label != null)
                    {
                        var pos = GetLabelPosition(0, i);
                        label.SetPosition(pos);
                        CheckValueLabelActive(component, i, label, pos);
                    }
                }
            }
        }

        protected override Vector3 GetLabelPosition(float scaleWid, int i)
        {
            if (component.context.parallel == null)
                return Vector3.zero;

            return GetLabelPosition(i, m_Orient, component, null,
                chart.theme.axis,
                scaleWid,
                component.context.x,
                component.context.y,
                component.context.width,
                component.context.height);
        }

        private void DrawParallelAxisSplit(VertexHelper vh, ParallelAxis axis)
        {
            if (AxisHelper.NeedShowSplit(axis))
            {
                if (axis.context.parallel == null)
                    return;

                var dataZoom = chart.GetDataZoomOfAxis(axis);

                DrawAxisSplit(vh, axis, chart.theme.axis, dataZoom,
                    m_Orient,
                    axis.context.x,
                    axis.context.y,
                    axis.context.width,
                    axis.context.height);
            }
        }

        private void DrawParallelAxisTick(VertexHelper vh, ParallelAxis axis)
        {
            if (AxisHelper.NeedShowSplit(axis))
            {
                if (axis.context.parallel == null)
                    return;

                var dataZoom = chart.GetDataZoomOfAxis(axis);

                DrawAxisTick(vh, axis, chart.theme.axis, dataZoom,
                    m_Orient,
                    axis.context.x,
                    axis.context.y,
                    axis.context.width);
            }
        }

        private void DrawParallelAxisLine(VertexHelper vh, ParallelAxis axis)
        {
            if (axis.show && axis.axisLine.show)
            {
                if (axis.context.parallel == null)
                    return;

                DrawAxisLine(vh, axis,
                    chart.theme.axis,
                    m_Orient,
                    axis.context.x,
                    axis.context.y,
                    axis.context.width);
            }
        }
    }
}