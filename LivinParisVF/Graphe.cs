namespace LivinParisVF;

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
        /// Ajout dans la liste d'adjacence
        if (!listeAdjacence.ContainsKey(a))
            listeAdjacence[a] = new Noeud(a);
        if (!listeAdjacence.ContainsKey(b))
            listeAdjacence[b] = new Noeud(b);
        
        listeAdjacence[a].Voisins.Add(b);
        listeAdjacence[b].Voisins.Add(a);
        
        /// Ajout dans la matrice d'adjacence
        matriceAdjacence[a, b] = 1;
        matriceAdjacence[b, a] = 1;
    }
    
    public void ParcoursLargeur(int depart)
    {
        List<int> visite = new List<int>();
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
        List<int> visite = new List<int>();
        Console.Write("Parcours en profondeur : ");
        Profondeur(depart, visite);
        Console.WriteLine();
    }
    
    private void Profondeur(int noeud, List<int> visite)
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
        if (listeAdjacence.Count == 0) return false; // Si le graphe est vide, il n'est pas connexe

        List<int> visite = new List<int>();
        int premierNoeud = listeAdjacence.Keys.First(); // Prendre un nœud de départ
        ProfondeurSansAffichage(premierNoeud, visite);

        return visite.Count == nbNoeuds; // Vérifie si tous les nœuds sont visités
    }


    private void ProfondeurSansAffichage(int noeud, List<int> visite)
    {
        visite.Add(noeud);
    
        foreach (var voisin in listeAdjacence[noeud].Voisins)
        {
            if (!visite.Contains(voisin))
            {
                ProfondeurSansAffichage(voisin, visite);
            }
        }
    }

    public void AnalyserGraphe()
    {
        int ordre = listeAdjacence.Count;
        int taille = 0;
        foreach (var noeud in listeAdjacence.Values)
        {
            taille += noeud.Voisins.Count;
        }
        taille /= 2; /// Car chaque lien est compté deux fois
        
        Console.WriteLine("Ordre du graphe (nombre de sommets) : " + ordre);
        Console.WriteLine("Taille du graphe (nombre d'arêtes) : " + taille);
        Console.WriteLine("Type du graphe : Non orienté, non pondéré");
    }

    public bool ContientCycle()
    {
        List<int> visite = new List<int>();
        Dictionary<int, int> parent = new Dictionary<int, int>(); // Stocke le parent de chaque nœud
        List<int> cycle = new List<int>(); // Stocke le cycle détecté

        foreach (var noeud in listeAdjacence.Keys)
        {
            if (!visite.Contains(noeud))
            {
                if (Profondeur_DetectionCycle(noeud, -1, visite, parent, cycle))
                {
                    Console.WriteLine("Le graphe contient un cycle.");
                    Console.WriteLine("Cycle détecté : " + string.Join(" -> ", cycle));
                    return true;
                }
            }
        }

        Console.WriteLine("Le graphe ne contient pas de cycle.");
        return false;
    }

    private bool Profondeur_DetectionCycle(int noeud, int parent, List<int> visite, Dictionary<int, int> parents, List<int> cycle)
    {
        visite.Add(noeud);
        parents[noeud] = parent; // Stocke le parent du nœud actuel

        foreach (var voisin in listeAdjacence[noeud].Voisins)
        {
            if (!visite.Contains(voisin))
            {
                if (Profondeur_DetectionCycle(voisin, noeud, visite, parents, cycle))
                    return true;
            }
            else if (voisin != parent) // Cycle détecté
            {
                // Reconstruire le cycle
                cycle.Clear();
                int current = noeud;
                while (current != -1 && current != voisin)
                {
                    cycle.Add(current);
                    current = parents[current];
                }
                cycle.Add(voisin);
                cycle.Reverse(); // Remet le cycle dans l'ordre

                return true;
            }
        }
        return false;
    }

    public Dictionary<int, Noeud> GetListeAdjacence()
    {
        return listeAdjacence;
    }
}
