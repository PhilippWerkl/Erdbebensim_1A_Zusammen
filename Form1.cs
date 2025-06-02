using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using PP_Integrator_Test1;
// Test 
namespace Erdbebensim.Zusaammen_GUI___Vis_
{
    public partial class Form1 : Form
    {
        private RK4Integrator integrator;
        private Building building;
        private double t = 0.0;
        private double dt = 0.01;
        private ErregerFunktion erreger;
        private Visualisierung visualisierung = new Visualisierung();
        private MouseTweaks mouseTweaks = new MouseTweaks();
        private int n;
        private const int MaxFloors = 10000;      
        private const double MaxMass = 1e6;      // max. 1 000 000 kg
        private const double MaxSpring = 1e7;      // max. 10 000 000 N/m
        private const double MaxDamping = 1e5;      // max. 100 000 Ns/m
        private const double StabilityLimitZ0 = 2.83;   //Stabilitätsgrenze für RK4
        private int currentScrollY = 0;

        public Form1()
        {
            InitializeComponent();

            // Mausevents für Drag & Zoom
            mouseTweaks.Attach(pictureBoxSimulation);
            pictureBoxSimulation.MouseEnter += (s, e) => pictureBoxSimulation.Focus();
            mouseTweaks.Attach(pictureBoxSimulation);

            // Timer initialisieren
            timer1.Interval = 25;
            timer1.Tick += timer1_Tick;

            // Button-Events
            btnStart.Click += btnStart_Click;
            btnStop.Click += btnStop_Click;
            btnClose.Click += btnClose_Click;

            // Tooltips
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 200;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(txtFloors, "Anzahl der Stockwerke (ganzzahlig)");
            toolTip1.SetToolTip(txtMass, "Masse pro Stockwerk in Kilogramm");
            toolTip1.SetToolTip(txtSpring, "Federkonstante (Steifigkeit) in N/m");
            toolTip1.SetToolTip(txtDamping, "Dämpfung in Ns/m");
            toolTip1.SetToolTip(statusLamp, "Simulation gestoppt");

            statusLamp.BackColor = Color.Red;

            // Standardwerte festlegen
            n = 15;
            txtFloors.Text = n.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Zeichen-Events
            pictureBoxSimulation.Resize += pictureBoxSimulation_Resize;

            // Bodenanregung definieren
            erreger = ErregerFunktion.Sinus(0.1, 1.0);

            // Gebäude und Integrator initialisieren
            building = new Building(n);
            building.SetDefaultParameters(1400, 10000, 10);
            building.ResetState();

            visualisierung.Stockwerke = n;
            visualisierung.Positionen = building.Positions;

            // Schritt 2: Scroll-Bereich an die Etagenzahl anpassen
            int stockwerkHöhe = 60;                                   // wie in Visualisierung.cs
            int gesamtHöhe = n * stockwerkHöhe;                   // oder "floors * stockwerkHöhe"
            int viewPortHöhe = pictureBoxSimulation.Height;          // sichtbarer Bereich

            vScrollBar1.Minimum = 0;
            vScrollBar1.Maximum = Math.Max(0, gesamtHöhe - viewPortHöhe);
            vScrollBar1.LargeChange = viewPortHöhe;
            vScrollBar1.SmallChange = stockwerkHöhe;
            vScrollBar1.Value = 0;

            integrator = new RK4Integrator(building);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            statusLamp.BackColor = Color.Green;
            toolTip1.SetToolTip(statusLamp, "Simulation läuft");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            statusLamp.BackColor = Color.Red;
            toolTip1.SetToolTip(statusLamp, "Simulation gestoppt");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnResetDefaults_Click(object sender, EventArgs e)
        {
            int defaultFloors = 15;
            double defaultMass = 1400;
            double defaultSpring = 10000;
            double defaultDamping = 10;

            building = new Building(defaultFloors);
            building.SetDefaultParameters(defaultMass, defaultSpring, defaultDamping);
            building.ResetState();
            integrator = new RK4Integrator(building);

            visualisierung.Stockwerke = defaultFloors;
            visualisierung.Positionen = building.Positions;

            // Schritt 2: Scroll-Bereich an die Etagenzahl anpassen
            int stockwerkHöhe = 60;                                   // wie in Visualisierung.cs
            int gesamtHöhe = n * stockwerkHöhe;                   // oder "floors * stockwerkHöhe"
            int viewPortHöhe = pictureBoxSimulation.Height;          // sichtbarer Bereich

            vScrollBar1.Minimum = 0;
            vScrollBar1.Maximum = Math.Max(0, gesamtHöhe - viewPortHöhe);
            vScrollBar1.LargeChange = viewPortHöhe;
            vScrollBar1.SmallChange = stockwerkHöhe;
            vScrollBar1.Value = 0;
            currentScrollY = 0;


            txtFloors.Text = defaultFloors.ToString();
            txtMass.Text = defaultMass.ToString();
            txtSpring.Text = defaultSpring.ToString();
            txtDamping.Text = defaultDamping.ToString();

            UpdateParameterLabels(defaultFloors, defaultMass, defaultSpring, defaultDamping);

            // Simulation sofort starten
            timer1.Start();
            statusLamp.BackColor = Color.Green;
            toolTip1.SetToolTip(statusLamp, "Simulation läuft");

            MessageBox.Show("Standardwerte wurden wiederhergestellt.", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int floors = rnd.Next(1, 101);
            double mass = rnd.Next(500, 5001);
            double spring = rnd.Next(1000, 100001);
            double damping = rnd.Next(1, 501);

            building = new Building(floors);
            building.SetDefaultParameters(mass, spring, damping);
            building.ResetState();
            integrator = new RK4Integrator(building);

            visualisierung.Stockwerke = floors;
            visualisierung.Positionen = building.Positions;

            // Schritt 2: Scroll-Bereich an die Etagenzahl anpassen
            int stockwerkHöhe = 60;                                   // wie in Visualisierung.cs
            int gesamtHöhe = n * stockwerkHöhe;                   // oder "floors * stockwerkHöhe"
            int viewPortHöhe = pictureBoxSimulation.Height;          // sichtbarer Bereich

            vScrollBar1.Minimum = 0;
            vScrollBar1.Maximum = Math.Max(0, gesamtHöhe - viewPortHöhe);
            vScrollBar1.LargeChange = viewPortHöhe;
            vScrollBar1.SmallChange = stockwerkHöhe;
            vScrollBar1.Value = 0;
            currentScrollY = 0;

            txtFloors.Text = floors.ToString();
            txtMass.Text = mass.ToString();
            txtSpring.Text = spring.ToString();
            txtDamping.Text = damping.ToString();

            UpdateParameterLabels(floors, mass, spring, damping);

            // Simulation sofort starten
            timer1.Start();
            statusLamp.BackColor = Color.Green;
            toolTip1.SetToolTip(statusLamp, "Simulation läuft");

            MessageBox.Show("Zufällige Parameter gesetzt!", "Randomizer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnApplyParameters_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Parsen (kann FormatException oder OverflowException werfen)
                int floors = int.Parse(txtFloors.Text);
                double mass = double.Parse(txtMass.Text);
                double spring = double.Parse(txtSpring.Text);
                double damping = double.Parse(txtDamping.Text);

                // 2) Bereichsprüfung
                if (floors <= 0 || floors > MaxFloors)
                    throw new ArgumentOutOfRangeException(
                        nameof(floors),
                        $"Stockwerke muss zwischen 1 und {MaxFloors} liegen.");
                if (mass <= 0 || mass > MaxMass)
                    throw new ArgumentOutOfRangeException(
                        nameof(mass),
                        $"Masse muss > 0 kg und ≤ {MaxMass} kg sein.");
                if (spring <= 0 || spring > MaxSpring)
                    throw new ArgumentOutOfRangeException(
                        nameof(spring),
                        $"Federkonstante muss > 0 N/m und ≤ {MaxSpring} N/m sein.");
                if (damping < 0 || damping > MaxDamping)
                    throw new ArgumentOutOfRangeException(
                        nameof(damping),
                        $"Dämpfung muss ≥ 0 Ns/m und ≤ {MaxDamping} Ns/m sein.");

                // 3) Zusätzliche Stabilitätsprüfung für RK4:
                //    ω = sqrt(k/m), wir verlangen: ω·dt ≤ StabilityLimitZ0
                double maxRatio = Math.Pow(StabilityLimitZ0 / dt, 2);
                if (spring / mass > maxRatio)
                    throw new ArgumentOutOfRangeException(
                        nameof(spring),
                        $"Das Verhältnis k/m ist zu hoch für eine stabile Simulation mit dt={dt}s. " +
                        $"Erlaubt: k/m ≤ {maxRatio:F0}.");

                // 4) Werte übernehmen
                building = new Building(floors);
                building.SetDefaultParameters(mass, spring, damping);
                building.ResetState();
                integrator = new RK4Integrator(building);

                // Stabilitäts-Check
                double omegaMax2 = Math.Pow(StabilityLimitZ0 / dt, 2);
                if (spring / mass > omegaMax2)
                    throw new ArgumentOutOfRangeException(
                        nameof(spring),
                        $"k/m ist zu groß für stabile Integration (k/m ≤ {omegaMax2:F0}).");

                // GUI updaten
                visualisierung.Stockwerke = floors;
                visualisierung.Positionen = building.Positions;
                UpdateParameterLabels(floors, mass, spring, damping);

                statusLamp.BackColor = Color.Green;
                toolTip1.SetToolTip(statusLamp, "Simulation läuft");
                MessageBox.Show(
                    "Parameter wurden erfolgreich angepasst.",
                    "OK",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Bitte nur Ziffern eingeben (keine Buchstaben oder Sonderzeichen).",
                    "Ungültige Eingabe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "Die Zahl ist zu groß für den zulässigen Bereich.",
                    "Ungültige Eingabe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Wert außerhalb des erlaubten Bereichs",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Bodenbewegung berechnen...
            double amplitude = 0.1;
            double frequency = 1.0;
            double omega = 2 * Math.PI * frequency;
            double groundPos = amplitude * Math.Sin(omega * t);
            double groundVel = amplitude * omega * Math.Cos(omega * t);

            try
            {
                integrator.SetGroundMotion(groundPos, groundVel);
                integrator.Step(dt, t);      // Problemstelle
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show(
                    "Simulation abgebrochen:\n" + ex.Message,
                    "Simulationsfehler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            t += dt;

            // weiter zeichnen
            visualisierung.Positionen = building.Positions;
            pictureBoxSimulation.Invalidate();
        }

        private void pictureBoxSimulation_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.ScaleTransform(mouseTweaks.Zoom, mouseTweaks.Zoom);
            g.TranslateTransform(mouseTweaks.Offset.X, mouseTweaks.Offset.Y);
            g.TranslateTransform(0, -currentScrollY);
            visualisierung.ZeichneHochhaus(g, pictureBoxSimulation.Size);
        }

        private void pictureBoxSimulation_Resize(object sender, EventArgs e)
        {
            pictureBoxSimulation.Invalidate();
        }

        private void UpdateParameterLabels(int floors, double mass, double spring, double damping)
        {
            lblFloors.Text = $"Stockwerke: {floors}";
            lblMass.Text = $"Masse: {mass} kg";
            lblSpring.Text = $"Federkonstante: {spring} N/m";
            lblDamping.Text = $"Dämpfung: {damping} Ns/m";
        }

        private void txtFloors_TextChanged(object sender, EventArgs e)
        {
            // Leer
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            currentScrollY = vScrollBar1.Value;
            pictureBoxSimulation.Invalidate();
        }
    }
}

