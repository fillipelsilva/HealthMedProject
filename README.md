![fiap](https://github.com/daviEmanuelNogueira/Crm/assets/104274261/1c28656a-8218-41ed-aeed-5aeae252becc)

## 🎖️ Hackathon - Turma .NET:
**Arquitetura de Sistemas .NET com Azure** <br>
<br>
A Health&Med, é uma Operadora de Saúde que tem como objetivo digitalizar seus processos e operação. O principal gargalo da empresa é o Agendamento de Consultas Médicas, que atualmente ocorre exclusivamente através de ligações para a central de atendimento da empresa. <br>
Recentemente, a empresa recebeu um aporte e decidiu investir no desenvolvimento de um sistema proprietário, visando proporcionar ***um processo de Agendamentos de Consultas Médicas 100% digital e mais ágil.***
Para viabilizar o desenvolvimento de um sistema que esteja em conformidade
com as melhores práticas de desenvolvimento, a Health&Med contratou os alunos
do curso de Pós Graduação .NET da FIAP para fazer a análise do projeto e
desenvolver o MVP da solução.
__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## 📱 Objetivo do Projeto:
<br>
O objetivo do Hackathon é a entrega de um produto de MVP desenvolvido e que
cumpra os requisitos funcionais e não funcionais. <br>
<br>
__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## 💂‍♀️ Participantes: 

- [Alex dos Santos Rosa](https://github.com/aleqsrosa) - RM352258; 
- [Davi Emanuel Torres de Souza Nogueira](https://github.com/daviEmanuelNogueira) - RM351602;
- [Fillipe Luis da Silva](https://github.com/fillipelsilva) - RM352110;
- [Pedro Henrique Sousa de Abreu](https://github.com/PedroAbreuHS) - RM352428.

| [<img loading= "lazy" src = "https://github.com/daviEmanuelNogueira/Crm/assets/104274261/2b4eee74-cbab-4192-91ab-19b75e45bc87" width=115>](https://github.com/aleqsrosa) | [<img loading= "lazy" src = "https://github.com/daviEmanuelNogueira/Crm/assets/104274261/e556f2d4-5312-4670-a54a-046c7de3a42d" width=115>](https://github.com/daviEmanuelNogueira) | [<img loading= "lazy" src = "https://github.com/daviEmanuelNogueira/Crm/assets/104274261/1455c943-2f52-4fcf-999b-1f1614f5cf0a" width=115>](https://github.com/fillipelsilva) | [<img loading= "lazy" src = "https://github.com/daviEmanuelNogueira/Crm/assets/104274261/0c879524-949c-492d-bf16-ea613defa63e" width=115>](https://github.com/PedroAbreuHS)
| :---: | :---: | :---: | :---: |
| Alex Rosa - RM352258 | Davi Nogueira - RM351602 | Fillipe Silva - RM352110 | Pedro Abreu - RM352428 |
| [![GitHub](https://img.shields.io/badge/-black?style=flat-square&logo=Github&link=https://github.com/danielecastroalves)](https://github.com/aleqsrosa) | [![GitHub](https://img.shields.io/badge/-black?style=flat-square&logo=Github&link=https://github.com/danielecastroalves)](https://github.com/daviEmanuelNogueira) | [![GitHub](https://img.shields.io/badge/-black?style=flat-square&logo=Github&link=https://github.com/danielecastroalves)](https://github.com/fillipelsilva) | [![GitHub](https://img.shields.io/badge/-black?style=flat-square&logo=Github&link=https://github.com/danielecastroalves)](https://github.com/PedroAbreuHS) |
__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## ⚙️ Tecnologias:
* C#;
* .NET 7;
* ASP.NET Core;
* SQLSERVER;
__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## 🥋 Skills Desenvolvidas:
* Comunicação;
* Trabalho em Equipe;
* Networking;
* Muito conhecimento técnico.
__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


## ⚙️ Levantamento de Requisitos e Critérios de Aceite:

### Requisitos Funcionais:<br>
<br>
1. Cadastro do Usuário (Médico); <br>
<br>
O médico deverá poder se cadastrar, preenchendo os campos
obrigatórios: Nome, CPF, Número CRM, E-mail e Senha.<br>
<br>
2. Autenticação do Usuário (Médico);<br>
<br>
O sistema deve permitir que o médico faça login usando o E-mail e uma
Senha.<br>
<br>
3. Cadastro/Edição de Horários Disponíveis (Médico);<br>
<br>
O sistema deve permitir que o médico faça o Cadastro e Edição de seus
horários disponíveis para agendamento de consultas.<br>
<br>
4. Cadastro do Usuário (Paciente);<br>
<br>
O paciente poderá se cadastrar preenchendo os campos: Nome, CPF, Email
e Senha.<br>
<br>
5. Autenticação do Usuário (Paciente);<br>
<br>
O sistema deve permitir que o paciente faça login usando um E-mail e
Senha.<br>
<br>
6. Busca por Médicos (Paciente);<br>
<br>
O sistema deve permitir que o paciente visualize a listagem dos médicos
disponíveis.<br>
<br>
7. Agendamento de Consultas (Paciente):<br>
<br>
Após selecionar o médico, o paciente deve poder visualizar a agenda do
médico com os horários disponíveis e efetuar o agendamento.<br>
<br>
8. Notificação de consulta marcada (Médico):<br>
<br>
Após o agendamento, feito pelo usuário Paciente, o médico deverá
receber um e-mail contendo: <br>
<br>
<br>
Título do e-mail: <br>
<br>
”Health&Med - Nova consulta agendada”
Corpo do e-mail:<br>
<br>

”Olá, Dr. {nome_do_médico}!
Você tem uma nova consulta marcada!<br>
<br>
Paciente: {nome_do_paciente}.
Data e horário: {data} às {horário_agendado}.” <br>
<br>
<br>

### Requisitos Não Funcionais:<br>
<br>
1. Concorrência de Agendamentos;<br>
<br>
O sistema deve ser capaz de suportar múltiplos acessos simultâneos e
garantir que apenas uma marcação de consulta seja permitida para um
determinado horário.<br>
<br>
2. Validação de Conflito de Horários.<br>
<br>
O sistema deve validar a disponibilidade do horário selecionado em tempo
real, assegurando que não haja sobreposição de horários para consultas
agendadas.<br>
<br>
__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## 🧪 Desenvolvimento (Build e Execução do Projeto):

### Arquitetura:
A estrutura para o desenvolvimento foi baseada e implementada considerando os principios da Arquitetura Limpa e a divisão em camadas:
- Domain;
- Infrastructure;
- Application;
- API;
- Testes.

### Persistência dos Dados:
O banco de dados escolhido foi o SQL Server, por ser um banco relacional e garantir os princípios ACID.

### Testes:
O padrão utilizado é pensado nos testes unitários, testes de integração e regras de negócio.

### Build e Execução do Projeto:
Para executar esses projetos você precisa seguir as etapas abaixo:
- Acessar o repositório do projeto através do link: https://github.com/fillipelsilva/HealthMedProject;
- Baixar o zip do projeto ou fazer um fork do mesmo;
- Abrir o projeto, preferencialmente, na IDE Visual Studio considerando que facilitará para a execução;
- Configurar a api como startup project;
- Rodar o comando update-database no package manage console apontando para o projeto de infraestrutura;
- Clicar na opção, configurar startup projects, selecionar startup projects e colocar o projeto Health-Med.API como start;
- Após iniciar o navegador será iniciado a interação com o sistema, possibilitando o registro de um pré cadastro;

__________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## ⚙️ Apresentação YouTube:


