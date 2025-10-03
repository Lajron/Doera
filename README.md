# Doera Project

## Getting Started

This project uses Docker Compose to orchestrate the ASP.NET Core application and SQL Server database.

### Prerequisites

- [Docker](https://www.docker.com/get-started) installed
  
### Running the Application

1. **Clone this repository**  
   ```bash
   git clone https://github.com/Lajron/Doera.git
   cd Doera
   ```

2. **Start the services**  
   ```bash
   docker compose up
   ```
   This will build and start both the `doera` ASP.NET app and the SQL Server database.

3. **Access the application**  
   - The web app will be available at [http://localhost:8080](http://localhost:8080)
   - SQL Server will be available on port 1433 locally.

4. **Stopping the services**
   ```bash
   docker compose down
   ```

### Data Persistence

- Database files and ASP.NET data protection keys are stored in Docker volumes for persistence between restarts.

---

## Additional Commands

- To rebuild the containers:
  ```bash
  docker compose build
  ```

- To run in detached mode:
  ```bash
  docker compose up -d
  ```

---

## License

This project is licensed under the MIT License.
