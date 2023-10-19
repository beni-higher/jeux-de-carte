namespace Demo;

public struct Carte
{
    // CHAMPS

    private readonly Valeur _valeur;
    private readonly Couleur _couleur;

    public string Nom
    {
        get {return $"{_valeur} de {_couleur}";}
    }
    
    // CONSTRUCTEURS

    public Carte(Valeur valeur, Couleur couleur)
    {
        _valeur = valeur;
        _couleur = couleur;
    }
   
    // MÉTHODES

    // Génère un paquet complet de 52 cartes
    public static List<Carte> GenererPaquet()
    {
        // Cette expression est équivalente à une double boucle foreach
        // qui itère toutes les combinaisons de couleurs et de valeurs
        return (from Valeur val in Enum.GetValues(typeof(Valeur)) 
            from Couleur coul in Enum.GetValues(typeof(Couleur)) 
            select new Carte(val, coul)).ToList();
    }
    
    // Vérifie si la carte donnée peut être jouée sur celle-ci (couleur ou valeur identique)
    public bool Compatible(Carte aComparer)
    {
        return (_couleur == aComparer._couleur || _valeur == aComparer._valeur);
    } 
}