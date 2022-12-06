using System.Reflection;
using System.Text;
using TourParTour.Library;

Random random = new Random();

Joueur personnagePrincipale = new Joueur(200, 11);
Ennemi bossDeCombat = new Ennemi(250, 18);

Console.WriteLine("Appuyer sur les touches après les × pour effectuer les actions");

while (personnagePrincipale.vieJoueur > 0 && bossDeCombat.vieEnnemi > 0)
{
    Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────┐");
    Console.WriteLine("│                                  Tour du Joueur                                  │");
    Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────┘");
    Console.WriteLine("┌────────────────────┐    ┌───────────────────────────┐");
    Console.WriteLine($"│ Point de Vie : {(personnagePrincipale.vieJoueur*100)/200}% │    │ Point de Vie Ennemi : {(bossDeCombat.vieEnnemi * 100) / 250}% │");
    Console.WriteLine("└────────────────────┘    └───────────────────────────┘");
    Console.WriteLine("→ Appuyer sur [A] pour attaquer");
    Console.WriteLine("→ Appuyer sur [S] pour utiliser un sort de soin");
    Console.WriteLine("→ Appuyer sur [F] pour prendre la fuite");

    string choix = Console.ReadLine();

    switch(choix)
    {
        case "A":
            int degatInfligeParJoueur = personnagePrincipale.degatJoueur * random.Next(1, 4);
            bossDeCombat.vieEnnemi -= degatInfligeParJoueur;
            Console.WriteLine($"Vous avez retiré {degatInfligeParJoueur} PV au Boss");
            break;

        case "S":
            int vieGagne = personnagePrincipale.degatJoueur * random.Next(1, 3);
            if (personnagePrincipale.vieJoueur >= 200)
            {
                Console.WriteLine("Vous êtes déjà au maximum de vos points de vie.");
            } else {
                personnagePrincipale.vieJoueur += vieGagne;
                Console.WriteLine($"Vous avez récupéré {vieGagne} PV.");
            }
            break;

        case "F":
            Console.WriteLine($"Vous prenez la fuite!");
            Environment.Exit(0);
            break;
    }

    if (bossDeCombat.vieEnnemi > 0)
    {
        Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine("│                                   Tour du Boss                                   │");
        Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────┘");
        int degatInfligeParEnnemi = bossDeCombat.degatEnnemi * random.Next(3); // 30% de Chances de Critiques ou de ne pas pouvoir Taper.

        if (degatInfligeParEnnemi == 0 )
        {
            personnagePrincipale.vieJoueur -= degatInfligeParEnnemi;
            Console.WriteLine("Le boss a raté son coup.");
        } 
        else if (degatInfligeParEnnemi == 30)
        {
            personnagePrincipale.vieJoueur -= degatInfligeParEnnemi;
            Console.WriteLine($"Le boss vous a retiré {degatInfligeParEnnemi} PV");
        } 
        else
        {
            personnagePrincipale.vieJoueur -= degatInfligeParEnnemi;
            Console.WriteLine($"Coup Critique! Vous venez de perdre {degatInfligeParEnnemi} PV");
        }
    } else
    {
        Console.Clear();
        Console.WriteLine("Bravo! Vous avez vaincu le boss");
    }

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
}