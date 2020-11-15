## DIO API.Net com MongoDB
### Exemplo adaptado para mostrar os conhecimentos adquiridos na aula.

Fiz umas alterações no projeto(original https://github.com/gabrielfbarros/dotnet-mongo) do gabrielfbarros, mostrado na aula(Construindo um projeto de uma API.NET integrada ao MongoDB), adaptando para a inserção e listagem de produtos. O endpoint é "**/produtos**" com o verbo **GET** ele lista os produtos e com o verbo **POST** ele adiciona um novo produto passando no corpo as informações do mesmo conforme exemplo abaixo:

    {
    "Nome": "Produtos 02",
    "Preco": 103.99
    }
O usuário e senha colocados no arquivo appsettings.json só tem acesso a esse database e será **desativado no fim desse bootcamp**.
