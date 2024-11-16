# TesteMD

## Descrição do Projeto

Este projeto é um sistema de gestão com funcionalidades de cadastro, consulta, venda e geração de relatórios de clientes e produtos. Inclui gráficos de vendas semanais e mensais na tela inicial, proporcionando uma visão rápida do desempenho do negócio.


## Funcionalidades

### Tela Inicial

-   Exibe um gráfico de vendas, mostrando o desempenho semanal e mensal.

### Clientes

-   **Cadastro de Clientes**: Tela para inserir novos clientes no sistema.
-   **Exibição de Clientes**: Mostra uma lista de clientes em um gridview, com as seguintes funcionalidades:
    -   **Pesquisa por Nome**: Permite filtrar clientes por nome.
    -   **Alteração de Informações**: Opção para editar dados de clientes.
    -   **Exclusão de Clientes**: Função para remover clientes do sistema.
-   **Relatório de Clientes**: Gera um relatório detalhado dos clientes cadastrados.

### Produtos 
-   **Cadastro de Produtos**: Similar à aba de clientes, esta seção permite inserir e gerenciar produtos.
-   **Exibição de Produtos**:  Lista de produtos com funcionalidades de pesquisa, alteração e exclusão.
    -   **Pesquisa por Nome**: Permite filtrar produtos por nome.
    -   **Alteração de Informações**: Opção para editar dados de produtos.
    -   **Exclusão de Produtos**: Função para remover produtos do sistema.
-   **Relatório de Produtos**: Gera um relatório completo dos produtos cadastrados.

### Vendas (PDV)

-   **Cadastro de Vendas**: Tela estilo PDV onde é possível registrar vendas, adicionando:
    -   **Nome do cliente associado.**
    -   **Ao usar um leito de código de barras ou colar manualmente um código de barras, ele é inserido automaticamente no grid de vendas.**
-   **Finalização de Venda**: Permite concluir e registrar a venda no sistema.

### Relatórios de Vendas

-   **Relatório de Vendas**: Gera um relatório das vendas realizadas, auxiliando na análise de desempenho.

## Imagem das Telas
Abaixo, imagens de cada tela do sistema para melhor entendimento da interface e funcionalidades:

-   Tela Inicial com gráficos
![enter image description here](https://i.imgur.com/8gL2Rps.jpeg)
---
-   Menu de Clientes
![enter image description here](https://i.imgur.com/oCLDj3I.gif)
---
-   Menu de Produtos
![enter image description here](https://i.imgur.com/UOLrqAD.gif)



--- 
-  Tela de Vendas (PDV)
-![enter image description here](https://i.imgur.com/xNzCVR1.gif)
---
## Tecnologias Utilizadas
-   **C#** com **Windows Forms**
-   **PostgreSQL (Versão17.0-1)** para o banco de dados
-   **ReportViewer** para relatórios
-   **Git** para versionamento de código

## Passo a Passo para Instalação e Configuração

### Pré-requisitos

-   **Internet** para download das ferramentas

### Passo 1: Instale o PostgreSQL

1.  Baixe o PostgreSQL [aqui](https://www.postgresql.org/download/).
2.  Siga as instruções do instalador para concluir a instalação.
3.  Durante a instalação, crie uma senha para o usuário **postgres** e anote-a para configurar a conexão com o sistema.
4.  Após a instalação, abra o **pgAdmin** (ferramenta gráfica do PostgreSQL) ou um cliente de SQL de sua preferência.
5.  Crie o banco de dados usando os scripts de criação e configuração em `/database`.

### Passo 2: Instale o Visual Studio

1.  Baixe o Visual Studio [aqui](https://visualstudio.microsoft.com/).
2.  Instale a versão **Community** (gratuita) ou outra de sua preferência.
3.  Durante a instalação, selecione o **.NET desktop development** para suportar C# e Windows Forms.
4.  Após a instalação, abra o Visual Studio e configure-o conforme as preferências iniciais.

### Passo 3: Clone o Repositório

1.  Abra o Git Bash ou seu terminal de preferência.
2.  Execute o comando para clonar o repositório:
    
    bash
    
    Copiar código
    
    `git clone <URL do repositório>` 
    
3.  Navegue até a pasta do projeto:
    
    bash
    
    Copiar código
    
    `cd nome-do-projeto` 
    

### Passo 4: Configure o Banco de Dados no Projeto

1.  No Visual Studio, abra o projeto clonado.
2.  No arquivo de configuração de conexão (por exemplo, `app.config` ou outro local no código), insira as credenciais do PostgreSQL:
    -   Servidor: `localhost`
    -   Banco de dados: nome do banco de dados criado
    -   Usuário: `postgres`
    -   Senha: senha definida no PostgreSQL

### Passo 5: Compile e Execute o Projeto

1.  No Visual Studio, clique em **Build** > **Build Solution** para compilar o projeto.
2.  Após a compilação, clique em **Start** para executar o sistema.
