# ElasticsearchExample

An ASP.NET Core 8 Web API project demonstrating how to integrate **Elasticsearch** for indexing and searching data.

## Project Structure

This project follows a layered architecture and consists of the following layers:

1. **ElasticsearchExample.Domain**  
   - Holds the domain models (e.g. `Product`, DTO classes).  
   - Represents the core entities used by the application.

2. **ElasticsearchExample.ElasticsearchService**  
   - Contains the logic for connecting to Elasticsearch via **NEST**.  
   - Provides methods to create indices, insert documents, update, delete, and perform searches.

3. **ElasticsearchExample.Presentation**  
   - The ASP.NET Core Web API layer.  
   - Exposes endpoints (controllers) for CRUD operations (Create, Read, Update, Delete) and searching.

---

## Technologies Used

- **.NET 8** (ASP.NET Core)
- **Elasticsearch** (run via Docker using the official Elasticsearch image)
- **NEST** (for Elasticsearch communication)

---

## How to Run

### 1. Start Elasticsearch (and Kibana) with Docker

Use the provided `docker-compose.yml` to run Elasticsearch (and Kibana) locally:

```bash
docker-compose up -d


### Explanation of the Sections

1. **Title and Introduction**  
   Clearly states the project’s name (*ElasticsearchExample*) and its main objective (using Elasticsearch in an ASP.NET Core Web API).

2. **Project Structure**  
   Explains each layer in the solution:  
   - **Domain** holds models (entities, DTOs).  
   - **ElasticsearchService** contains the integration logic for Elasticsearch.  
   - **Presentation** exposes the controllers and endpoints.

3. **Technologies Used**  
   Lists core frameworks and libraries: .NET 8, Elasticsearch, and NEST.

4. **How to Run**  
   - Instructs how to start Elasticsearch and Kibana with `docker-compose up -d`.  
   - Shows how to configure the application via `appsettings.json`.  
   - Explains how to run the .NET solution (`dotnet run`).  
   - Highlights the available REST endpoints for CRUD and search operations.

With this **README**, anyone viewing your repository can quickly understand what the project does, how it’s structured, and how to get it running locally.

