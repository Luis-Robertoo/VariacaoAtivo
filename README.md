# Variação do Ativo EMBR3.SA

Está API consiste de uma rota que busca e cálcula o preço de um ativo nos últimos 30 pregões, foi desenvolvida com o .NET 7 e SQL Server como banco de dados.

## Executando a API e banco de dados

### É obrigatório as portas 1433 e 5000 estarem liberadas

1. Fazer pull do projeto
2. Abra um prompt de comando no dirétorio `variacao_ativo\Infra`
3. Execute o comando `docker-compose build` 
4. Execute o comando `docker-compose up` 
4. Navegue até a pasta `variacao_ativo\src\VariacaoAtivo\VariacaoAtivo.API`
5. Execute o comando `dotnet ef database update`
6. Cole no navegador o link `http://localhost:5000/VariacaoAtivo`

## Acesso a base de dados

A base é SQL Server o usuário é `sa` e a senha é `senha@1234` .

