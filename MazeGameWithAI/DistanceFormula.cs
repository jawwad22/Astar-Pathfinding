using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGameWithAI
{
    class DistanceFormula
    {
        public static int Formula(int XA, int YA, int XB, int YB)
        {
            //
            int bracketOne = XA - XB;
            int bracketTwo = YA - YB;

            int bracketThree = Math.Abs(bracketOne + bracketTwo);

            return bracketThree;

        }
        public static int RetMin(List<int> arr)
        {
            int min = arr.Min();
            int index = 0;
            for (int i = 0; i <= arr.Count - 1; i++)
            {
                if (arr[i] == min)
                {
                    index = i;
                }
            }
            return index;
        }
    }
}
