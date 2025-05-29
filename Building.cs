using System;

namespace PP_Integrator_Test1
{
    // Repräsentiert ein Mehrstockwerk-Gebäude mit linearen Federn und Dämpfern.
    // Das Fundament kann sich mitbewegen.
    public class Building
    {
        public int NumberOfFloors { get; private set; }

        public double[] Masses;              // m_i
        public double[] SpringConstants;     // k_i (zwischen Etage i und i-1)
        public double[] DampingConstants;    // c_i (zwischen Etage i und i-1)

        public double[] Positions;           // u_i
        public double[] Velocities;          // u̇_i
        public double[] Accelerations;       // ü_i

        // Tilger-Eigenschaften       
        public double TilgerMasse { get; set; } = 1000.0;   // z. B. 1000 kg
        public double TilgerFeder { get; set; } = 50000.0; // z.B. 50 kN/m
        public double TilgerDaempfung { get; set; } = 800.0; // z. B. 800 Ns/m
        public double TilgerPosition { get; set; } = 0.0;
        public double TilgerVelocity { get; set; } = 0.0;
        public double TilgerAcceleration { get; set; } = 0.0;

        // Gibt eine Kopie der aktuellen Positionen zurück (zum Schutz vor direkter Manipulation)
        public double[] GetAktuellePositionen() 
        {
            return (double[])Positions.Clone();
        }

        // Konstruktor: Initialisiert Arrays je nach Anzahl der Stockwerke (+ Tilger falls gewünscht)
        public Building(int numberOfFloors)
        {
            NumberOfFloors = numberOfFloors;

            Masses = new double[numberOfFloors + 1];        // + 1 für Tilger 
            SpringConstants = new double[numberOfFloors + 1];
            DampingConstants = new double[numberOfFloors + 1];

            Positions = new double[numberOfFloors + 1];
            Velocities = new double[numberOfFloors + 1];
            Accelerations = new double[numberOfFloors + 1];
        }
        public Building(int numberOfFloors, bool includeTilger)

        {
            NumberOfFloors = numberOfFloors;

            int totalElements = includeTilger ? numberOfFloors + 1 : numberOfFloors;

            Masses = new double[totalElements];
            SpringConstants = new double[totalElements];
            DampingConstants = new double[totalElements];

            Positions = new double[totalElements];
            Velocities = new double[totalElements];
            Accelerations = new double[totalElements];
        }

        public void SetDefaultParameters(double mass, double spring, double damping)
        {
            for (int i = 0; i < NumberOfFloors; i++)
            {
                Masses[i] = mass;
                SpringConstants[i] = spring;
                DampingConstants[i] = damping;
            }
        }

        public void ResetState()
        {
            Array.Clear(Positions, 0, NumberOfFloors);
            Array.Clear(Velocities, 0, NumberOfFloors);
            Array.Clear(Accelerations, 0, NumberOfFloors);
        }

        
        // Gibt den aktuellen Zustandsvektor [Positionen; Geschwindigkeiten] zurück.
        public double[] GetStateVector()
        {
            double[] state = new double[2 * NumberOfFloors];
            for (int i = 0; i < NumberOfFloors; i++)
            {
                state[i] = Positions[i];
                state[NumberOfFloors + i] = Velocities[i];
            }
            return state;
        }

        // Setzt den Zustandsvektor [Positionen; Geschwindigkeiten].
        public void SetStateVector(double[] state)
        {
            for (int i = 0; i < NumberOfFloors; i++)
            {
                Positions[i] = state[i];
                Velocities[i] = state[NumberOfFloors + i];
            }
        }

        // Berechnet die rechte Seite der Bewegungsgleichung (Zustandsableitungen).
        public double[] ComputeDerivative(double t, double[] state, double groundPos, double groundVel)
        {
            int n = NumberOfFloors;
            double[] derivative = new double[2 * n]; // [v1, v2, ..., a1, a2, ...]

            for (int i = 0; i < n; i++)
            {
                // Position und Geschwindigkeit auslesen
                double u_i = state[i];
                double v_i = state[n + i];

                // Ableitung der Position ist die Geschwindigkeit
                derivative[i] = v_i;

                // Kräfte berechnen
                double force = 0.0;

                // Kopplung mit Etage darunter oder Boden
                double u_below = (i == 0) ? groundPos : state[i - 1];
                double v_below = (i == 0) ? groundVel : state[n + i - 1];

                force += -SpringConstants[i] * (u_i - u_below);
                force += -DampingConstants[i] * (v_i - v_below);

                // Kopplung mit Etage darüber (nur wenn vorhanden)
                if (i < n - 1)
                {
                    double u_above = state[i + 1];
                    double v_above = state[n + i + 1];

                    force += SpringConstants[i + 1] * (u_above - u_i);
                    force += DampingConstants[i + 1] * (v_above - v_i);
                }

                // a_i = F / m_i
                derivative[n + i] = force / Masses[i];
            }
            // --- Tilger-Erweiterung ---
            if (state.Length >= 2 * (NumberOfFloors + 1)) // nur wenn Tilger vorhanden ist
            {
                int iTop = NumberOfFloors - 1;

                // Indexe im Zustandsvektor
                int tilgerPosIndex = NumberOfFloors;               // Positionsteil
                int tilgerVelIndex = state.Length / 2 + iTop + 1;  // Geschwindigkeitsteil

                double u_top = state[iTop];                        // Position oberste Etage
                double v_top = state[state.Length / 2 + iTop];     // Geschwindigkeit oberste Etage

                double u_t = state[tilgerPosIndex];                // Tilgerposition
                double v_t = state[tilgerVelIndex];                // Tilgergeschwindigkeit

                double relativeDisplacement = u_t - u_top;
                double relativeVelocity = v_t - v_top;

                double fFeder = -TilgerFeder * relativeDisplacement;
                double fDaempfer = -TilgerDaempfung * relativeVelocity;
                double fGesamt = fFeder + fDaempfer;

                double a_tilger = fGesamt / TilgerMasse;

                // Tilger-Geschwindigkeit (Ableitung von Position)
                derivative[tilgerPosIndex] = v_t;

                // Tilger-Beschleunigung (Ableitung von Geschwindigkeit)
                derivative[tilgerVelIndex] = a_tilger;

                // Rückwirkung auf oberste Etage
                derivative[state.Length / 2 + iTop] -= fGesamt / Masses[iTop];
            }

            return derivative; 
        }
        //Öffe ntliche Properties für Zugriff aus Form1
        public int FloorCount => NumberOfFloors;
        public double MassPerFloor => Masses.Length > 0 ? Masses[0] : 0.0;
        public double SpringConstant => SpringConstants.Length > 0 ? SpringConstants[0] : 0.0;
        public double DampingCoefficient => DampingConstants.Length > 0 ? DampingConstants[0] : 0.0;
    }
}
