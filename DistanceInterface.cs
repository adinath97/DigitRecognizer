using System;
namespace Classification_DigitRecognition
{
    public interface DistanceInterface
    {
        //goal: compute 'distance' between the pixel sets of two elements passed in
        double Between(int[] pixels1, int[] pixels2);
    }
}
