using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;
namespace FilterRLC.Models
{
    public class Transmittance
    {
        public static List<object> GetTransmittance(FilterParams filter)
        {
            double u1 = (double)filter.U1;
            double fmin = (double)filter.Fmin;
            double fmax = (double)filter.Fmax;
            double R1 = (double)filter.Resistance_1;
            double R2= (double)filter.Resistance_2;
            double L1 = (double)filter.Inductance;
            double C1 = (double)filter.Capacitance;
            int size = (int)filter.NumOfRows;

            List<object> results = new List<object>();

            Complex Z1;
            Complex Z2;
            Complex Z3;
            Complex Z4;
            Complex Z5;

            double f = fmin;
            double df = (fmax - fmin) / (size - 1);
            double omega = 0;

            results.Add(new[] { "Frequency", "Amplitude", "Phase" });

            if (f == 0)
            {
                f = 0.000000001;
            }

            for (int i = 0; i < size; i++)
            {

                omega = 2 * Math.PI * f;
                Z1 = new Complex(R1, 0);
                Z2 = new Complex(R2, 0);
                Z3 = new Complex(0, -1 / (omega * C1));
                Z4 = new Complex(0, omega * L1);

                Z5 = u1*(Z2 * Z4) / ((Z1 + Z2) * (Z3 + Z4)+Z1*Z2);
                results.Add(new[] { f, Z5.Magnitude, Z5.Phase });
                f += df;
            }

            return results;
        }
    }
}
