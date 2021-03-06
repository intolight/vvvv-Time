﻿using System;
using VVVV.PluginInterfaces.V2;
using VVVV.Packs.Timing;

namespace VVVV.Packs.Timing.Nodes
{

    #region PluginInfo
    [PluginInfo(Name = "EQ", Category = "Time", Help = "Compares two times and returns 1 if they are equal", Tags = "TimeSpan", Author = "tmp")]
    #endregion PluginInfo
    public class EqualsTimeNode : IPluginEvaluate
    {
        #region fields & pins
        [Input("Time 1")]
        public ISpread<Time> FInput1;

        [Input("Time 2")]
        public ISpread<Time> FInput2;

        [Input("Epsilon")]
        public ISpread<TimeSpan> FEpsilon;

        [Output("Output")]
        public ISpread<bool> FOutput;

        #endregion fields & pins
        public void Evaluate(int SpreadMax)
        {
            FOutput.SliceCount = SpreadMax;
            for (int i = 0; i < SpreadMax; i++)
            {
                DateTime epsilonHigh = FInput2[i].UniversalTime + FEpsilon[i];
                DateTime epsilonLow = FInput2[i].UniversalTime - FEpsilon[i];
                if (FInput1[i].UniversalTime.CompareTo(epsilonLow) >= 0 && FInput1[i].UniversalTime.CompareTo(epsilonHigh) <= 0)
                    FOutput[i] = true;
                else FOutput[i] = false;
            }
        }
    }

    #region PluginInfo
    [PluginInfo(Name = "GT", Category = "Time", Help = "Compares two Times and returns 1 if time1 is gt time2.", Tags = "", Author = "tmp")]
    #endregion PluginInfo
    public class AfterTimeNode : IPluginEvaluate
    {
        #region fields & pins
        [Input("Time 1")]
        public ISpread<Time> FInput1;

        [Input("Time 2")]
        public ISpread<Time> FInput2;

        [Output("Output")]
        public ISpread<bool> FOutput;

        #endregion fields & pins
        public void Evaluate(int SpreadMax)
        {
            FOutput.SliceCount = SpreadMax;
            for (int i = 0; i < SpreadMax; i++)
            {
                FOutput[i] = FInput1[i] > FInput2[i];
            }
        }
    }

    #region PluginInfo
    [PluginInfo(Name = "LT", Category = "Time", Help = "Compares two times and returns 1 if time1 is lt time2.", Tags = "", Author = "tmp")]
    #endregion PluginInfo
    public class BeforeTimeNode : IPluginEvaluate
    {
        #region fields & pins
        [Input("Time 1")]
        public ISpread<Time> FInput1;

        [Input("Time 2")]
        public ISpread<Time> FInput2;

        [Output("Output")]
        public ISpread<bool> FOutput;

        #endregion fields & pins
        public void Evaluate(int SpreadMax)
        {
            FOutput.SliceCount = SpreadMax;
            for (int i = 0; i < SpreadMax; i++)
            {
                FOutput[i] = FInput1[i] < FInput2[i];
            }
        }
    }
}
