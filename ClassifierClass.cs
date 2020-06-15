using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Classification_DigitRecognition
{
    public class ClassifierClass : ClassifierInterface
    {
        //first, get the collection of observations
        private IEnumerable<Observation> data;
        //create distance variable 
        private readonly DistanceInterface distance;

        //whatever distance is passed in, assign it to the distance variable in this class
        public ClassifierClass(DistanceInterface distance1)
        {
            this.distance = distance1;
        }

        //let the passed in data set be equivalent to the data set in this class
        public void Train(IEnumerable<Observation> trainingSet)
        {
            //let the data here be the collection of observations
            this.data = trainingSet;
        }

        public string Predict(int[] pixels)
        {
            //initially, we don't have a "closest" observation, but this will get updated as we iterate
            Observation current_Best = null;
            /* 
             * let the initial shortest distance be the biggest value a double can be. This way
             * you ensure there is no possibility of missing/excluding a possible distance calculation
             */
            var shortest = Double.MaxValue;
            foreach(Observation obs in this.data)
            {
                //calculate distance between current obs pixels and pixels passed in
                var dist = this.distance.Between(obs.Pixels, pixels);
                /*
                 * if distance between current obs and pixels for test case is less than previous shortest,
                 * update accordingly. This obs then becomes our 'best fit' until and unless we find an
                 * ever closer/better fit (ie. an obs with a shorter associated distance)
                 */
                if(dist < shortest)
                {
                    shortest = dist;
                    current_Best = obs;
                }
            }
            //return label of out 'best match'
            return current_Best.Label;
        }
    }
}
