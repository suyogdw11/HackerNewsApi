The API can be run on Visual Studio 2019/2022 using Asp.NET Core 6
Please install the below NugetPackages to ensure the successful build.
  <ItemGroup>
    <PackageReference Include="AutoMapper" Version="10.0.0" />
    <PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="8.0.1" />
    <PackageReference Include="Refit" Version="7.0.0" />
    <PackageReference Include="Refit.HttpClientFactory" Version="7.0.0" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.2.3" />
  </ItemGroup>


  **Note:** Here I have used Refit to call the external HackerNewsAPI Endpoints.

  **Some conceptual points for Refit**
    1. Refit is an automatic type-safe REST library for .NET.
  2. Refit turns a REST API into a live interface.
  3. Refit reduces the amount of code required to call APIs by eliminating the need to manually construct HTTP requests and handle responses.
  4. It provides automatic serialization and deserialization of data.
