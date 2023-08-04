// chat.js

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${user} says ${message}`;
});

connection.start()
    .then(function () {
        console.log("SignalR connection established.");
        document.getElementById("sendButton").disabled = false;
    })
    .catch(function (err) {
        console.error(err.toString());
    });

document.getElementById("sendButton").addEventListener("click", function (event) {
    event.preventDefault();
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    connection.invoke("SendMessage", user, message)
        .catch(function (err) {
            console.error(err.toString());
        });

    // Clear input fields after sending the message
    document.getElementById("messageInput").value = "";
});
