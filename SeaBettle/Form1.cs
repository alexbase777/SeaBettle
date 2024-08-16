namespace SeaBettle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.PlayerShips[0, 0] = CoordStatus.Ship;
            model.PlayerShips[5, 1] = CoordStatus.Ship;
            model.PlayerShips[5, 2] = CoordStatus.Ship;
            model.PlayerShips[5, 3] = CoordStatus.Ship;
            model.PlayerShips[5, 4] = CoordStatus.Ship;
            model.PlayerShips[1,6] = CoordStatus.Ship;
            model.PlayerShips[2,6] = CoordStatus.Ship;
            model.PlayerShips[3,6] = CoordStatus.Ship;
        }
        Model model;
        private void button1_Click(object sender, EventArgs e)
        {
            
            model.LastShot = model.Shot(textBox1.Text);
            int x = int.Parse(textBox1.Text.Substring(0,1));
            int y = int.Parse(textBox1.Text.Substring (1,1));
            switch (model.LastShot)
            {
                case ShotStatus.Miss:
                    model.EnemyShips[x, y] = CoordStatus.Shot;
                    break;
                case ShotStatus.Wounded:
                    model.EnemyShips[x, y] = CoordStatus.Got;
                    break;
                case ShotStatus.Kill:
                    model.EnemyShips[x, y] = CoordStatus.Got;
                    break;
            }
            //model.LastShotCoord = textBox1.Text;
            if (model.LastShot == ShotStatus.Wounded) // Перезаписываем координату последнего выстрела, если мы попали
            {
                model.LastShotCoord = textBox1.Text;
                model.WoundedStatus = true;
            }
            MessageBox.Show(model.Shot(textBox1.Text).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s;
            int x, y;
            do
            {
                s = model.ShotGen();
                x = int.Parse(s.Substring(0, 1));
                y = int.Parse(s.Substring(1, 1));
            }
            while (model.EnemyShips[x, y] != CoordStatus.None);            
            textBox1.Text = s;
        }
    }
}