﻿using MathLib.Data;
using System.Text;

namespace MathLib.MathMethods.Lyapunov {
    public abstract class LyapunovMethod {

        protected StringBuilder Log;

        protected double[] timeSeries;
        public Timeseries slope;

        public LyapunovMethod(double[] timeSeries) {
            this.timeSeries = timeSeries;
            slope = new Timeseries();
            Log = new StringBuilder();
        }

        public abstract void Calculate();

        public abstract string GetInfoShort();

        public abstract string GetInfoFull();
    }
}