# Variação do Ativo EMBR3.SA

Está API consiste de uma rota que busca e cálcula o preço de um ativo nos últimos 30 pregões, foi desenvolvida com o .NET 7 e SQL Server como banco de dados.

## Executando a API e banco de dados

### É obrigatório as portas 1433 e 5000 estarem liberadas

1. Fazer pull do projeto
2. Abra um prompt de comando no dirétorio `VariacaoAtivo\Infra`
3. Execute o comando `docker-compose build` 
4. Execute o comando `docker-compose up` 
4. Abra um prompt de comando no dirétorio `VariacaoAtivo\src\VariacaoAtivo\VariacaoAtivo.API`
5. Execute o comando `dotnet ef database update`
6. Cole no navegador o link `http://localhost:5000/VariacaoAtivo`

## Acesso a base de dados

A base é SQL Server o usuário é `sa` e a senha é `senha@1234` .

## Exemplo

Esta aplicação consiste em consultar a variação do preço de um ativo a sua escolha nos últimos 30 pregões. Apresentar o percentual de variação de preço de um dia para o outro e o percentual desde o primeiro pregão apresentado.

| Dia   | Data          |  Valor    | Variação em relaçào a D-1     | Variação em relação a primeira data
|-      | -             | -         | -                             | - 
|2      |  01/01/2021   |  R$ 1,00  | -                             | -
|3      |  02/01/2021   |  R$ 1,10  | 10%                           | 10%
|4      |  03/01/2021   |  R$ 1,05  | -4,54%                        | 5%
|5      |  04/01/2021   |  R$ 1,90  | 80,95%                        | 90%

Para este desafio, iremos utilizar a API do Yahoo Finance https://finance.yahoo.com/ 

