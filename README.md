# RedisCacheCountriesTest

API para testar o funcionamento do REDIS como cache.
<br/>Utilizamos a API do RestCountries para fazer a busca da lista de países.
<br/>https://restcountries.com/v3.1/all

## Como testar

Primeiro, você precisa ter uma instância do Redis rodando localmente.
Tendo isso, você precisa alterar a configuração no arquivo "Program.cs" com a configuração do seu REDIS, no seguinte trecho:

<br/>`builder.Services.AddStackExchangeRedisCache(options => `
<br/>`{`
<br/>    `options.InstanceName = "My Redis test instance";`
<br/>   ` options.Configuration = "localhost:6379";`
<br/>`});`

Com essa configuração feita, basta executar o projeto e dar um GET no endpoint "/api/Countries" 

Na primeira execução, iremos buscar a lista de países e armazenaremos essa informação no cache.
Da segunda em diante, antes do cache expirar, a API buscará diretamente da instância do cache.

