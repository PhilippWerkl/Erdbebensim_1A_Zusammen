namespace PP_Integrator_Test1
{
    public class MouseTweaks
    {
        public float Zoom { get; private set; } = 1.0f;
        public PointF Offset { get; private set; } = new PointF(0, 0);

        private bool isDragging = false;
        private Point lastMousePos;

        public void Attach(PictureBox pictureBox)
        {
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.MouseUp += PictureBox_MouseUp;
            pictureBox.MouseWheel += PictureBox_MouseWheel;
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMousePos = e.Location;
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                float dx = (e.X - lastMousePos.X) / Zoom;
                float dy = (e.Y - lastMousePos.Y) / Zoom;
                Offset = new PointF(
                    Offset.X + dx,
                    Offset.Y + dy
                );
                lastMousePos = e.Location;
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isDragging = false;
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            float oldZoom = Zoom;
            float zoomFactor = (e.Delta > 0) ? 1.05f : 0.95f;
            Zoom *= zoomFactor;
            Zoom = Math.Clamp(Zoom, 0.05f, 5.0f);

            PointF focus = e.Location;
            Offset = new PointF(
                (Offset.X - focus.X) * (Zoom / oldZoom) + focus.X,
                (Offset.Y - focus.Y) * (Zoom / oldZoom) + focus.Y
            );
        }

        public void Reset()
        {
            Zoom = 1.0f;
            Offset = new PointF(0, 0);
        }
    }
}