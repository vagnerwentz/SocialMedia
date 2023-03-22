# SocialMedia

## .NET Microservices: CQRS & Event Sourcing with Kafka

### What is a Command?
A Command, is a combination of expressed intent. In other words it describes an action that you want to be performed. 
It also contains the information that is required to undertake the desired action.

Commands are always named with a **verb** in the imperative mood.
For example: *NewPostCommand, LikePostCommand, AddCommentCommand*

### What is an Event?
Events are objects that describe something that has occured in the application. A typical source of events is the aggregate.
When somenthing important happens in the aggregate, it will raise an event

Events are named with a **past-participle** verb.
For example: *PosCreatedEvent, PostLikedEvent, CommentAddedEvent*

### What is an Aggregate?
The aggregate can be viewed as the domain entity on the write or command side of a
CQRS and Event Sourcing based application or service, similar to the domain entity that you find on the read or query side.
When you create the Aggregate class, you will see that it is difficult at first glance to view the aggregate as a domain entity,
because unlike the domain entity on the read sidem it is not simple plain old C# object that contains only state and no behaviour.

IMPORTANT - The fundamentals differences in its structure is due to the fundamental
differences in how the data is stored in the write database ir event store vs how it is stored in the read database.

The read side is simple one instance of the domain entity represents one record in the read database.

The write side is more complex, because there we store the data as a sequence of immutable events over time. In other words, we store all the state changes
and we save these state changes in the form of events that are versioned.

The design of the aggregate should therefore allow you to be able to use these events to recreate or replay the latest state of the Aggregate,
so that you do not have to query the read database for the latest state, else the hard separation of commands and queries would be in vain.

### Event Store - Key Considerations

An Event Store must be an append only store. No update or delete operations should be allowed

Each event that is saved, should represent the version or state of an aggregate at any given point in time

Events should be stored in chronological order and new events should be appended to the previous event

The state of the aggregate should be recreatable by replaying the event store

Implement optimistic concurrency control

# Event Producer

## Kafka Cluster
![KafkaCluster](https://user-images.githubusercontent.com/26815672/226778952-91c43bce-821d-4801-a193-ef496ca55b51.png)

## Kafka Broker
![KafkaBroker](https://user-images.githubusercontent.com/26815672/226779053-e1932f90-a566-4929-b354-da33c87a2e88.png)

--

Events e Aggregate Roots são conceitos relacionados que são frequentemente usados em conjunto na implementação de padrões de design de software baseados em Domain-Driven Design (DDD).

Em DDD, um Aggregate Root é uma entidade de negócios que é responsável por garantir a consistência e a integridade dos dados dentro de um grupo relacionado de objetos. Os eventos são usados para notificar outras partes do sistema quando ocorre uma mudança no estado do Aggregate Root.

Quando uma mudança ocorre em um Aggregate Root, em vez de atualizar o estado diretamente no banco de dados, um evento é criado para notificar outras partes do sistema sobre a mudança. Esses eventos são então tratados por outros objetos que podem atualizar o banco de dados ou tomar outras ações necessárias.

Por exemplo, suponha que temos um Aggregate Root "Pedido" que contém informações sobre um pedido de compra em um sistema de comércio eletrônico. Quando um novo pedido é criado, um evento "PedidoCriado" é disparado. Esse evento pode ser tratado por outros objetos, como um serviço de envio, que usa as informações do pedido para enviar uma notificação de envio ao cliente.

Em resumo, os eventos são usados em conjunto com Aggregate Roots para manter a integridade dos dados e permitir que outras partes do sistema respondam a mudanças no estado do Aggregate Root.
