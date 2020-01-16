# OfficeBoy
Projeto de estudo RabbitMQ com .Net Core 

## 1. Erlang – Download e instalação
- O Erlang é a linguagem de programação utilizada pelo RabbitMQ e o OTP é o conjunto de bibliotecas e frameworks responsáveis pela execução do Erlang.

- Windows 64 bits: http://erlang.org/download/otp_win64_20.0.exe

## 2. RabbitMQ – Download e instalação
Software de mensageria, responsável pela troca de mensagens entre o ambiente do cliente/Servidor

- Download do software em https://www.rabbitmq.com/releases/rabbitmq-server/v3.6.9/rabbitmq-server-3.6.9.exe

## 2.1 RabbitMQ – Habilitando o gerenciador web
O RabbitMQ possui um gerenciador web que está desabilitado por padrão. Utilizando um prompt de comando (cmd.exe – como Administrador), acesse a pasta `C:\Program Files\RabbitMQ Server\rabbitmq_server-3.6.9\sbin` onde está instalado o RabbitMQ, ou pelo menu iniciar do Windows, selecione o atalho `RabbitMQ Command Prompt`.

EXEMPLO
C:\Program Files\RabbitMQ Server\rabbitmq_server-3.6.9\sbin.

Execute o comando que habilita o gerenciador web:

```sh
rabbitmq-plugins enable rabbitmq_management
```

```sh
Endereço de acesso: 
localhost:15672
User: guest
Pass: guest
```



- Referencia do Codigo: https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
