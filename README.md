# Library_OOP

project opdracht voor Object Oriented Programming AP '24

# Boekenbibliotheek Applicatie

## Overzicht

Deze C# console applicatie simuleert een bibliotheeksysteem waar gebruikers boeken kunnen toevoegen, verwijderen, zoeken en bekijken. Het project maakt gebruik van objectgeoriënteerd programmeren principes, met de klassen `Book` en `Library` als kernonderdelen van de applicatie.

## Klasse: Book

### Eigenschappen

De `Book` klasse bevat de volgende eigenschappen:

- ISBN-nummer (String): Uniek identificatienummer voor het boek.
- Titel (String): De titel van het boek.
- Auteur (String): De naam van de auteur van het boek.
- Genre (Enumeration): Het genre van het boek, gedefinieerd door een enum met vooraf bepaalde waarden zoals Fictie, Non-Fictie, Wetenschap, enz.
- Publicatiejaar (Integer): Het jaar waarin het boek is gepubliceerd.
- Aantal Pagina's (Integer): Het aantal pagina's in het boek.
- Taal (String): De taal waarin het boek is geschreven.
- Uitgever (String): De uitgever van het boek.

### Controles

Bij het toewijzen van waarden aan de eigenschappen van een boek worden de volgende controles uitgevoerd:

- De titel van een boek mag niet leeg zijn.
- Het ISBN-nummer moet een geldige format hebben.
- Het publicatiejaar moet in het verleden liggen.
- Het aantal pagina's moet positief zijn.

### Constructor

De constructor vereist de titel, auteur, en een referentie naar een `Library` object.

### Methoden

- `ToonInfo()`: Toont alle informatie van het boek op een duidelijke manier.
- `DeserializeerVanCSV(string csvBestand)`: Leest een lijst van boeken uit een CSV-bestand en voegt deze toe aan de bibliotheek.

## Klasse: Library

### Eigenschappen

- Naam (String): De naam van de bibliotheek.
- Boeken (List<Book>): Een lijst met alle boeken in de bibliotheek.

### Constructor

Maakt een nieuwe bibliotheek met een specifieke naam.

### Methoden

- `VoegBoekToe(Book boek)`: Voegt een nieuw boek toe aan de bibliotheek.
- `VerwijderBoek(string ISBN)`: Verwijdert een boek op basis van het ISBN-nummer.
- `ZoekBoekTitelAuteur(string titel, string auteur)`: Zoekt naar een boek op basis van titel en auteur.
- `ZoekBoekISBN(string ISBN)`: Zoekt naar een boek op basis van het ISBN-nummer.
- `ZoekBoekenAuteur(string auteur)`: Geeft een lijst van boeken van een specifieke auteur.
- `ZoekBoekenEigenschap()`: Zoekt naar boeken die voldoen aan een specifieke eigenschapswaarde.

## Menu

Bij het starten van de applicatie wordt eerst een nieuwe `Library` aangemaakt. Vervolgens wordt een keuzemenu weergegeven waarmee de gebruiker verschillende acties kan uitvoeren:

1. Een boek toevoegen aan de bibliotheek.
2. Informatie aan een boek toevoegen.
3. Alle informatie van een boek tonen.
4. Een boek opzoeken.
5. Een boek verwijderen uit de bibliotheek.
6. Alle boeken tonen uit de bibliotheek.

De applicatie blijft in het menu tot de gebruiker kiest om te stoppen.

## CSV Bestandsformaat

Voor het deserialiseren van boeken uit een CSV-bestand, moet het bestand de volgende kolommen bevatten: ISBN, Titel, Auteur, Genre, Publicatiejaar, Aantal Pagina's, Taal, Uitgever.

---

Dit `README.md` bestand biedt een overzicht van de functies en structuur van de Boekenbibliotheek applicatie. Pas de inhoud aan op basis van de specifieke details en vereisten van je project.

