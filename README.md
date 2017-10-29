# meuCarro

```
.Net Core 
```

## Estudos de Caso – Controle de Frota

Muitas empresas estão utilizando frotas próprias para agilizar o trabalho de seus
funcionários. Essa é uma medida muito interessante que tem que ser bem
gerenciada. Precisamos fazer o gerenciamento das pessoas que utilizam os
veículos para não haver usos indevidos e dos veículos que necessitam manutenção,
ver se ele está disponível ou não, enfim temos vários controles a fazer.
A partir deste cenário vamos trabalhar o contexto de cada disciplina.

Alguns dados para montagem desse cenário:
a) Empresa com 40 funcionários;
b) A frota é composta de veículos com as devidas características: por exemplo:
fabricante, modelo, cor, placa, tipo de combustível, quantidade de portas e
opcionais.
c) O veículo pode ser utilizado ocasionalmente por qualquer funcionário
devidamente autorizado.
d) O funcionário deverá preencher um formulário de solicitação de reserva do
veículo e encaminhar ao setor de frotas.
e) O formulário de reserva contém: identificação do funcionário, data/hora,
quantidade de passageiros e destino.
f) O setor de frota recebe esse formulário e verifica se existe veículo disponível para
ser utilizado naquela data e hora. Se houver disponibilidade faça a reserva,
alocando um veículo para esse formulário e retorna ao solicitante o número do
veículo reservado. Em caso negativo, retorna a indisponibilidade ao solicitante
encerrando essa solicitação.
g) O funcionário recebe a resposta do setor de frotas, e comparece na data e hora
combinadas para retirar o veículo. Ao retirar o veículo, ele anota a quilometragem
inicial no formulário de devolução.
h) Após a utilização do veículo, o funcionário deve completar o formulário de
devolução que contém a identificação do funcionário e do veículo, a data/horal da
devolução e quilometragem final.
