using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Classification_DigitRecognition
{
    public interface ClassifierInterface
    {
        //function for training in classification
        void Train(IEnumerable<Observation> trainingSet);
        //function for predicting from actual test cases/sets
        string Predict(int[] pixels);
    }
}
