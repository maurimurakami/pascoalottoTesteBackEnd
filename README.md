# PascoalottoTesteBackEnd
API para o calculo de juros

### Para rodar o projeto
- Dentro da pasta do projeto, basta fazer um build

    ``` dotnet build ```

- Apos isso, rodar o projeto com:
    
    ``` dotnet run ```

- Com isso sera possivel acessar localmente o projeto. Para acessar o Swagger da API, basta acessar https://localhost:5001/swagger/ui/. La sera possivel testar a funcao de calculo de juros.

- Caso voce preferir pode abrir a solucao do projeto no Visual Studio e inicializar o projeto.

### Swagger
Para utilizar a requisição de cálculo de juros, você pode preencher cada campo com as configurações desejadas.

- InterestType: "simples" ou "composto"

- InterestPercentage: 0 < valor < 1

- ComissionPercentage: 0 < valor < 1

- DebtAmount: 0 < valor

- MonthlyPayments: quantidade de parcela

- Expirationdate: YYYY-MM-DD

