using System;
using System.Linq;
using System.IO;

namespace Classification_DigitRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate object of class ManhattanDistance
            var distance = new ManhattanDistance();
            /*
             * instantiate object of class ClassifierClass, and pass in distance above as the parameter
             * as that is how the classifer is defined. It takes the distance then does it's thing.
            */
            var classifier = new ClassifierClass(distance);

            /************/
            /* TRAINING */
            /************/

            //store in a variable the path to the file containing the training data set
            var trainingPath = @"/Users/adityaiyengar/Documents/C#/DigitRecognition/Classification-DigitRecognition/train.csv";
            /* 
             * store in a variable the output obtained when the training data is passed into
             * read and the collection of observations is created using the Read_Observations function
             */
            var training = DataReader.Read_Observations(trainingPath);
            /* 
             * now that you have the collection of observations, replace the data set inside classifier 
             * with the training data (training collection of observations). This is the data set against which
             * the program will check each "unknown" against. Among the data set, the program will find the closest
             * match to the unknown and declare that unknown's label is equivalent to the label of the closest match
             * 
            */
            classifier.Train(training);

            /**************/
            /* VALIDATION */
            /**************/

            //store in a variable the path to the file containing the validation data set
            var validationPath = @"/Users/adityaiyengar/Documents/C#/DigitRecognition/Classification-DigitRecognition/train_2.csv";
            /* 
             * store in a variable the output obtained when the validation data is passed into
             * read and the collection of observations is created using the Read_Observations function
             */
            var validation = DataReader.Read_Observations(validationPath);

            /*
             * now we call the Correct function from the Evaluator class to calculate the accuracy of the model.
             * Pass in the validation set of observations and the classifier as parameters so that, for each
             * observation, you can use the classifier to make the prediction and then evaluate the prediction
             * using the score function inside Correct
            */
            var correct = Evaluator.Correct(validation, classifier);
            double correct_percentage = correct * 100;
            Console.WriteLine("Percentage Correction: " + correct_percentage + " %");
            Console.ReadLine();
        }
    }
}
