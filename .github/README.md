# Desafio Técnico - MP


  [Sobre o projeto](#about) •
  <a href="#installation">Instalação</a> •
  <a href="#packages">Pacotes utilizados no projeto</a> •
  <a href="#build-exec">Build e Execução</a> •
  <a href="#author">Author</a>

## Sobre o projeto {#about}
O objetivo geral do desafio é implementar uma aplicação console gerador de arquivos. Para cumprir o objetivo, o algoritmo utiliza um crawler para recuperar o texto base para logo após utilizar buffers de tamanho pré-definido pelo usuário para realizar a escrita contínua e repetida em um arquivo de tamanho também pré-definido e no final gerar um relatório impresso no console que mostra informações como: nome do arquivo, quantidade de iterações, tempo total gasto na escrita, etc.

## Instalação {#installation}

### Passos de download e instalação:

Como o projeto foi desenvolvido em .NET Core 3.1, será necessário baixá-lo para a execução:

* **[.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)**

#### Clone do projeto

Realize a instalação do GIT para conseguir executar as próximas etapas de instalação:

* **[GIT](https://git-scm.com/downloads)**

Será necessário realizar o clone do repositório para a execução em sua máquina local. Digite o comando abaixo em seu terminal:

```
git clone https://github.com/eduardosbcabral/desafio-tecnico-mp.git
```

## Pacotes utilizados no projeto {#packages}

- Selenium.WebDriver (3.141.0)

## Build e Execução {#build-exec}

Para buildar e executar o projeto, entre no diretório ```src/``` e execute o seguinte comando:

```
dotnet run -- -f 5 -b 1 -p "DIRETÓRIO NA SUA MÁQUINA (EX: D:\dev)"
```

#### Argumentos

A aplicação faz o uso de alguns argumentos de execução para seu funcionamento, que são os seguintes:
- **-f**: Define o tamanho do arquivo a ser escrito. Deve ser um número inteiro positivo.
- **-b**: Define o comprimento do buffer que será utilizado para a escrita do arquivo. Deve ser um número inteiro positivo.
- **-p**: (OBRIGATÓRIO) Define o caminho que será escrito o arquivo.

### Arquivo executável
Se achar necessário, é possível gerar um arquivo executável executando o comando abaixo dentro do diretório ```src/```:
Obs: o comando publish irá gerar por padrão um executável ```.exe```, ou seja, Windows.

```
// Executável Windows implícito
dotnet publish -c Release

// Executável Windows explícito
dotnet publish -c Release -r win10-x64

// Executável Linux
dotnet publish -c Release -r ubuntu.16.10-x64
```

Para executar o arquivo, entre na pasta ```src/bin/Release/netcoreapp3.1/{win10-x64|ubuntu.16.10-x64}/publish/``` e insira o comando abaixo:
```
// Executável Windows
 DesafioTecnicoMP.exe -f 5 -b 1 -p "DIRETÓRIO NA SUA MÁQUINA (EX: D:\dev)"
// Executável Linux
DesafioTecnicoMP -f 5 -b 1 -p "DIRETÓRIO NA SUA MÁQUINA (EX: D:\dev)"
```
## Autor {#author}
<table>
  <tr>
    <td align="center"><a href="https://github.com/eduardosbcabral"><img style="border-radius: 50%;" src="https://avatars2.githubusercontent.com/u/29133996?s=460&u=5b6448ac95459d30e91293f9893d9fafe54fb523&v=4" width="100px;" alt=""/><br /><sub><b>Eduardo Cabral</b></sub></a><br />
  </tr>
</table>
