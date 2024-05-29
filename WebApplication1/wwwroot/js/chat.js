const { data } = require("jquery");
const { signalR } = require("./signalr/dist/browser/signalr")

$(document).ready(function)() {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    connection.start().then(function () {
        console.log('SignalR Started...')
        viewModel.roomList();
        viewModel.userList();
    })


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

        self.joinRoom = function (room) {
            connection.invoke("Join", room.name())
                .then(function () {
                    self.joinedRoom(room.name());
                    self.joinedRoomId(room.id());
                    self.userList();
                    self.messageHistory();
                });
        }


        self.roomList = function () {
            fetch('/api/Rooms')
                .then(response => response.json())
                .then(data => {
                    self.chatRooms.removeAll();
                    for (var i = 0; i < data.length; i++) {
                        self.chatRooms.push(new ChatRoom(data[i].id, data[i].name));
                    }

                    if (self.chatRooms().length > 0)
                        self.joinRoom(self.chatRooms()[0]);
                });
        }

        self.creatRoom = function () {
            var roomName = $("#roomName").val();
            fetch('/api/Rooms'), {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ name: roomName })
            });
        }
        self.userList = function () {
            connection.invoke("GetUsers", self.joinedRoom()).then(function (result) {

                self.chatUsers.removeAll();
                for (var i = 0; i < result.length; i++) {
                    self.chatUsers.push(new ChatUser(result[i].username,
                        result[i].fullName,
                        result[i].avatar == null ? "default-avatar.png" : result[i].avatar,
                        result[i].currentRoom,
                        result[i].device))
                }
            });
        }
    }
    function ChatUser(userName, displayName, avatar, currentRoom, device) {
        var self = this;
        self.userName = ko.observable(userName);
        self.displayName = ko.observable(displayName);
        self.avatar = ko.observable(avatar);
        self.currentRoom = ko.observable(currentRoom);
        self.device = ko.observable(device);
    }

    function ChatRoom(id, name) {
        var self = this;
        self.id = ko.observable(id);
        self.name = ko.observable(name);
    }
    function ChatMessage(content, timestamp, from, isMine, avatar) {
        var self = this;
        self.content = ko.observable(content);
        self.timestamp = ko.observable(timestamp);
        self.from = ko.observable(from);
        self.isMine = ko.observable(isMine);
        self.avatar = ko.observable(avatar);
    }

    var viewModel = new AppviewModel();
    ko.applyBindings(viewModel);
})