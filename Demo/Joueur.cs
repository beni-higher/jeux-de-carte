namespace Demo;

public class Joueur
{
    // CHAMPS CONSTANTS
    
    private const int MaxCartes = 8;
   
    // CHAMPS

     Table _table = new Table();
     Carte _listCarte = new Carte();
    
    public  List<Carte> _main;
    public int Id;
    public string Prenom;
    public string Nom;

    public bool MaxCartesAtteint
    {
        get { return _main.Count >= MaxCartes; }
    }

    // CONSTRUCTEURS

    public Joueur(int id, string prenom, string nom)
    {
        _main = new List<Carte>();
        Id = id;
        Prenom = prenom;
        Nom = nom;
    }
    
    // MÉTHODES

    public void Piocher(Carte cartePiochee)
    {
        _main.Add(cartePiochee);
    }

    public void Deposer(Carte carteDeposee)
    {
        
        _main.Remove(carteDeposee);
        
    } 
}