namespace Demo;

public class Table
{
    // CHAMPS

    private readonly List<Carte> _depot;
    private readonly Stack<Carte> _pioche;

    public Carte Carteactive
    {
        get
        {
            return _depot.LastOrDefault();
        }
    }

    // CONSTRUCTEURS

    // Génère une pile de pioche contenant un paquet mélangé 
    public Table()
    {
        _depot = Carte.GenererPaquet();
        _pioche = new Stack<Carte>();
        NouvellePioche();
    }
    
    // MÉTHODES

    // Vide la pile de dépot et place son contenu dans la pile de pioche dans un ordre aléatoire
    public void NouvellePioche()
    {
        Random random = new Random();
        while (_depot.Count > 0)
        {
            int idx = random.Next(_depot.Count);
            _pioche.Push(_depot[idx]);
            _depot.RemoveAt(idx);
        }
    }

    public Carte Piocher()
    {
        Carte cartePiochee = _pioche.Pop();
        if (_pioche.Count == 0) NouvellePioche();
        return cartePiochee;
    }

    public void Deposer(Carte carte)
    {
        _depot.Add(carte);
    }

}