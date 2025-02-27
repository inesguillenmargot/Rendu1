namespace LivinParisVF;
using System;


class Program
{
    static void Main()
    {
        Graphe graphe = new Graphe(34); // Nombre de membres (34)
        
        int[][] liens = {
            new int[] {2,1}, new int[] {3,1}, new int[] {4,1}, new int[] {5,1}, new int[] {6,1},
            new int[] {7,1}, new int[] {8,1}, new int[] {9,1}, new int[] {11,1}, new int[] {12,1},
            new int[] {13,1}, new int[] {14,1}, new int[] {18,1}, new int[] {20,1}, new int[] {22,1},
            new int[] {32,1}, new int[] {3,2}, new int[] {4,2}, new int[] {8,2}, new int[] {14,2},
            new int[] {18,2}, new int[] {20,2}, new int[] {22,2}, new int[] {31,2}, new int[] {4,3},
            new int[] {8,3}, new int[] {9,3}, new int[] {10,3}, new int[] {14,3}, new int[] {28,3},
            new int[] {29,3}, new int[] {33,3}, new int[] {8,4}, new int[] {13,4}, new int[] {14,4},
            new int[] {7,5}, new int[] {11,5}, new int[] {7,6}, new int[] {11,6}, new int[] {17,6},
            new int[] {17,7}, new int[] {31,9}, new int[] {33,9}, new int[] {34,9}, new int[] {34,10},
            new int[] {34,14}, new int[] {33,15}, new int[] {34,15}, new int[] {33,16}, new int[] {34,16},
            new int[] {33,19}, new int[] {34,19}, new int[] {34,20}, new int[] {33,21}, new int[] {34,21},
            new int[] {33,23}, new int[] {34,23}, new int[] {26,24}, new int[] {28,24}, new int[] {30,24},
            new int[] {33,24}, new int[] {34,24}, new int[] {26,25}, new int[] {28,25}, new int[] {32,25},
            new int[] {32,26}, new int[] {30,27}, new int[] {34,27}, new int[] {34,28}, new int[] {32,29},
            new int[] {34,29}, new int[] {33,30}, new int[] {34,30}, new int[] {33,31}, new int[] {34,31},
            new int[] {33,32}, new int[] {34,32}, new int[] {34,33}
        };


        foreach (var lien in liens)
        {
            graphe.AjouterLien(lien[0], lien[1]);
        }

        // Affichage des 2 parcours (profondeur et largeur)
        graphe.ParcoursLargeur(1);
        graphe.ParcoursProfondeur(1);
        
        // Vérification si connexe ou non
        Console.WriteLine("Le graphe est connexe : " + (graphe.EstConnexe() ? "Oui" : "Non"));
        
        // Vérification si cycle ou non
        Console.WriteLine("Le graphe contient un cycle : " + (graphe.ContientCycle() ? "Oui" : "Non"));
        
        // Analyse des propriétés du graphe
        graphe.AnalyserGraphe();
        
        // Lance la fenêtre Windows Forms
        //graphe.AfficherGraphe(); 
    }
}
