using Xunit;
using LivinParisVF;
using System.Collections.Generic;

namespace TestProject1
{
    public class GrapheTests
    {
        [Fact]
        public void AjouterLien_AjouteCorrectementUnLien()
        {
            // Arrange
            var graphe = new Graphe(5);
            
            // Act
            graphe.AjouterLien(1, 2);
            
            // Assert
            Assert.Contains(2, graphe.GetListeAdjacence()[1].Voisins);
            Assert.Contains(1, graphe.GetListeAdjacence()[2].Voisins);
        }

        [Fact]
        public void ParcoursLargeur_ExploreTousLesNoeuds()
        {
            // Arrange
            var graphe = new Graphe(4);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3);
            graphe.AjouterLien(3, 4);
            
            // Act
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);
            graphe.ParcoursLargeur(1);
            var output = consoleOutput.ToString();

            // Assert
            Assert.Contains("1", output);
            Assert.Contains("2", output);
            Assert.Contains("3", output);
            Assert.Contains("4", output);
        }

        [Fact]
        public void EstConnexe_RetourneTrueSiToutEstConnecte()
        {
            // Arrange
            var graphe = new Graphe(3);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3);
            
            // Act & Assert
            Assert.True(graphe.EstConnexe());
        }

        [Fact]
        public void EstConnexe_RetourneFalseSiGrapheEstDeconnecte()
        {
            // Arrange
            var graphe = new Graphe(3);
            graphe.AjouterLien(1, 2);
            
            // Act & Assert
            Assert.False(graphe.EstConnexe());
        }

        [Fact]
        public void ContientCycle_RetourneTrueSiCycleDetecte()
        {
            // Arrange
            var graphe = new Graphe(3);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3);
            graphe.AjouterLien(3, 1); // Cycle : 1 -> 2 -> 3 -> 1
            
            // Act & Assert
            Assert.True(graphe.ContientCycle());
        }

        [Fact]
        public void ContientCycle_RetourneFalseSiPasDeCycle()
        {
            // Arrange
            var graphe = new Graphe(3);
            graphe.AjouterLien(1, 2);
            graphe.AjouterLien(2, 3);
            
            // Act & Assert
            Assert.False(graphe.ContientCycle());
        }
    }
}
