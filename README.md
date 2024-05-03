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

Docker-compose

## Para executar a imagem docker, instale o docker na sua maquina local

Execute o comando: docker-compose up no diretorio que estiver o arquivo

Acessar a url: http://localhost:15672/#/queues

# RabbitMQ properties
services:
  rabbitmq:
    image: rabbitmq:latest  # Use 'latest' for the most recent version
    container_name: rabbitmq_management-v1  
    ports:
      - 5672:5672 # (erlang) communication between the nodes and CLI tool
      - 15672:15672 # communication with the web management API
    volumes:
      # data persistence
      - /docker_conf/rabbitmq/data/:/var/lib/rabbitmq/
      # data mapping -> host: container
      # queues and messages data of the container will be stored on the host
    environment:
      - RABBITMQ_DEFAULT_USER=admin
      - RABBITMQ_DEFAULT_PASS=123456
    restart: always

volumes:
  logs-folder:
    name: ${log_rabbitmq_management}
    driver: local
