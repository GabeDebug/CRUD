# MeuCrud

Aplicação console simples em C# para gerenciar produtos (CRUD) usando um arquivo JSON local (`produto.json`).

## Estrutura

- Projeto: `MeuCrud` (pasta `MeuCrud/`)
- Arquivo de dados: `produto.json` (localizado no diretório onde o programa é executado)
- Framework alvo observado no build: `net10.0`

## Requisitos

- .NET SDK compatível com `net10.0` (instale a versão adequada do .NET SDK)

## Como compilar e executar

Abra um terminal na raiz do repositório e execute:

```bash
cd MeuCrud
dotnet build
dotnet run
```

Ou execute diretamente em modo debug/IDE (Visual Studio / VS Code).

## Uso

Ao executar a aplicação, o menu interativo exibe as opções:

- `1` - Adicionar produto (informe nome e preço)
- `2` - Listar todos (exibe ID, nome e preço formatado)
- `3` - Buscar por ID (informa o ID e mostra detalhes do produto)
- `4` - Atualizar produto (informe ID, novo nome e novo preço)
- `5` - Remover produto (informe ID para deletar)
- `0` - Sair

Os dados são salvos em `produto.json` automaticamente após operações que alteram o conjunto de produtos.

## Observações e boas práticas

- Faça backup de `produto.json` antes de mudanças manuais.
- Valide entradas (números e formatos) se for integrar a uma interface gráfica ou API.

## Contribuição

Sinta-se à vontade para abrir issues ou pull requests com melhorias.

## Licença

Coloque aqui a licença do seu projeto (ex.: MIT) ou remova esta seção se não aplicável.
