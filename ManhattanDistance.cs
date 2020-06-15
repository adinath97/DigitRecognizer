using System;
namespace Classification_DigitRecognition
{
    public class ManhattanDistance : DistanceInterface
    {
        public double Between(int[] pixels1, int[] pixels2)
        {
            //first ensure that both images have the same 'dimensions'--same number of pixels. if not, through an error
            if(pixels1.Length != pixels2.Length)
            {
                Console.WriteLine(pixels1.Length);
                Console.WriteLine(pixels2.Length);
                throw new ArgumentException("Inconsistent image sizes. Ensure inputs have same number of pixels");
            }
            /*
             declare distance to be 0, and find the length of one of the inputs.
             without loss of generality, we can pick pixels1
            */
            var length = pixels1.Length;
            var distance = 0;
            /* 
             * For every pixel, compute the difference, then add it to the distance
             * The greater the distance, the more "different" two images are.
             */
            for(int i = 0; i < length; i++)
            {
                distance += Math.Abs(pixels1[i] - pixels2[i]);
            }
            return distance;
        }
    }
}
