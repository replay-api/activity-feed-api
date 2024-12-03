


# Setup

```sh
# Install dotnet-ef Tool
dotnet tool install --global dotnet-ef

# Expected output should be:
# You can invoke the tool using the following command: dotnet-ef
# Tool 'dotnet-ef' (version '9.0.0') was successfully installed.
```

# Migrations
```sh
dotnet ef migrations add CreateActivityFeedSchema
dotnet ef database update
```
