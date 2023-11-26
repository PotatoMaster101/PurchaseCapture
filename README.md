# Purchase Capture
Solution for Tim Corey's [Back-End Development Challenge](https://www.youtube.com/watch?v=BbxjvV3d9pY) using the clean architecture.

## Running
1. Create DB migrations:
```
dotnet ef migrations add InitialCreate --project src/PurchaseCapture.Persistence --startup-project src/PurchaseCapture.Presentation --context ApplicationDbContext
```
2. Start Postgres DB:
```
docker compose up -d
```
3. Run Blazor project:
```
dotnet run -c Release --project src/PurchaseCapture.Presentation
```

## TODO
- Create `New Item` page for adding new items
    - `New Purchase` page should show dropdown for item name
