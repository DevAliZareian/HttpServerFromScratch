# HttpServer From Scratch

A simple HTTP server written in C# (.NET) from scratch using raw TCP sockets.

## Features

- No external dependencies
- Custom HTTP request parsing
- Static file serving from the `Public` folder
- Color-coded console logging
- Optional secret-key authentication

## Run

```bash
dotnet build
dotnet run --port 3000
```

Optional secret key:

```bash
dotnet run --secret-key my-secret --port 3000
```

Then open `http://localhost:3000`.

## Project Structure

```
Core/        - Server startup and socket handling
Handlers/    - Request handling
Interfaces/  - Server and socket contracts
Protocol/    - HTTP parsing, requests, responses, validation
Public/      - Static files to serve
Utils/       - Logging and path resolution
```

## CLI Arguments

| Argument         | Description                             |
| ---------------- | --------------------------------------- |
| `--port`         | Port to listen on                       |
| `--secret-key`   | Required value for the `Secret-Key` header (optional) |
