# ECommerceSystem

## Open and run
1. Open `ECommerceSystem.sln` in Visual Studio.
2. Allow NuGet restore to complete.
3. Press `Ctrl+F5`.

Requires the .NET 10 SDK and a Visual Studio version that supports .NET 10. The project uses SQLite and creates its local database automatically on first run.

## Relationships
Category → Products is one-to-many; Customer → Orders is one-to-many; Order ↔ Product is many-to-many through OrderDetail. The OrderDetail composite key is (OrderId, ProductId).

See `Database-Diagram.png` for the relationship diagram.
