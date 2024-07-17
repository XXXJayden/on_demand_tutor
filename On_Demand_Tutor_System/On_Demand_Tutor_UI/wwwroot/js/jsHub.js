"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub", {
    transport: signalR.HttpTransportType.WebSockets
})
    .configureLogging(signalR.LogLevel.Debug)
    .build();

connection.on("ReceiveMessage", function () {
    location.reload();
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

