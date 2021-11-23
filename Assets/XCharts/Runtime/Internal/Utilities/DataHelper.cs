/************************************************/
/*                                              */
/*     Copyright (c) 2018 - 2021 monitor1394    */
/*     https://github.com/monitor1394           */
/*                                              */
/************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace XCharts
{
    internal static class DataHelper
    {
        public static double DataAverage(ref List<SerieData> showData, SampleType sampleType, int minCount, int maxCount, int rate)
        {
            double totalAverage = 0;
            if (rate > 1 && sampleType == SampleType.Peak)
            {
                double total = 0;
                for (int i = minCount; i < maxCount; i++)
                {
                    total += showData[i].data[1];
                }
                totalAverage = total / (maxCount - minCount);
            }
            return totalAverage;
        }

        public static double SampleValue(ref List<SerieData> showData, SampleType sampleType, int rate,
            int minCount, int maxCount, double totalAverage, int index, float dataChangeDuration,
            ref bool dataChanging, Axis axis)
        {
            var inverse = axis.inverse;
            double minValue = axis.context.minValue;
            double MaxValue = axis.context.maxValue;
            if (rate <= 1 || index == minCount)
            {
                if (showData[index].IsDataChanged()) dataChanging = true;
                //Debug.LogError("sample:"+index+","+rate+","+(showData[index].GetCurrData(1, dataChangeDuration, inverse, minValue, MaxValue))+","+showData[index].GetData(1));
                return showData[index].GetCurrData(1, dataChangeDuration, inverse, minValue, MaxValue);
            }
            switch (sampleType)
            {
                case SampleType.Sum:
                case SampleType.Average:
                    double total = 0;
                    var count = 0;
                    for (int i = index; i > index - rate; i--)
                    {
                        count ++;
                        total += showData[i].GetCurrData(1, dataChangeDuration, inverse, minValue, MaxValue);
                        if (showData[i].IsDataChanged()) dataChanging = true;
                    }
                    //Debug.LogError("sample:"+index+","+rate+","+count+","+total);
                    if (sampleType == SampleType.Average) return total / rate;
                    else return total;
                case SampleType.Max:
                    double max = double.MinValue;
                    for (int i = index; i > index - rate; i--)
                    {
                        var value = showData[i].GetCurrData(1, dataChangeDuration, inverse, minValue, MaxValue);
                        if (value > max) max = value;
                        if (showData[i].IsDataChanged()) dataChanging = true;
                    }
                    return max;
                case SampleType.Min:
                    double min = double.MaxValue;
                    for (int i = index; i > index - rate; i--)
                    {
                        var value = showData[i].GetCurrData(1, dataChangeDuration, inverse, minValue, MaxValue);
                        if (value < min) min = value;
                        if (showData[i].IsDataChanged()) dataChanging = true;
                    }
                    return min;
                case SampleType.Peak:
                    max = double.MinValue;
                    min = double.MaxValue;
                    total = 0;
                    for (int i = index; i > index - rate; i--)
                    {
                        var value = showData[i].GetCurrData(1, dataChangeDuration, inverse, minValue, MaxValue);
                        total += value;
                        if (value < min) min = value;
                        if (value > max) max = value;
                        if (showData[i].IsDataChanged()) dataChanging = true;
                    }
                    var average = total / rate;
                    if (average >= totalAverage) return max;
                    else return min;
            }
            if (showData[index].IsDataChanged()) dataChanging = true;
            return showData[index].GetCurrData(1, dataChangeDuration, inverse, minValue, MaxValue);
        }
    }
}