﻿namespace LivinParisVF;

public class Noeud
{
    public int Id { get; set; }
    public List<int> Voisins { get; set; }
    
    public Noeud(int id)
    {
        Id = id;
        Voisins = new List<int>();
    }
}