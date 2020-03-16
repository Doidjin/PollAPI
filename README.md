# PollAPI - README 


- Realizar o download e instalar o [SQLite](https://www.sqlite.org/index.html)
- Realizar o download e instalar o [VisualStudioCode](https://code.visualstudio.com/)


## Configurando a ConnectionString no projeto
- Abrir o projeto utilizando o [Vistual Studio Code](https://code.visualstudio.com/)
- Localizar e abrir o arquivo **Startup.cs** na pasta raiz do projeto
- Procurar a região definida pelo método **ConnfigureServices**

```
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PoolContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddCors();
        }
```
- Depois localizar o arquivo **appsettings.json**
```
{
  "ConnectionStrings": {
    "DefaultConnection" : "Data source=poolapp.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```


## Executando a API no Visual Studio Code
- Com o projeto ainda aberto no **Visual Studio Code**, importar a API,e digitar  **dotnet watch run** no terminal integrado

 ## Comandos utilizados no projeto
 - Utilizar o comando primeiramente
 ```
dotnet tool install --global dotnet-ef
 ```
 - Se quiser restaurar o banco de dados, o codigo abaixo ira restaura-lo 
```
dotnet ef database drop 
 ```

## Comandos para a criacao do Banco
```
dotnet ef migrations add InitialCreate
dotnet ef migrations add OptionDatabase
dotnet ef migrations add ViewDatabase
dotnet ef migrations add VoteDatabase
 ```
- Por fim, o comando abaixo criara o banco que sera inserido no **SQlite**
```
dotnet ef database update 
 ```

 ## Dependencias utilizadas
 ```
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="3.0.0"/>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="3.0.0"/>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="3.0.0"/>
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="3.0.0"/>
 ```

# As estruturas do banco se encontram assim
- Options  
    * option_id, option_description, poll_id
    * 1         , "this is a test", 1
    * 2         , "this is a test2", 2

- Values
    * poll_id, poll_description
    * 1     , "This is a test"

- Views
    * poll_id, date
    * 1, 2020-03-13 22:35:49.017761

- Votes
    * option_id, date
    * 1, 2020-03-13 22:35:49.017761

----
#####  As requisições utilizadas para a realização dos testes via Postman se encontram neste [link](https://documenter.getpostman.com/view/2722732/SzS4R7PE) 

