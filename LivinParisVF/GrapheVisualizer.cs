namespace LivinParisVF;
using SkiaSharp;
using System.Drawing;
/*
public class GraphVisualizer : Form
{
    private Graphe graphe;
    private Dictionary<int, Point> positions;
    private Random random = new Random();

    public GraphVisualizer(Graphe graphe)
    {
        this.graphe = graphe;
        this.Text = "Visualisation du Graphe";
        this.Size = new Size(800, 600);
        this.DoubleBuffered = true;
        positions = new Dictionary<int, Point>();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.Clear(Color.White);
        
        foreach (var noeud in graphe.GetListeAdjacence())
        {
            if (!positions.ContainsKey(noeud.Key))
                positions[noeud.Key] = new Point(random.Next(100, 700), random.Next(100, 500));
        }
        
        foreach (var noeud in graphe.GetListeAdjacence())
        {
            Point p1 = positions[noeud.Key];
            foreach (var voisin in noeud.Value.Voisins)
            {
                Point p2 = positions[voisin];
                g.DrawLine(Pens.Black, p1, p2);
            }
        }
        
        foreach (var noeud in graphe.GetListeAdjacence())
        {
            Point p = positions[noeud.Key];
            g.FillEllipse(Brushes.Blue, p.X - 10, p.Y - 10, 20, 20);
            g.DrawString(noeud.Key.ToString(), SystemFonts.DefaultFont, Brushes.White, p.X - 5, p.Y - 5);
        }
    }
}*/