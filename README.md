# Gestione Ristorante – Applicazione Web in Blazor

## Descrizione del Progetto
Questo progetto è un’applicazione web di un ristorante realizzata con **Blazor**.  
L’obiettivo dell’applicazione è fornire una piattaforma gestionale per un ristorante, consentendo l’amministrazione di contenuti e dati attraverso pagine CRUD e componenti riutilizzabili. Il progetto dimostra l’utilizzo dell’architettura Blazor, del routing a componenti e dell’integrazione con servizi e dati lato server.

L’applicazione permette di:
- Visualizzare il **menu del ristorante** (piatti e categorie)
- Gestire le **prenotazioni dei clienti**
- Gestire **utenti e personale** con livelli di accesso
- Eseguire **operazioni CRUD** (Create, Read, Update, Delete) sui dati
- Accedere alle funzionalità tramite **autenticazione** con login e registrazione
- Navigare tra le sezioni tramite routing Blazor

---

## Tecnologie Utilizzate
- **Blazor / ASP.NET Core**
- **C#**
- **Razor Components**
- **Entity Framework / DB relazionale** (CRUD)
- **Dependency Injection**
- **.NET** (versione indicata nel progetto)
- **Bootstrap / CSS** per la parte grafica

---

## Architettura del Progetto
Il progetto segue l’architettura tipica Blazor, basata su componenti e services:

| Sezione | Descrizione |
|----------|------------|
| `Pages/` | Pagine Blazor che gestiscono il routing e mostrano le viste principali |
| `Shared/` | Componenti condivisi (layout, menu, navbar, footer, ecc.) |
| `wwwroot/` | File statici (CSS, immagini, script) |
| `Data/` | Modelli, servizi e logica per l’accesso ai dati |
| `Program.cs` | Configurazione dell’app, routing e servizi |

Ogni pagina utilizza servizi in **Dependency Injection** per interagire con i dati, seguendo una separazione tra logica e interfaccia.

---

## Funzionalità Principali
- **Autenticazione** con login e registrazione
- **Gestione Menu**
  - Aggiunta, modifica e rimozione di piatti
  - Visualizzazione per categorie
- **Gestione Prenotazioni**
  - Inserimento nuove prenotazioni
  - Eliminazione o modifica delle prenotazioni esistenti
- **Gestione Utenti**
  - Ruoli o livelli di permessi (se presenti)
- **Routing e Navigazione**
  - Interfaccia single-page con layout condiviso
  - Navigazione fluida senza refresh completo

---

## Come Eseguire il Progetto
Prerequisiti:
- **.NET SDK** installato (versione compatibile con il progetto)
- Eventuale database configurato (se richiesto nella `appsettings.json`)

Per avviare l’applicazione:

```bash
dotnet restore
dotnet run
```
## Poi aprire il browser su:
https://localhost:5001
