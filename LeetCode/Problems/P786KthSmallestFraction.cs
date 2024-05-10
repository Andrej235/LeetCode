using LeetCode.Utility;

namespace LeetCode.Problems
{
    public class P786KthSmallestFraction : IProblemSolver<TestCaseWrapper<P786KthSmallestFraction.P786Input, int[]>, int[]>
    {
        public record P786Input(int[] Arr, int K) : ITestCaseInput;

        public TestCaseWrapper<P786Input, int[]>[] TestCases => [
                new(new([1,2,3,5], 3), [2, 5]),
                new(new([1,7], 1), [1,7]),
                new(new([1,2,47,149,211,541,613,631,643,647,919, 1033,1187,1237,1451,1669,1907,1979,2003,2081,2281,2339,2383,2473,2609,2663,2857,2909,3167,3319,3373,3467,3499,3557,3889,4111,4133,4289,4751,4813,4969,5179,5479,5531,5737,5839,5851,5857,5953,6079,6101,6173,6247,6581,6607,6679,6733,6917,6971,7481,7499,7523,7589,7717,7723,7841,7907,8219,8233,8243,8369,8647,8663,9281,9343,9601,9631,9679,9833,10069,10091,10531,10949,11027,11779,11839,11987,12097,12149,12239,12373,12457,12659,12703,12853,12923,13033,13291,13327,13367,13553,13763,13931,14071,14419,14593,14683,14891,15017,15073,16067,16319,16519,16607,16657,16741,16943,16963,17033,17401,17471,17477,17683,17729,17807,17851,17881,18089,18379,18481,18523,18553,18617,18859,19403,19777,19991,20011,20023,20107,20269,20897,21397,21601,21911,22171,22259,22273,22531,22549,22619,22691,22787,22871,23021,23029,23041,23081,23561,23887,24203,24469,24527,24593,24917,25013,25163,25169,25219,25601,25819,26029,26821,26861,27241,27361,27527,27541,27581,27673,27743,28181,28439,28463,28619,28867,28979,29017,29033,29059,29101,29131,29167,29179,29251,29327,29527,29581,29599,29927], 8752), [2473,6679]),
                new(new([1,19,71,107,307,367,419,1009,1153,1297,1373,1693,1931,2389,2609,2731,2917,3461,3613,3677,4001,4013,4201,4513,4691,5323,5333,5503,6701,7283,7433,7621,7673,8053,8191,8387,9043,9239,9433,9923,10321,10627,10639,10723,11279,11411,11779,11801,12437,12473,12703,13799,13997,14051,14251,14653,14683,14759,14797,15091,15149,15217,16987,17467,18253,18541,18731,19051,19259,19813,19963,20149,20347,20369,20879,20899,21521,22079,22571,22709,22783,22859,23087,23567,23593,24847,24917,25117,25601,25903,26029,26407,26437,26573,27271,27803,27901,27961,28307,29017], 4733), [19259,20369])
            ];

        public int[] Solve(object testCaseInput)
        {
            if (testCaseInput is not P786Input input)
                throw new ArgumentException(null, nameof(testCaseInput));

            return KthSmallestPrimeFraction(input.Arr, input.K);
        }

        public int[] KthSmallestPrimeFraction(int[] arr, int k)
        {
            int n = arr.Length;
            float left = 0;
            float right = 1;

            while (true)
            {
                float mid = (left + right) / 2;
                int j = 0; //Index of the current bottom value (arr[i]/arr[j])
                int numberOfSmallerFractions = 0;

                float maxFraction = 0; //Maximum fraction is the answer if numberOfSmallerFractions is equal to k
                int topNumberIndex = 0;
                int bottomNumberIndex = 0;

                for (int i = 0; i < n - 1; i++)
                {
                    while (j < n && arr[i] >= mid * arr[j])
                        j++;

                    if (j == n) break;

                    numberOfSmallerFractions += n - j; //Every number after 'j' is bigger than 'j' an so the fraction is smaller as 'i' remains the same

                    if (maxFraction < (float)arr[i] / arr[j])
                    {
                        topNumberIndex = i;
                        bottomNumberIndex = j;
                        maxFraction = (float)arr[i] / arr[j];
                    }
                }

                if (numberOfSmallerFractions == k)
                    return [arr[topNumberIndex], arr[bottomNumberIndex]];
                else if (numberOfSmallerFractions < k)
                    left = mid; //If there are too few smaller fractions, increase the range
                else
                    right = mid; //If there are too many smaller fractions, reduce the range
            }
        }
    }
}
