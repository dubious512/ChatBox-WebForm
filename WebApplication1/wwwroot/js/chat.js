const { signalR } = require("./signalr/dist/browser/signalr")

$(document).ready(function)() {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    function AppviewModel() {
        var self = this;
        self.message = ko.observable("");
        self.chatRooms = ko.observableArray([]);
        self.chatUsers = ko.observableArray([]);
        self.chatMessages = ko.observableArray([]);
        self.joinedRoom = ko.observable("");
        self.joinedRoomId = ko.observable("");
        self.myName = ko.observable("");
        self.myAvatar = ko.observable("avatar1.png");
        self.isLoading = ko.observable(true);

        self.creatRoom = function () {
            var roomName = $("#roomName").val();
            fetch('/api/Rooms'), {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ name: roomName })
            });
        }
    }
}