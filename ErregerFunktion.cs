using System;
using System.Collections.Generic;
using System.IO;
using PP_Integrator_Test1;

namespace PP_Integrator_Test1
{

    // Verwaltet die Bodenanregung (Position, Geschwindigkeit, Beschleunigung) anhand einer Funktion oder einer Zeitreihe.
    // Unterstützt Sinus, Double-Sinus, Impuls, Dateiimport.
    public class ErregerFunktion
    {
        private readonly double h;
        private Func<double, double> positionFunc = _ => 0.0;

        public Func<double, double> Position { get; private set; }
        public Func<double, double> Velocity { get; private set; }
        public Func<double, double> Acceleration { get; private set; }

        public ErregerFunktion(Func<double, double> positionFunc, Func<double, double> velocityFunc)
        {
            Position = positionFunc;
            Velocity = velocityFunc;
        }


        public void SetPositionFunction(Func<double, double> f)
        {
            positionFunc = f;
            Position = f;
            Velocity = t => (f(t + h) - f(t - h)) / (2 * h);
            Acceleration = t => (f(t + h) - 2 * f(t) + f(t - h)) / (h * h);
        }

        // Vorgefertigte Erregerfunktionen 

        public static ErregerFunktion Sinus(double amplitude, double frequency)
        {
            return new ErregerFunktion(
            t => amplitude * Math.Cos(2 * Math.PI * frequency * t),
            t => -amplitude * 2 * Math.PI * frequency * Math.Sin(2 * Math.PI * frequency * t));

        }

        public static ErregerFunktion DoubleSinus(double amplitude1, double freq1, double amplitude2, double freq2)
        {
            return new ErregerFunktion(
            t => amplitude1 * Math.Cos(2 * Math.PI * freq1 * t) + amplitude2 * Math.Cos(2 * Math.PI * freq2 * t),
            t => -amplitude1 * 2 * Math.PI * freq1 * Math.Sin(2 * Math.PI * freq1 * t)
             - amplitude2 * 2 * Math.PI * freq2 * Math.Sin(2 * Math.PI * freq2 * t));

        }

        public static ErregerFunktion Rechteckimpuls(double amplitude, double dauer)
        {
            return new ErregerFunktion(
            t => (t < dauer) ? amplitude : 0,
            t => 0); // Geschwindigkeit ist 0 bei idealem Rechteckimpuls);

        }

        // Lädt eine Zeitreihe aus einer CSV-Datei (t[s], displacement[m]) und interpoliert sie linear.
        public static ErregerFunktion AusDatei(string pfad)
        {
            var zeiten = new List<double>();
            var werte = new List<double>();
            foreach (var zeile in File.ReadLines(pfad))
            {
                var teile = zeile.Split(';');
                if (teile.Length >= 2 && double.TryParse(teile[0], out double t) && double.TryParse(teile[1], out double x))
                {
                    zeiten.Add(t);
                    werte.Add(x);
                }
            }

            return new ErregerFunktion(CreateInterpolation(zeiten.ToArray(), werte.ToArray()),
                t => 0.0); //Dummy-Geschwindigkeitsfunktion
        }

        private static Func<double, double> CreateInterpolation(double[] t, double[] x)
        {
            return time =>
            {
                if (time <= t[0]) return x[0];
                if (time >= t[^1]) return x[^1];

                for (int i = 0; i < t.Length - 1; i++)
                {
                    if (time >= t[i] && time <= t[i + 1])
                    {
                        double alpha = (time - t[i]) / (t[i + 1] - t[i]);
                        return x[i] * (1 - alpha) + x[i + 1] * alpha;
                    }
                }
                return 0;
            };
        }
    }
}
