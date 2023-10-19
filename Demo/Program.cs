// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
using Demo;


public class Program
{
    static Random _random = new Random();
    private static List<Joueur> _joueurs = new List<Joueur>();
    private static Table _table = new Table();
    static int nbCarte = 0;
       
       // MÉTHODES


   static void Main()
   {
       
       Joueur j1 = new Joueur(1, "Beni", "Dikitele");
       Joueur j2 = new Joueur(2, "Tommy", "Egen");
       Joueur j3 = new Joueur(3, "Ghost", "Wonder");
    _joueurs.Add(j1);
    _joueurs.Add(j2);
    _joueurs.Add(j3);
    
    
   DebutPartie();
   MainLoop();
   }

   private static void DebutPartie()
   {
       bool inputValide = false;
       
       while (!inputValide)
       {
           Console.WriteLine("Veuillez entrer le nombre de cartes initial par joueur");
           string strInput = Console.ReadLine();

           if (int.TryParse(strInput, out nbCarte))
           {
               if (2 <= nbCarte && nbCarte <= 8)
               {
                   inputValide = true;
               }
               else
               {
                   Console.WriteLine("L'entrée doit être entre 2 et 8");
               }
           }
           else
           {
               Console.WriteLine("L'entrée doit être un nombre entier");
           }
       }
       
       foreach (var j in _joueurs)
       {
           for (int i = 0; i < nbCarte; i++)
           {
               j.Piocher(_table.Piocher());
               Console.WriteLine(i+" "+j.Prenom + " "+j.Nom+ " a piocher "+j._main[i].Nom);

           }
       }
      
       Console.WriteLine("Debut partie");
      


        
       

   }

   private static void MainLoop()
   {
       // index de random entre 0 et la taille de la liste des joueurs -1
       int indexJoueur = _random.Next(0, _joueurs.Count);
       int indexCarte = _random.Next(0, nbCarte);
      
       //choix du joueur aleatoirement
       Joueur j0 = _joueurs[indexJoueur];
       
       Carte CarteDepose = j0._main[indexCarte];
       j0.Deposer(CarteDepose);
       _table.Deposer(CarteDepose);

       Console.WriteLine("\n"+j0.Prenom+" a deposer "+CarteDepose.Nom);
       bool finPartie = false;

       while (!finPartie)
       {
           indexJoueur = (indexJoueur + 1) % _joueurs.Count;
           bool isDeposer = false;
           foreach (var cart in _joueurs[indexJoueur]._main)
           {
               if (cart.Compatible(_table.Carteactive))
               {
                   _joueurs[indexJoueur].Deposer(cart);
                   _table.Deposer(cart);
                   Console.WriteLine(_joueurs[indexJoueur].Prenom+" a deposer "+cart.Nom); 
                   isDeposer = true;
                   break;
               }
           }
//Verification si la carte est deposee et que la main du joueur est vide

           if (isDeposer)
           {
               if (_joueurs[indexJoueur]._main.Count == 0)
               {
                   Console.WriteLine("\n"+_joueurs[indexJoueur].Prenom + _joueurs[indexJoueur].Nom + " a gagne");
                   finPartie = true;
               }
           }else if (!_joueurs[indexJoueur].MaxCartesAtteint)
           {

               Carte cartePiocher = _table.Piocher();
                _joueurs[indexJoueur].Piocher(cartePiocher);
              
              
               Console.WriteLine("\n"+_joueurs[indexJoueur].Prenom + " "+ _joueurs[indexJoueur].Nom + " a piocher "+ cartePiocher.Nom);

           }
          
         
       }

   }
}