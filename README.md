# CV-Webbapplikation med Docker

## Beskrivning

Det här är en enkel webbapplikation för att visa ett CV med data om certifikat, erfarenheter. Applikationen är byggd med .NET 8 (Blazor Server) och använder Entity Framework Core för att kommunicera med en SQL Server-databas.

Applikationen körs i en Docker-miljö där databasen och webbapplikationen ligger i separata containrar men i samma nätverk. Det gör att webbapplikationen kan hämta data från databasen på ett säkert och isolerat sätt.

## Funktionalitet

- Visa listor med certifikat, arbetslivserfarenheter.
- Data sparas och hämtas från en SQL Server-databas som körs i en separat container.
- Applikationen använder Entity Framework Core migrations för att skapa och uppdatera databasen.
- Data "seedas" vid första start för att visa exempeldata.
- Applikationen körs som en Blazor Server-app och är responsiv.

## Så kör du och testar applikationen

1. **Kloning av repo**  
   Klona detta GitHub-repo till din lokala dator:
   git clone <din-repo-url>
   cd <din-repo-mapp>

2. Bygg och starta containrarna med Docker Compose
Kör följande kommando för att bygga och starta webbapplikation och databas:
docker compose up --build

3. Öppna webbläsaren
Gå till: http://localhost:8080
Här ser du din webbapplikation i drift och kan navigera till certifikat och erfarenheter för att se data från databasen.

Stoppa applikationen
Avsluta Docker-processen i terminalen med:
docker compose down

## Tekniska val och Verktyg

Ramverk: .NET 8 med Blazor Server
Valdes för att snabbt och enkelt bygga en interaktiv webbapplikation. Gammalt repo dock men detta var annledningen :)

Databas: SQL Server körd i Docker-container
Separat container gör det lätt att hantera data isolerat från appen.

Entity Framework Core
Används för datamodellering, migrationshantering och för att "seeda" data i databasen automatiskt vid start.

Docker & Docker Compose
Docker används för att paketera app och databas som containrar. Compose hanterar multi-container setup och nätverk.

HttpClient / ApiService
(Valfritt beroende på implementation) För anrop till API:er eller direkt till DbContext i appen.
