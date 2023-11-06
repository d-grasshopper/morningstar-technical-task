# Morningstar Technical Test

## What is provided

- .NET 7 API, using Minimal API approach
- MSSQL DB
- React frontend

The API and DB have been dockerized, and unit tests run as part of the Docker build process for the API. The react frontend is expected to be ran locally from a terminal.

## Running

1. Run .NET API and DB

```zsh
docker-compose up -d --build --remove-orphans
```

2. Run React frontend

```zsh
cd frontend

npm run start
```

3. Open `http://localhost:5005/swagger`

4. Paste content of `test_data.json` into `POST /people` endpoint and click "Execute"

5. Go to `http://localhost:3000`

## Assumptions made/general thoughts

Proper validation of search terms is not in the project, would generally add with FluentValidation.

DB usage can be optimized, in general would include normalized fields and include a column with the full name for easier searching. Not having these right now means that we have to use a workaround for our matching of terms against fields in the DB.

Frontend is very bare-bones, no attempt was made to make it pretty.
