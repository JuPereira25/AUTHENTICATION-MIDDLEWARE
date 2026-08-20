# AuthChallenge
Solução implementada em API ASP.NET Core para o desafio de autenticação descrita em PROBLEM.md

## Solução

Toda request passa pelo middleware `TokenValidationMiddleware` **antes** de chegar na rota.

1. O middleware lê o header `Authorization`.
2. `TokenValidation.IsValid` compara o valor com o token esperado: `vYQIYxOpyfr`.
3. Se for igual, a request segue e a rota responde **204 No Content**.
4. Se faltar o header ou o valor for diferente, responde **401** com o texto `Invalid token`.

O token tem que ser **exatamente** `vYQIYxOpyfr`. Sem prefixo `Bearer`.

Arquivos principais:

- `AuthChallenge/Program.cs` — registra o middleware e a rota `/foo-bar`
- `AuthChallenge/Service/TokenValidationMiddleware.cs` — intercepta as requests
- `AuthChallenge/Service/Token.cs` — valida o token

## Como rodar

Na pasta `AuthChallenge`:

```powershell
dotnet run --launch-profile http
```

A API sobe em `http://localhost:5043`.

## Como testar no VS Code

1. Deixe a API rodando.
2. Abra `AuthChallenge/AuthChallenge.http`.
3. Clique em **Send Request** acima do `GET` (não no URL).

O arquivo já tem três testes:

| Teste | Header | Resposta esperada |
| --- | --- | --- |
| Token válido | `Authorization: vYQIYxOpyfr` | 204 No Content |
| Token errado | `Authorization: token-errado` | 401 Invalid token |
| Sem header | (nenhum) | 401 Invalid token |

