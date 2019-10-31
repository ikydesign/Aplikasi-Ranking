using System;
using static System.Console;

namespace RANKING_03
{
    class Program
    {
        public void TUKAR(double[] A, string[] NR, string[] NM, int S, int P)
        {
            double C = A[S]; A[S] = A[P]; A[P] = C;
            string Cc = NM[S]; NM[S] = NM[P]; NM[P] = Cc;
            string CC = NR[S]; NR[S] = NR[P]; NR[P] = CC;
        }

        public void SELECTION(string[] NR, double[] A, string[] NM, int F)
        {
            int N = A.Length, S, P = 0;
            for (int X = 0; X < N -1; X++)
            {
                S = X; P = X;
                for (int Y = X +1; Y < N; Y++)
                {
                    if (F == 0) if (string.Compare(NR[P], NR[Y]) > 0) P = Y;
                    if (F == 1) if (string.Compare(NM[P], NM[Y]) > 0) P = Y;
                    if (F == 2) if (A[P] < A[Y]) P = Y;
                }
                if (S != P) TUKAR(A, NR, NM, S, P);
            }
        }

        public void DISPLAY(string[] NR, double[] NL, string[] NM)
        {
            double TN1 = 0;
            Clear(); Write("\n");
            WriteLine(" +--------------------+");
            WriteLine(" | NO.| Nama | Nilai  |");
            WriteLine(" +----+------+--------+");

            for (int X = 0; X < 20; X++)
            {
                WriteLine(" | {0} | {1,-6} | {2:0.00} |", NR[X], NM[X], NL[X]);
                TN1 += NL[X];
            }
            WriteLine(" +-----------+--------+");
            WriteLine(" | Rata2 Tes | {0:0.00} |", TN1 / 20);
            WriteLine(" +-----------+--------+");
        }

        static void Main()
        {
            string[] NM = { "DANI", "DINA","NADI","DIAN","ANDI",
                            "BONAR", "HENI","BINA","JOGI","FANI",
                            "INDAH", "ERNI","IRMA","ERIKA","EDI",
                            "CITRA", "JULITA","GEA","SIMA","ASMI",
                            "RISA", "SARI","IRSA","BORIS","FERDI",
                            "ARDI", "IRA","CITA","IRDA","DIAR",
                            "FIA", "RITA","TIAR","GINA","TRIA",
                            "LINA", "NILA", "ALIN","ALIN","DELANI" };
            double[] NL = new double[20]; int F;
            string[] NR = new string[20]; string NO;
            Random R = new Random();

            for (int X = 0; X <20; X++)
            {
                NO = ((X + 101).ToString());
                NR[X] = NO.Substring(1, 2);
                NL[X] = R.Next(70, 99) + R.NextDouble();
            }

            Program P1 = new Program(); P1.DISPLAY(NR, NL, NM);

            loop:
            Write(" Sort by [0/1/2] "); F = int.Parse(ReadLine());
            Program P2 = new Program(); P2.SELECTION(NR, NL, NM, F);
            Program P3 = new Program(); P3.DISPLAY(NR, NL, NM);
            if (F >= 0 && F <= 2) goto loop;
            ReadKey();



        }
    }
}
