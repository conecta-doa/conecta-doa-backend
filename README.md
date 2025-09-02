# conecta-doa-backend
Olá pessoal, espero que estejam bem! Segue um passo a passo de como rodar o projeto e subir no github.

- [Requisitos](#requisitos)
- [1 - Clonar o projeto](#1--clone-o-projeto)
- [2 - Verificar atualizações](#2---verifique-atualizações)
- [3 - Criar branch](#3---crie-a-sua-branch)
- [4 - Commits](#4---commits)
- [5 - Push](#5---push)
- [6 - Pull Request](#6---criando-a-pull-request)
- [Tipos de branches](#tipos-de-branches)
- [Requisitos para rodar a aplicação](#requisitos-para-rodar-a-aplicação)
- [Como rodar o projeto](#como-rodar-o-projeto)

## Requisitos
- [Git](https://git-scm.com/downloads)
- Uma IDE (VSCode, Visual Studio, etc)

## 1- Clone o projeto
- Na sua IDE, faça o seguinte comando 

```bash
git clone https://github.com/conecta-doa/conecta-doa-backend.git
```

## 2 - Verifique atualizações
- Essa parte é bem importante, esporádicamente rode:
```bash
# Esse comando fará a verificação de novas mudanças (seja branchs, commits e etc)
git fetch
```
- Caso tenha algo para atualizar rode:
```bash
# Esse comando trará as atualizações para a sua branch local
git pull
```

## 3 - Crie a sua branch
- Crie a sua branch para desenvolvimento a partir da master
- Por favor, siga este padrão tipo-de-branch/nome-enxuto-do-que-foi-desenvolvido
- Ex:

```bash
# Para criar a sua branch
git branch feature/update-readme

# Para selecionar a branch criada
git checkout feature/update-readme


git branch fix/ajuste-no-login

git checkout fix/ajuste-no-login


git branch chore/atualizacao-dependencias

git checkout chore/atualizacao-dependencias
```

## 4 - Commits
- Quando criar/modificar/deletar algo é necessário salvar na branch, para isso usamos:

```bash
# Adiciona as mudanças
git add .
```

```bash
git commit -m "mensagem que diz o que mudou"
```

## 5 - Push
- Quando finalmente acreditar que terminou faça o push para atualizar no GitHub
```bash
git push origin nome-da-sua-branch
```

## 6 - Criando a Pull Request
- Para criar a PR é necessário ter seguido os passos anteriores.
- Após fazer o Push, entre no github, vá para o [repositório do back-end](https://github.com/conecta-doa/conecta-doa-backend#), clique em Pull Requests e lá irá aparecer este botão:
<p align="center">
    <img alt="pull request" src="https://private-user-images.githubusercontent.com/160268301/484364606-f9a768dc-0a38-4552-ad6b-10a48dba2582.png?jwt=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NTY3NzgzMjYsIm5iZiI6MTc1Njc3ODAyNiwicGF0aCI6Ii8xNjAyNjgzMDEvNDg0MzY0NjA2LWY5YTc2OGRjLTBhMzgtNDU1Mi1hZDZiLTEwYTQ4ZGJhMjU4Mi5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjUwOTAyJTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI1MDkwMlQwMTUzNDZaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT1kMTJjMjA3NDE0ZDBjMWE0ZjEyM2M2ZGU5NTZlYjIxMTc4MGI5ODRiNmNlZDlmYzNhNDUyOGUyZjMyM2QwYjNlJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCJ9.uh8AYoaooxfvVR4yJAvlu2vVzz0zUDQl3l0a9Yd3-C4">
</p>

- Assim que clicar crie a PR e pronto!
- Agora só esperar a Review, fique atento ao GitHub

## Tipos de branches

### 🔹 `main` (ou `master`)
- **O que é:** branch principal do projeto.  
- **Uso:** contém apenas código estável e pronto para produção.  
- **Quem altera:** somente via Pull Request revisada.  

---
### 🔹 `feature/*`
- **O que é:** branch para novas funcionalidades.  
- **Uso:** cada nova feature deve ser criada a partir da `develop`.  
- **Padrão de nome:**  
  - `feature/nome-da-funcionalidade`  
  - Ex.: `feature/cadastro-usuario`, `feature/integracao-pagamentos`.  

---
### 🔹 `fix/*`
- **O que é:** branch para corrigir bugs.  
- **Uso:** utilizada quando for corrigir problemas detectados no código.  
- **Padrão de nome:**  
  - `fix/descricao-do-bug`  
  - Ex.: `fix/erro-login`, `fix/carrinho-vazio`.  

---

### 🔹 `chore/*`
- **O que é:** ajustes técnicos ou de configuração que não alteram funcionalidades diretamente.  
- **Uso:** atualizações de dependências, configuração de CI/CD, melhorias no código sem mudar comportamento.  
- **Padrão de nome:**  
  - `chore/descricao`  
  - Ex.: `chore/update-dependencies`, `chore/config-docker`.  

---
### 🔹 `docs/*`
- **O que é:** documentação do projeto.  
- **Uso:** ajustes no README, Wiki ou documentação do código.  
- **Padrão de nome:**  
  - `docs/descricao`  
  - Ex.: `docs/update-readme`.

## Requisitos para rodar a aplicação
- [Git](https://git-scm.com/downloads)
- [VSCode](https://code.visualstudio.com/download) (ou outra IDE de sua preferência)
- [.NET 9 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0)  
- [.NET 9 Runtime](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0) 
- [MongoDB](https://www.mongodb.com/try/download/community) (local ou em container Docker)



## Como rodar o projeto

### 🔹 VSCode
- Recomendo instalar a extensão **C# Dev Kit**, que facilita o debug diretamente pelo VSCode.  
- Basta ir em **Run and Debug** (ou usar o atalho `Ctrl + Shift + D`) e rodar a aplicação.


### 🔹 .NET CLI
- Certifique-se de estar no diretório correto do projeto (exemplo: `cd Application.Presentation`).
- Compile a aplicação:
   ```bash
   dotnet build
   ````
- Rode a aplicação:
    ```bash
    dotnet run --urls "https://localhost:7219"
    ```
- Após rodar, a API estará disponível no Swagger: https://localhost:7219/swagger

- Para derrubar a aplicação vá no terminal onde está rondando e aperte Ctrl + C