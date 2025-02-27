namespace LivinParisVF;
//using SkiaSharp;
using System.Drawing;

public class Lien
{
    public int Noeud1 { get; set; }
    public int Noeud2 { get; set; }
    
    public Lien(int noeud1, int noeud2)
    {
        Noeud1 = noeud1;
        Noeud2 = noeud2;
    }
}