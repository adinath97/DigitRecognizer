﻿using System;
namespace Classification_DigitRecognition
{
    public class Observation
    {
        public Observation(string label, int[] pixels)
        {
            this.Label = label;
            this.Pixels = pixels;
        }

        public string Label { get; private set; }
        public int[] Pixels { get; private set; }
    }
}
