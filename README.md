[![Build status](https://ci.appveyor.com/api/projects/status/be40ai1lfg1wucxw/branch/master?svg=true)](https://ci.appveyor.com/project/tenor/restbus/branch/master)
## Easy, Service Oriented, Asynchronous Messaging and Queueing for .NET ##

RestBus is a high performance library for RabbitMQ that lets you consume ASP.NET Core (ASP.NET 5), Web API and ServiceStack service endpoints via RabbitMQ.

Sending a message is as easy as:

```csharp
var amqpUrl = "amqp://localhost:5672"; //AMQP URI for RabbitMQ server
var serviceName = "samba"; //The unique identifier for the target service

var client = new RestBusClient(new BasicMessageMapper(amqpUrl, serviceName));

//Call the /hello/random endpoint
var response = await client.GetAsync("/hello/random");
```

where `/hello/random` is an ordinary web service endpoint in an ASP.NET Core, Web API or ServiceStack service.  
RestBus routes the request over RabbitMQ, invokes the endpoint and returns the response, without ever hitting the HTTP transport.

[Home page](http://restbus.org) | [Documentation](https://github.com/tenor/RestBus/wiki) | <a href="https://github.com/tenor/RestBus.Examples" target="_blank">Example Projects</a>
------- | ------- | --------

### Getting Started

You can:

1. Use the [Getting Started Guide](https://github.com/tenor/RestBus/wiki/Getting-Started).  
*or*
2. Clone this repo.   
Open `RestBus.sln` in Visual Studio 2015.  
Restore Nuget packages.  
Run the [Examples](https://github.com/tenor/RestBus/tree/master/src/Examples) project.

### Benchmarks

![One Way RPC Test Results](https://raw.githubusercontent.com/tenor/RestBus.Benchmarks/master/images/RabbitMQ/rpc_throughput_20_threads.png)

For more benchmarks, see <a href="https://github.com/tenor/RestBus.Benchmarks" target="_blank">the RestBus.Benchmarks project</a>.

### License

Apache License, Version 2.0
