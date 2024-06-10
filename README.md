# Quebra-Cabeça Deslizante (8-Puzzle) - Implementação de Busca

Este projeto implementa dois algoritmos de busca para resolver o problema do quebra-cabeça deslizante 8-puzzle: Busca em Amplitude (BFS) e Busca pela Melhor Escolha (Best-First Search)., desde a implementação do problema até a análise dos resultados obtidos.

## Estrutura do Projeto
### Execução
- **Program.cs:** Ponto de entrada do programa. Configura os estados iniciais e executa as análises de busca.
- **QuebraCabeca.cs:** Define a estrutura do quebra-cabeça, incluindo métodos para verificar se está resolvido, gerar movimentos possíveis e calcular heurísticas.
- **ResolutorQuebraCabeca.cs:** Implementa os algoritmos de busca (BFS e Best-First Search).
- **AnaliseBusca.cs:** Realiza a análise de tempo e memória usados pelos algoritmos de busca.

## Pré-requisitos
.NET SDK (versão 6.0 ou superior)

## Instruções para Execução

1. Clone o Repositório
```bash
git clone https://github.com/seu-usuario/nome-do-repositorio.git
cd nome-do-repositorio
```
 2. Compile o Projeto

No diretório do projeto, execute o seguinte comando para compilar o projeto:
```bash
dotnet build
```
 3. Execute o Projeto

Execute o projeto usando o seguinte comando:
```bash
dotnet run
```


## Etapas de implementação

### Etapa 1: Implementação do Problema (branch etapa1)

Nesta etapa, o foco está na compreensão do problema do quebra-cabeça deslizante e na representação do espaço de estados por meio de um grafo.

### Etapa 2: Implementação da Solução - Busca em Largura (branch etapa2)

Na segunda etapa, implementamos a solução para o problema utilizando o algoritmo de busca em largura (amplitude). O código correspondente está disponível e será acompanhado por um vídeo explicativo.

### Etapa 3: Implementação da Solução - Busca pela Melhor Escolha (branch etapa3)

Na terceira etapa, exploramos a implementação da solução utilizando o algoritmo de busca pela melhor escolha.

### Etapa 4: Análise de Resultados (branch etapa4)

Por fim, na quarta etapa, realizamos uma análise detalhada dos resultados obtidos, incluindo a melhor solução encontrada, o consumo de recursos e uma análise de diferentes entradas.

## Personalização
- **Adicionar Novos Estados Iniciais**

Para adicionar novos estados iniciais, edite a lista estadosIniciais no arquivo Program.cs:
  ```bash
    List<string> estadosIniciais = new List<string>
    {
        "123804765", // exemplo 1
        "283164705", // exemplo 2
        "283104765", // exemplo 3
        "213804756"
        // Adicione outros estados iniciais conforme necessário
    };
  ```

- **Configurar Algoritmos de Busca**

  No arquivo Program.cs, você pode alternar entre os algoritmos de busca modificando as chamadas dentro do loop:
  ```bash
  // Análise para Busca em Amplitude (BFS)
  AnaliseBusca.AnalisarBusca(quebraCabecaInicial, "BFS");
 
  // Análise para Busca pela Melhor Escolha (Best-First Search)
  AnaliseBusca.AnalisarBusca(quebraCabecaInicial, "Best-First");

  ```
## Observações
Projeto completo está na branch 'Main'

Link da explicação da implementação do código: https://youtu.be/MkZ0GxKdPew

## Contribuição

Sinta-se à vontade para contribuir com melhorias, correções de bugs ou novas funcionalidades. Para contribuir, siga os passos abaixo:

1. **Fork o Repositório**
2. **Crie uma Branch para sua Feature** (`git checkout -b feature/nova-feature`)
3. **Commit suas Modificações** (`git commit -m 'Adiciona nova feature'`)
4. **Push para a Branch** (`git push origin feature/nova-feature`)
5. **Abra um Pull Request**

## Licença

Este projeto está licenciado sob a <span style="color:blue">MIT License</span>.
