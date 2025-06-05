using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using PP_Integrator_Test1;
// Test 456
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
        private double excitationAmplitude = 2.0;
        private double excitationFrequency = 1.0;
        private const int DefaultFloors = 15;
        private const double DefaultMass = 1400;
        private const double DefaultSpring = 10000;
        private const double DefaultDamping = 10;
        private const double DefaultAmplitude = 0.15;
        private const double DefaultFrequency = 1;


        public Form1()
        {
            InitializeComponent();

            //Events für RadioButtons
            rbSinus.CheckedChanged += RadioButton_CheckedChanged;
            rbDoubleSinus.CheckedChanged += RadioButton_CheckedChanged;
            rbSquare.CheckedChanged += RadioButton_CheckedChanged;

            // Eine Funktion aktivieren, damit direkt was passiert
            rbSinus.Checked = true;

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

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Zeichen-Events
            pictureBoxSimulation.Resize += pictureBoxSimulation_Resize;

            // Bodenanregung definieren
            erreger = ErregerFunktion.Sinus(DefaultAmplitude, DefaultFrequency);


            // Gebäude und Integrator initialisieren
            n = DefaultFloors;
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

            txtFloors.Text = "";
            txtMass.Text = "";
            txtSpring.Text = "";
            txtDamping.Text = "";
            txtAmp.Text = "";
            txtFreq.Text = "";

        }

        private void btnApplyParameters_Click(object sender, EventArgs e)
        {
            // 1. Mit Defaultwerten starten
            int floors = DefaultFloors;
            double mass = DefaultMass;
            double spring = DefaultSpring;
            double damping = DefaultDamping;
            double amp = DefaultAmplitude;
            double freq = DefaultFrequency;

            // 2. Nur überschreiben, wenn gültig geparst
            if (int.TryParse(txtFloors.Text, out int parsedFloors) && parsedFloors > 0 && parsedFloors <= MaxFloors)
                floors = parsedFloors;

            if (double.TryParse(txtMass.Text, out double parsedMass) && parsedMass > 0 && parsedMass <= MaxMass)
                mass = parsedMass;

            if (double.TryParse(txtSpring.Text, out double parsedSpring) && parsedSpring > 0 && parsedSpring <= MaxSpring)
                spring = parsedSpring;

            if (double.TryParse(txtDamping.Text, out double parsedDamping) && parsedDamping >= 0 && parsedDamping <= MaxDamping)
                damping = parsedDamping;

            if (double.TryParse(txtAmp.Text, out double parsedAmp) && parsedAmp > 0)
                amp = parsedAmp;

            if (double.TryParse(txtFreq.Text, out double parsedFreq) && parsedFreq > 0)
                freq = parsedFreq;

            // 3. RK4-Stabilitätsprüfung
            double maxRatio = Math.Pow(StabilityLimitZ0 / dt, 2);
            if (spring / mass > maxRatio)
            {
                MessageBox.Show(
                    $"Das Verhältnis k/m ist zu hoch für eine stabile Simulation mit dt={dt}s.\nErlaubt: k/m ≤ {maxRatio:F0}.",
                    "Stabilitätsfehler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // 4. Werte übernehmen
            building = new Building(floors);
            building.SetDefaultParameters(mass, spring, damping);
            building.ResetState();
            integrator = new RK4Integrator(building);

            visualisierung.Stockwerke = floors;
            visualisierung.Positionen = building.Positions;
            UpdateParameterLabels(floors, mass, spring, damping);

            // 5. Erregerfunktion setzen
            excitationAmplitude = amp;
            excitationFrequency = freq;

            if (rbSinus.Checked)
            {
                erreger = ErregerFunktion.Sinus(amp, freq);
                lblAktuell.Text = $"Aktuell: Sinus ({amp} / {freq} Hz)";
            }
            else if (rbDoubleSinus.Checked)
            {
                erreger = ErregerFunktion.DoubleSinus(amp, freq, 0.5 * amp, 2.0 * freq);
                lblAktuell.Text = $"Aktuell: Double-Sinus";
            }
            else if (rbSquare.Checked)
            {
                erreger = ErregerFunktion.Rechteckimpuls(amp, 1.0 / freq);
                lblAktuell.Text = $"Aktuell: Rechteck (Amp: {amp}, Dauer: {1.0 / freq:F2} s)";
            }

            // 6. Feedback an Nutzer
            statusLamp.BackColor = Color.Green;
            toolTip1.SetToolTip(statusLamp, "Simulation läuft");
            MessageBox.Show(
                "Parameter wurden erfolgreich angepasst.",
                "OK",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            txtFloors.Text = "";
            txtMass.Text = "";
            txtSpring.Text = "";
            txtDamping.Text = "";
            txtAmp.Text = "";
            txtFreq.Text = "";

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            // Bodenbewegung berechnen
            double groundPos = erreger?.Position(t) ?? 0.0;
            double groundVel = erreger?.Velocity(t) ?? 0.0;

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

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is RadioButton rb) || !rb.Checked) return;

            // Alte Logik: Zugriff auf txtAmp & txtFreq => WEG DAMIT!
            // Wir tun hier erstmal nichts – die eigentliche Erregerfunktion wird erst bei "Apply" neu gesetzt.

            if (rb == rbSinus)
            {
                lblAktuell.Text = "Ausgewählt: Sinus";
            }
            else if (rb == rbDoubleSinus)
            {
                lblAktuell.Text = "Ausgewählt: Double-Sinus";
            }
            else if (rb == rbSquare)
            {
                lblAktuell.Text = "Ausgewählt: Rechteckimpuls";
            }
        }



        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            currentScrollY = vScrollBar1.Value;
            pictureBoxSimulation.Invalidate();
        }
    }
}

