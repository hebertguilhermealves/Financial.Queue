# Financial.Queue
# API de Mensageria com Docker, RabbitMQ e .NET 8

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

Execute o comando: "docker-compose up" no diretorio que estiver o arquivo

Acessar a url: http://localhost:15672/#/queues

# RabbitMQ properties
Instruções de Uso
Salvar o arquivo: Salve o conteúdo acima em um arquivo chamado docker-compose.yml.
Iniciar o RabbitMQ:
bash
Copy code
docker-compose up -d
Este comando inicia o RabbitMQ em modo 'detached', o que significa que ele será executado em background.
Acessar o RabbitMQ Management:
Abra um navegador e acesse http://localhost:15672.
Use as credenciais padrão (usuário: admin, senha: 123456) para fazer login.
Personalização
Você pode personalizar as configurações de usuário, senha e portas modificando as variáveis environment e ports no arquivo docker-compose.yml.

Persistência de Dados
Os dados são persistentes através do volume mapeado em /docker_conf/rabbitmq/data/. Isso significa que os dados do RabbitMQ, como filas e mensagens, serão mantidos entre as reinicializações do container.

Considerações
Certifique-se de alterar a senha padrão para uma mais segura antes de colocar o serviço em um ambiente de produção.
O uso da tag latest para a imagem Docker pode levar a atualizações inesperadas. Considere usar uma tag específica da versão para ambientes de produção.
Suporte e Contribuições
Para suporte e contribuições, por favor, abra uma issue ou envie um pull request para o repositório.
