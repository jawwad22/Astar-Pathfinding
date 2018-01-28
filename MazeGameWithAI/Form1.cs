using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGameWithAI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Label[,] Squares;
        List<int> OpenX = new List<int>();
        List<int> OpenY = new List<int>();
        List<int> CloseX = new List<int>();
        List<int> CLoseY = new List<int>();
        int PointXA, PointYA, PointXB, PointYB;
        int CurrentSPX, CurrentSPY;// current Shortest Path X and Shortest Path Y
        List<int> G = new List<int>();
        List<int> H = new List<int>();
        List<int> F = new List<int>();
        int MinimumF;

        private void Form1_Load(object sender, EventArgs e)
        {
            Squares = new Label[,]
            {
            {Nodes00,Nodes01,Nodes02,Nodes03,Nodes04,Nodes05,Nodes06},
            {Node10,Nodes11,Nodes12,Nodes13,Nodes14,Nodes15,Nodes16},
            {Nodes20,Nodes21,Nodes22,Nodes23,Nodes24,Nodes25,Nodes26},
            {Nodes30,Nodes31,Nodes32,Nodes33,Nodes34,Nodes35,Nodes36},
            {Nodes40,Nodes41,Nodes42,Nodes43,Nodes44,Nodes45,Nodes46},
            {Nodes50,Nodes51,Nodes52,Nodes53,Nodes54,Nodes55,Nodes56},        
            };
            Squares[1, 1].BackColor = Color.Blue; //Point A
            Squares[4, 4].BackColor = Color.Red; //Point B

            #region ObstacleMaking
            Squares[1, 2].BackColor = Color.Yellow;
            Squares[2, 3].BackColor = Color.Yellow;
            Squares[3, 3].BackColor = Color.Yellow;
            Squares[4, 3].BackColor = Color.Yellow;
            Squares[4, 1].BackColor = Color.Yellow;
           ;
            #endregion
            #region Find Point A and Point B put the Location in OpenX and OpenY

            for (int Y = 0; Y <= 6; Y++)
            {
                for (int X = 0; X <= 5; X++)
                {
                    if (Squares[X, Y].BackColor == Color.Red)
                    {

                        PointXB = X;
                        PointYB = Y;
                        continue;
                    }
                    else if (Squares[X, Y].BackColor == Color.Blue)
                    {

                        PointXA = X;
                        PointYA = Y;
                        continue;

                    }
                    continue;
                }
                continue;
            }
            CurrentSPY = PointXA;
            CurrentSPX = PointYA;


            #endregion
        }

        private void TimerPerTick_Tick(object sender, EventArgs e)
        {
            int LeftX, LeftY;
            int DownX, DownY;
            int UpX, UpY;
            int RightX, RightY;

            LeftX = CurrentSPX - 1;
            LeftY = CurrentSPY;
            RightX = CurrentSPX + 1;
            RightY = CurrentSPY;
            UpX = CurrentSPX;
            UpY = CurrentSPY - 1;
            DownX = CurrentSPX;
            DownY = CurrentSPY + 1;

            CloseX.Add(CurrentSPX);
            CLoseY.Add(CurrentSPY);

            if (!(LeftX > 5 || LeftY >= 6))
            {
                if (Squares[LeftY, LeftX].BackColor != Color.Yellow)
                {
                    OpenX.Add(LeftX);
                    OpenY.Add(LeftY);
                    int LeftSideG = DistanceFormula.Formula(CurrentSPX, CurrentSPY, LeftX, LeftY);
                    int LeftSideH = DistanceFormula.Formula(PointXB, PointYB, LeftX, LeftY);

                    G.Add(LeftSideG);
                    H.Add(LeftSideH);
                    F.Add(LeftSideG + LeftSideH);
                }//end of if
            }//end of IF
            if (!(DownX > 5 || DownY >= 6))
            {
                if (Squares[DownY, DownX].BackColor != Color.Yellow)
                {
                    OpenX.Add(DownX);
                    OpenY.Add(DownY);
                    int DownSideH = DistanceFormula.Formula(PointXB, PointYB, DownX, DownY);
                    int DownSideG = DistanceFormula.Formula(CurrentSPX, CurrentSPY, DownX, DownY);
                    G.Add(DownSideG);
                    H.Add(DownSideH);
                    F.Add(DownSideG + DownSideH);
                }//end of if
            }//end of if
            if (!(RightX > 5 || RightY >= 6))
            {
                if (Squares[RightY, RightX].BackColor != Color.Yellow)
                {
                    OpenX.Add(RightX);
                    OpenY.Add(RightY);
                    int RightSideG = DistanceFormula.Formula(CurrentSPX, CurrentSPY, RightX, RightY);
                    int RightSideH = DistanceFormula.Formula(PointXB, PointYB, RightX, RightY);
                    G.Add(RightSideG);
                    H.Add(RightSideH);
                    F.Add(RightSideG + RightSideH);
                }//end of if
            }//end of if
            if (!(UpX > 5 || UpY >= 6))
            {
                if (Squares[UpY, UpX].BackColor != Color.Yellow)
                {
                    OpenX.Add(UpX);
                    OpenY.Add(UpY);
                    int UpSideG = DistanceFormula.Formula(CurrentSPX, CurrentSPY, UpX, UpY);
                    int UpSideH = DistanceFormula.Formula(PointXB, PointYB, UpX, UpY);
                    G.Add(UpSideG);
                    H.Add(UpSideH);
                    F.Add(UpSideG + UpSideH);
                }//end of if
            }//end of if

            MinimumF = DistanceFormula.RetMin(F);
            CLoseY.Add(OpenY[MinimumF]);
            CloseX.Add(OpenX[MinimumF]);
            Squares[OpenY[MinimumF], OpenX[MinimumF]].BackColor = Color.Green;
            CurrentSPX = OpenX[MinimumF];
            CurrentSPY = OpenY[MinimumF];
            OpenY.RemoveAt(MinimumF);
            OpenX.RemoveAt(MinimumF);
            G.RemoveAt(MinimumF);
            H.RemoveAt(MinimumF);
            F.RemoveAt(MinimumF);
           




        }
    }
}
