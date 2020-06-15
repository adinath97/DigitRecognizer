using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Classification_DigitRecognition
{
    public class Evaluator
    {
        //pass in validation set and classifier as parameters for the evaluation function
        public static double Correct(IEnumerable<Observation> validationSet,
            ClassifierInterface classifier)
        {
            //run the score function for each obs, then average out the scores to get the overall accuracy
            return validationSet
                .Select(obs => Score(obs, classifier))
                .Average();
        }

        private static double Score(Observation obs, ClassifierInterface classifier)
        {
            //pass in an observation and the classifier
            //if the classifier's predicted label (based on the pixel input) equals the actual label, accuracy = 1. else, it's 0
            if(classifier.Predict(obs.Pixels) == obs.Label)
            {
                return 1; //perfect accuracy/score
            }
            else
            {
                return 0; //inaccurate. predicted label didn't match actual label
            }
        }
    }
}
