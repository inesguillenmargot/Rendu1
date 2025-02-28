using System;
using SkiaSharp;

namespace LivinParisVF
{
    public class GrapheVisualizer
    {
        private Graphe _graphe;
        private int _width = 800;
        private int _height = 800;
        private int _radius = 300;  /// Rayon du cercle où placer les nœuds
        private Dictionary<int, SKPoint> _positions;

        public GrapheVisualizer(Graphe graphe)
        {
            _graphe = graphe;
            _positions = new Dictionary<int, SKPoint>();
            _radius = (int)(Math.Min(_width, _height) / 2.5f);
            CalculerPositions();
        }

        /// <summary>
        /// Calculer les positions des nœuds en cercle
        /// </summary>
        private void CalculerPositions()
        {
            int n = _graphe.GetListeAdjacence().Count;
            if (n == 0) return;

            double angleStep = 2 * Math.PI / n;
            int centerX = _width / 2;
            int centerY = _height / 2;
            int i = 0;

            foreach (var noeud in _graphe.GetListeAdjacence().Keys)
            {
                double angle = i * angleStep;
                float x = centerX + (float)(_radius * Math.Cos(angle));
                float y = centerY + (float)(_radius * Math.Sin(angle));
                _positions[noeud] = new SKPoint(x, y);
                i++;
            }
        }

        /// <summary>
        /// Dessiner le graphe et l'enregistrer en tant qu'image PNG
        /// </summary>
        public void DessinerGraphe(string filePath)
        {
            using var bitmap = new SKBitmap(_width, _height);
            using var canvas = new SKCanvas(bitmap);
            canvas.Clear(SKColors.White);

            var paintArrete = new SKPaint { Color = SKColors.Black, StrokeWidth = 2, IsAntialias = true };
            var paintNoeud = new SKPaint { Color = SKColors.Blue, IsAntialias = true };
            var paintTexte = new SKPaint { Color = SKColors.White, TextSize = 20, TextAlign = SKTextAlign.Center };

            /// Dessiner les arêtes
            foreach (var noeud in _graphe.GetListeAdjacence())
            {
                SKPoint p1 = _positions[noeud.Key];

                foreach (var voisin in noeud.Value.Voisins)
                {
                    if (_positions.ContainsKey(voisin))
                    {
                        SKPoint p2 = _positions[voisin];
                        canvas.DrawLine(p1, p2, paintArrete);
                    }
                }
            }

            /// Dessiner les nœuds
            foreach (var (id, pos) in _positions)
            {
                canvas.DrawCircle(pos, 20, paintNoeud); /// Cercle du nœud
                canvas.DrawText(id.ToString(), pos.X, pos.Y + 7, paintTexte); /// Texte (numéro du nœud)
            }

            /// Enregistrer l'image
            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            File.WriteAllBytes(filePath, data.ToArray());

            string cheminComplet = Path.GetFullPath(filePath);
            Console.WriteLine($"Le dessin du graphe a été enregistré avec succès !");
            Console.WriteLine($"Emplacement du fichier : {cheminComplet}");

        }
    }
}
