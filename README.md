# Recrutamento

Protótipo local em .NET 10, Razor Pages e Aspire para cadastrar e consultar candidaturas. Os dados são armazenados em SQLite em `Recrutamento.Web/App_Data/candidatos.db` e persistem entre execuções.

## Executar

Instale o SDK do .NET 10 e execute na raiz do repositório:

```sh
dotnet run --project Recrutamento.AppHost
```

Abra o dashboard Aspire no endereço exibido no terminal e acesse o recurso `web`. Também é possível executar apenas a aplicação com `dotnet run --project Recrutamento.Web`.

## Limitações de segurança

Este é um protótipo para uso local: a aplicação aceita apenas conexões de loopback e não possui autenticação ou controle de acesso entre usuários locais. Não exponha a aplicação ou o dashboard à rede nem use dados reais de candidatos. Para produção, implemente autenticação e autorização, proteção e retenção adequadas dos dados pessoais, backups e infraestrutura apropriada.
