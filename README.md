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

