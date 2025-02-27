namespace LivinParisVF;
using SkiaSharp;
using System.Drawing;

public class Graphe
{
    private Dictionary<int, Noeud> listeAdjacence;
    private int[,] matriceAdjacence;
    private int nbNoeuds;
    
    public Graphe(int nbNoeuds)
    {
        this.nbNoeuds = nbNoeuds;
        listeAdjacence = new Dictionary<int, Noeud>();
        matriceAdjacence = new int[nbNoeuds + 1, nbNoeuds + 1];
    }
    
    public void AjouterLien(int a, int b)
    {
        // Ajout dans la liste d'adjacence
        if (!listeAdjacence.ContainsKey(a))
            listeAdjacence[a] = new Noeud(a);
        if (!listeAdjacence.ContainsKey(b))
            listeAdjacence[b] = new Noeud(b);
        
        listeAdjacence[a].Voisins.Add(b);
        listeAdjacence[b].Voisins.Add(a);
        
        // Ajout dans la matrice d'adjacence
        matriceAdjacence[a, b] = 1;
        matriceAdjacence[b, a] = 1;
    }
    
    public void ParcoursLargeur(int depart)
    {
        HashSet<int> visite = new HashSet<int>();
        Queue<int> file = new Queue<int>();
        
        file.Enqueue(depart);
        visite.Add(depart);
        
        Console.Write("Parcours en largeur : ");
        
        while (file.Count > 0)
        {
            int noeud = file.Dequeue();
            Console.Write(noeud + " ");
            
            foreach (int voisin in listeAdjacence[noeud].Voisins)
            {
                if (!visite.Contains(voisin))
                {
                    file.Enqueue(voisin);
                    visite.Add(voisin);
                }
            }
        }
        Console.WriteLine();
    }
    
    public void ParcoursProfondeur(int depart)
    {
        HashSet<int> visite = new HashSet<int>();
        Console.Write("Parcours en profondeur : ");
        Profondeur(depart, visite);
        Console.WriteLine();
    }
    
    private void Profondeur(int noeud, HashSet<int> visite)
    {
        visite.Add(noeud);
        Console.Write(noeud + " ");
        
        foreach (int voisin in listeAdjacence[noeud].Voisins)
        {
            if (!visite.Contains(voisin))
            {
                Profondeur(voisin, visite);
            }
        }
    }
    
    public bool EstConnexe()
    {
        HashSet<int> visite = new HashSet<int>();
        Profondeur(1, visite);
        return visite.Count == listeAdjacence.Count;
    }

    public void AnalyserGraphe()
    {
        int ordre = listeAdjacence.Count;
        int taille = 0;
        foreach (var noeud in listeAdjacence.Values)
        {
            taille += noeud.Voisins.Count;
        }
        taille /= 2; // Car chaque lien est compté deux fois
        
        Console.WriteLine("Ordre du graphe (nombre de sommets) : " + ordre);
        Console.WriteLine("Taille du graphe (nombre d'aretes) : " + taille);
        Console.WriteLine("Type du graphe : Non oriente, non pondere");
    }
    public bool ContientCycle()
    {
        HashSet<int> visite = new HashSet<int>();
        foreach (var noeud in listeAdjacence.Keys)
        {
            if (!visite.Contains(noeud))
            {
                if (Profondeur_DetectionCycle(noeud, -1, visite))
                    return true;
            }
        }
        return false;
    }
    
    private bool Profondeur_DetectionCycle(int noeud, int parent, HashSet<int> visite)
    {
        visite.Add(noeud);
        foreach (var voisin in listeAdjacence[noeud].Voisins)
        {
            if (!visite.Contains(voisin))
            {
                if (Profondeur_DetectionCycle(voisin, noeud, visite))
                    return true;
            }
            else if (voisin != parent) // Il y a un cycle si un voisin est visité et que ce n'est pas le parent, 
            {
                return true;
            }
        }
        return false;
    }
    /*public void AfficherGraphe()
    {
        Application.Run(new GraphVisualizer(this));
    }*///https://github.com/inesguillenmargot/LivinParisVF.git
    public Dictionary<int, Noeud> GetListeAdjacence()
    {
        return listeAdjacence;
    }
}