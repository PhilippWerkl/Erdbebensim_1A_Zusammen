using System;

namespace PP_Integrator_Test1
{
    public class RK4Integrator
    {
        private Building building;              // Referenz auf das zu simulierende Gebäude
        private double groundPosition = 0.0;    // Aktuelle Bodenverschiebung (z. B. durch Erdbeben)
        private double groundVelocity = 0.0;    // Aktuelle Bodengeschwindigkeit

        public RK4Integrator(Building building)
        {
            this.building = building;
        }

        
        // Legt die momentane Bodenverschiebung und -geschwindigkeit fest,
        // die als Anregung in ComputeDerivative eingespeist werden.
        public void SetGroundMotion(double position, double velocity)
        {
            this.groundPosition = position;
            this.groundVelocity = velocity;
        }

        
        // Führt einen Zeitschritt der RK4-Integration aus.
        // dt = Schrittweite, t = aktuelle Zeit
        public void Step(double dt, double t)
        {
            double[] y = building.GetStateVector();

            // Berechnung der 4 Zwischenschritte k1 bis k4
            double[] k1 = building.ComputeDerivative(t, y, groundPosition, groundVelocity);
            double[] k2 = building.ComputeDerivative(t + dt / 2, AddVectors(y, MultiplyVector(k1, dt / 2)), groundPosition, groundVelocity);
            double[] k3 = building.ComputeDerivative(t + dt / 2, AddVectors(y, MultiplyVector(k2, dt / 2)), groundPosition, groundVelocity);
            double[] k4 = building.ComputeDerivative(t + dt, AddVectors(y, MultiplyVector(k3, dt)), groundPosition, groundVelocity);

            // Neue Zustände y(t+dt)
            double[] y_new = new double[y.Length];
            for (int i = 0; i < y.Length; i++)
            {
                y_new[i] = y[i] + dt / 6.0 * (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]);
            }

            // Rückspeichern in Gebäudezustand
            building.SetStateVector(y_new);
        }

        
        
        // Hilfsmethoden zur Vektoraddition und Skalarmultiplikation
        private static double[] AddVectors(double[] a, double[] b)
        {
            double[] result = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
                result[i] = a[i] + b[i];
            return result;
        }

        private static double[] MultiplyVector(double[] a, double factor)
        {
            double[] result = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
                result[i] = a[i] * factor;
            return result;
        }
    }
}

