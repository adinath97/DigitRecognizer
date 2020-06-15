using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Classification_DigitRecognition
{
    public class DataReader
    {
        //create observations from individual lines passed in. data reader
        private static Observation Create_Observation(string data)
        {
            //for every string of data passed in, split the string at every comma
            var commaSeparated = data.Split(',');
            //take the first element of data and store it in label (b/c it is the label?)
            var label = commaSeparated[0];
            /*
            the rest of the elements in the array are pixels. Skip the first element in
            the variable, take each string pixel and convert it to an int, then add it
            to an array of such elements, and call that array pixels.
            */
            var pixels = commaSeparated
                .Skip(1)
                .Select(x => Convert.ToInt32(x))
                .ToArray();
            //return observation associated with the particular data string passed in
            return new Observation(label, pixels);
        }

        /*
         * function below runs the Create_Observation function for each line, and thus creates an
         * observation for each, adds it to the collection of observations that it then outputs
        */
        //data reader + storage (which calls the function that reads)
        public static Observation[] Read_Observations(string dataPath)
        {
            /* when passed in a file, read all the lines, skip the first one (labeling), create
             * observation from that line, then add that observation to an array of observations
             */
            /* File.ReadAllLines opens the file passed in, reads/copies whatever, then closes it*/
            var data = File.ReadAllLines(dataPath)
                .Skip(1)
                .Select(Create_Observation)
                .ToArray();
            return data;
        }
    }
}
