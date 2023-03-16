dotnet tool update --global dotnet-ef
dotnet build
dotnet ef --startup-project ../Papasi/ database update --context ApplicationDbContext
pause