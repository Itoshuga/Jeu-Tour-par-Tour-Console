﻿using System.Collections;
using System.Reflection;
using System.Text;
using TourParTour.Library;

#region Déclarion des Variables Aléatoire & Personnages
Random random = new Random();

Joueur personnagePrincipale = new Joueur(200, 11, 100, 2);
Ennemi bossDeCombat = new Ennemi(250, 18);
#endregion

#region Déclaration des Compétences
var skillCollection = new List<Competence>();

Competence bouleDeFeu = new Competence("Boule de Feu", 17, 25, "BDF");
Competence lanceDeGlace = new Competence("Lance De Glace", 14, 20, "LDG");

skillCollection.Add(bouleDeFeu);
skillCollection.Add(lanceDeGlace);


#endregion

Console.WriteLine("Appuyer sur les touches après les × pour effectuer les actions");
Thread.Sleep(500);

// Tant que nos deux personnages ont de la vie, le jeu continue
while (personnagePrincipale.vieJoueur > 0 && bossDeCombat.vieEnnemi > 0)
{
    #region Tour du Joueur
    Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────┐");
    Console.WriteLine("│                                  Tour du Joueur                                  │");
    Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────┘");
    Console.WriteLine("┌────────────────────┐      ┌────────────────────┐     ┌───────────────────────────┐");
    Console.WriteLine($"│ Point de Vie : {(personnagePrincipale.vieJoueur*100)/200}% │      │ Mana Restant : {personnagePrincipale.manaJoueur}% │     │ Point de Vie Ennemi : {(bossDeCombat.vieEnnemi * 100) / 250}% │");
    Console.WriteLine("└────────────────────┘      └────────────────────┘     └───────────────────────────┘");
    Console.WriteLine("→ Appuyer sur [A] pour attaquer");
    Console.WriteLine("→ Appuyer sur [S] pour ouvrir votre grimoire");
    Console.WriteLine("→ Appuyer sur [F] pour prendre la fuite");

    // On récupère ce qui est écrit et on y convertit en majuscule
    string choix = Console.ReadLine().ToString().ToUpper() ;
    int degatInfligeParJoueur;

    if (choix == "A")
    {
        degatInfligeParJoueur = personnagePrincipale.degatJoueur * random.Next(1, 4);
        bossDeCombat.vieEnnemi -= degatInfligeParJoueur;
        Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine($"Vous avez retiré {degatInfligeParJoueur} PV au Boss");
        Thread.Sleep(1000);

    } else if (choix == "S") {
        Console.WriteLine("┌───────────────────┐");
        Console.WriteLine("│  Liste des Sorts  │");
        Console.WriteLine("└───────────────────┘");
        foreach (var skill in skillCollection)
        {
            Console.WriteLine($"→ {skill._nomCompetence} × {skill._keyForUse}");
        }
        string choixSort = Console.ReadLine();

        switch (choixSort) {
            case "BDF":
                degatInfligeParJoueur = personnagePrincipale.puissanceMagique * bouleDeFeu.degatCompetence;
                personnagePrincipale.manaJoueur -= bouleDeFeu.manaCompetence;
                bossDeCombat.vieEnnemi -= degatInfligeParJoueur;
                Console.WriteLine($"Vous avez infligé {degatInfligeParJoueur} PV au Boss");
                Thread.Sleep(2000);
                break;

            case "LDG":
                degatInfligeParJoueur = personnagePrincipale.puissanceMagique * lanceDeGlace.degatCompetence;
                personnagePrincipale.manaJoueur -= lanceDeGlace.manaCompetence;
                bossDeCombat.vieEnnemi -= degatInfligeParJoueur;
                Console.WriteLine($"Vous avez infligé {degatInfligeParJoueur} PV au Boss");
                Thread.Sleep(2000);
                break;
            default:
                Console.WriteLine("Il semble que vous vous êtes tromper dans l'incantation de votre sort, Tour perdu!");
                Console.WriteLine("Cliquer sur [ENTRER] pour continuer");
                Console.ReadLine();
                break;
        }

    } else if (choix == "F") {
        Console.WriteLine($"Vous prenez la fuite!");
        Environment.Exit(0);

    } else {
        Console.WriteLine("Vous êtes tomber avant de toucher votre cible, Tour perdu!");
        Console.WriteLine("Cliquer sur [ENTRER] pour continuer");
        Console.ReadLine();
    }
    #endregion

    #region Tour du Boss
    if (bossDeCombat.vieEnnemi > 0)
    {
        Console.Clear();
        Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine("│                                   Tour du Boss                                   │");
        Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────┘");
        int degatInfligeParEnnemi = bossDeCombat.degatEnnemi * random.Next(3); // 30% de Chances de Critiques ou de ne pas pouvoir Taper.

        if (degatInfligeParEnnemi == 0 )
        {
            personnagePrincipale.vieJoueur -= degatInfligeParEnnemi;
            Console.WriteLine("Le boss a raté son coup.");
            Thread.Sleep(2000);
        } 
        else if (degatInfligeParEnnemi == 18)
        {
            personnagePrincipale.vieJoueur -= degatInfligeParEnnemi;
            Console.WriteLine($"Le boss vous a retiré {degatInfligeParEnnemi} PV");
            Thread.Sleep(2000);
        } 
        else
        {
            personnagePrincipale.vieJoueur -= degatInfligeParEnnemi;
            Console.WriteLine($"Coup Critique! Vous venez de perdre {degatInfligeParEnnemi} PV");
            Thread.Sleep(2000);
        }
    } else
    {
        Console.Clear();
        Console.WriteLine("Bravo! Vous avez vaincu le boss");
    }
    #endregion

    #region Défaite
    if (personnagePrincipale.vieJoueur < 0)
    {
        Console.Clear();
        Console.WriteLine("Le Boss vous à mis à terre...");
        Console.WriteLine("Souhaitez-vous recommencer ?");
        Console.WriteLine("→ Appuyer sur [Y] pour relancer une partie");
        Console.WriteLine("→ Appuyer sur [N] pour fermer la console");
        switch (choix)
        {
            case "Y":

                break;

            case "N":
                Environment.Exit(0);
                break;

        }
    }
    #endregion
}