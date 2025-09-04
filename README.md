STRUTTURA PROGETTO
1.JobBoardSample.Api
2.JobBoardSample.BlazorApp
3.JobBoardSample.Maui
4.JobBoardSample.Shared


1.JobBoardSample.Api
il progetto è suddiviso in:
- Controllers -> Espongo API a cui il front può fare richieste HTTP
- Data -> Due file JSON dove sono salvati i dati
- Repositories -> Contiene due classi che leggono i dati dai file JSON e li convertono in liste, in modo da poterle utilizzare nella nostra applicazione.


2.JobBoardSample.BlazorApp
Progetto creato per poter programmare un interfaccia web in blazor.
il file principale che descrive il front è Home.razor,
questo file descrive la pagina principale dell'applicazione, con una searchbox, filters e delle cards che rappresentano le posizioni lavorative aperte.
Il secondo file è Admin che visualizza la pagina dedicata all'admin-> la apikey si trova all'interno del file appsettings.json del progetto 1.JobBoardSample.Api


3.JobBoardSample.Maui
- Progetto uguale a quello Blazor, con la sola differenza della URL api
- Come connettersi al back:
  1. Avviare JobBoardSample.Api
  2. Avviare Ngrok -> ngrok http 5017
  3. Prendere la url simile a -> https://83c9b6813f53.ngrok-free.app ed inserirla in Home.razor @code{... private readonly string ApiBaseUrl = "https://83c9b6813f53.ngrok-free.app"; ...}
  5. Avviare JobBoardSample.Maui
     
4.JobBoardSample.Shared
La tipologia di questo progetto è un razor class library, necessario per condividere codice tra BlazorApp e MAUI.

Classi comuni nel progetto che ricprono il ruolo di Models
- Applcations
- Positions

DTO
Creato per la paginazione lato server
- PositionsResponse
Creati per lo stato
- UpdateStatusRequest

Liste per select e options nel front
-Localities
-Departments


