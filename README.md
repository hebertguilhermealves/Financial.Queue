# Financial.Queue
# API de Mensageria com RabbitMQ e .NET 8

Este projeto demonstra a integração de uma API .NET 8 com RabbitMQ, usando Docker para simplificar o desenvolvimento e a implantação. A API atua como um producer de mensagens, enviando dados para diferentes filas no RabbitMQ conforme solicitado pelos clientes.

## Funcionalidades

- **Envio de Mensagens**: Envia dados assíncronos para filas específicas no RabbitMQ.
- **Gerenciamento de Filas**: Cria e gerencia filas através de uma interface de usuário administrativa do RabbitMQ.
- **Autenticação e Segurança**: Implementa autenticação básica para proteger os endpoints.

## Pré-requisitos

Antes de começar, certifique-se de ter o seguinte software instalado:
- Docker e Docker Compose
- .NET SDK 8

## Configuração Inicial

### Clonagem do Repositório

Clone o repositório para sua máquina local usando:
