using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PP_Integrator_Test1
{
    public class Visualisierung
    {
        public int Stockwerke { get; set; } = 1;                // Standardwert :contentReference[oaicite:0]{index=0}:contentReference[oaicite:1]{index=1}
        public double[] Positionen { get; set; } = Array.Empty<double>();

        private const double ScaleFactor = 100.0;               // Maßstab Auslenkung → Pixel :contentReference[oaicite:2]{index=2}:contentReference[oaicite:3]{index=3}

        public void ZeichneHochhaus(Graphics z, Size controlSize)
        {
            // Glatte Linien
            z.SmoothingMode = SmoothingMode.AntiAlias;

            // Pinsel und Stifte
            var brushStuetze = new SolidBrush(Color.Gray);
            var brushBoden = new SolidBrush(Color.Black);
            var penStuetze = new Pen(Color.Gray, 6);
            var penBoden = new Pen(Color.Black, 2);

            // --- Zentrierung & dynamischer maxShift ---
            // Halbe Breite minus halbe Hausbreite (200/2)
            int halfW = controlSize.Width / 2;
            int houseHalfW2 = 100;
            int xBase = halfW - houseHalfW2;
            int maxShift = halfW - houseHalfW2;

            // Vertikale Basis und Etagenhöhe
            int yTotal = controlSize.Height;
            int stockwerkHoehe = 60;
            int bodenY = yTotal - 100;

            // 1) Stockwerk-Böden & schräge Stützen
            for (int i = 0; i < Stockwerke; i++)
            {
                // Boden-Position
                int offsetY = bodenY - (i * stockwerkHoehe);
                int offsetX = xBase;

                // Auslenkung clampen
                if (Positionen.Length > i)
                {
                    double raw = Positionen[i] * ScaleFactor;
                    if (double.IsNaN(raw) || double.IsInfinity(raw)) raw = 0;
                    raw = Math.Max(Math.Min(raw, maxShift), -maxShift);
                    offsetX += (int)Math.Round(raw);
                }

                // Boden zeichnen
                try
                {
                    var rect = new Rectangle(new Point(offsetX, offsetY), new Size(200, 10));
                    z.DrawRectangle(penBoden, rect);
                    z.FillRectangle(brushBoden, rect);
                }
                catch (OverflowException)
                {
                    // Überspringen bei ungültigen Koordinaten
                }

                // Schräge Stützen zur nächsten Etage
                if (i < Stockwerke - 1 && Positionen.Length > i + 1)
                {
                    double rawU = Positionen[i] * ScaleFactor;
                    double rawO = Positionen[i + 1] * ScaleFactor;
                    if (double.IsNaN(rawU) || double.IsInfinity(rawU)) rawU = 0;
                    if (double.IsNaN(rawO) || double.IsInfinity(rawO)) rawO = 0;
                    rawU = Math.Max(Math.Min(rawU, maxShift), -maxShift);
                    rawO = Math.Max(Math.Min(rawO, maxShift), -maxShift);

                    int xU = xBase + (int)Math.Round(rawU);
                    int xO = xBase + (int)Math.Round(rawO);
                    int yU = offsetY;
                    int yO = offsetY - stockwerkHoehe;

                    try
                    {
                        // links
                        z.DrawLine(penStuetze, new Point(xU, yU), new Point(xO, yO));
                        // rechts
                        z.DrawLine(penStuetze, new Point(xU + 200, yU), new Point(xO + 200, yO));
                    }
                    catch (OverflowException)
                    {
                        // Linie überspringen
                    }
                }
            }

            // 2) Dach mit Stützen
            if (Positionen.Length > Stockwerke)
            {
                // Dach-Auslenkung clampen
                double rawRoof = Positionen[Stockwerke] * ScaleFactor;
                if (double.IsNaN(rawRoof) || double.IsInfinity(rawRoof)) rawRoof = 0;
                rawRoof = Math.Max(Math.Min(rawRoof, maxShift), -maxShift);

                int roofX = xBase + (int)Math.Round(rawRoof);
                int roofY = bodenY - Stockwerke * stockwerkHoehe;

                // Stützbasis eine Etage unterhalb des Dachs
                int supportY = bodenY - (Stockwerke - 1) * stockwerkHoehe;
                double rawPrev = Positionen[Stockwerke - 1] * ScaleFactor;
                if (double.IsNaN(rawPrev) || double.IsInfinity(rawPrev)) rawPrev = 0;
                rawPrev = Math.Max(Math.Min(rawPrev, maxShift), -maxShift);
                int baseX = xBase + (int)Math.Round(rawPrev);

                // Stützen zum Dach
                try
                {
                    z.DrawLine(penStuetze, new Point(baseX, supportY), new Point(roofX, roofY));
                    z.DrawLine(penStuetze, new Point(baseX + 200, supportY), new Point(roofX + 200, roofY));
                }
                catch (OverflowException)
                {
                    // überspringen
                }

                // Dach-Dreieck
                try
                {
                    Point p1 = new Point(roofX, roofY);
                    Point p2 = new Point(roofX + 100, roofY - 40);
                    Point p3 = new Point(roofX + 200, roofY);
                    z.FillPolygon(brushBoden, new[] { p1, p2, p3 });
                    z.DrawPolygon(penBoden, new[] { p1, p2, p3 });
                }
                catch (OverflowException)
                {
                    // überspringen
                }
            }
        }
    }
}


