<template>
    <h1>Messages</h1>

    <div v-if="loading">
        Loading messages...
    </div>

    <table v-if="messages" class="messages">
        <thead>
            <tr>
                <th>TimeStamp</th>
                <th>Message</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="message in messages" :key="message.id">
                <td>{{ message.timeStamp }}</td>
                <td>{{ message.messageBody }}</td>
            </tr>
        </tbody>
    </table>

    <h2>Send message</h2>
    <select name="recipient" id="recipient" class="messageArea">
        <option v-for="recipient in recipients" :key="recipient.id" value="{{recipient.id}}">{{recipient.email}}</option>
    </select>

    <br />

    <textarea rows="10" class="messageArea" id="messageBody" />

    <br />

    <button @click="addMessage()">Send</button>

</template>

<script>

    import messageHub from '../signalr';

    export default {
        name: 'MessageCenter',
        data() {

            return {
                loading: false,
                messages: null,
                recipients: null,
            };

        },
        created() {

            this.getMessages();
            this.getRecipients();

            messageHub.client.on("NewMessage", function (newMessage) {
                alert(newMessage.messageBody);
                this.messages.push(newMessage);
            });

            messageHub.client.on("NewUser", function (newUser) {
                this.recipients.push(newUser);
            });

            messageHub.start();

        },
        methods: {

            getMessages() {
                let formData = new FormData();
                formData.append('recipientId', '2');

                const request = new Request(
                    "https://localhost:7138/api/getMessages",
                    {
                        method: "post",
                        body: formData,
                        mode: "cors",
                        cache: "default"
                    }
                );

                this.messages = null;
                this.loading = true;

                fetch(request)
                    .then(r => r.json())
                    .then(json => {
                        this.messages = json;
                        this.loading = false;
                        return;
                    });
            },

            getRecipients() {
                let formData = new FormData();
                formData.append('userId', '1');

                const request = new Request(
                    "https://localhost:7138/api/getRecipients",
                    {
                        method: "post",
                        body: formData,
                        mode: "cors",
                        cache: "default"
                    }
                );

                this.messages = null;

                fetch(request)
                    .then(r => r.json())
                    .then(json => {
                        this.recipients = json;
                        return;
                    });
            },

            addMessage() {

                let formData = new FormData();
                formData.append('senderUserId', 1);
                formData.append('recipientUserId', 2);
                formData.append('messageBody', document.getElementById("messageBody").value);

                const request = new Request(
                    "https://localhost:7138/api/addNewMessage",
                    {
                        method: "post",
                        body: formData,
                        mode: "cors",
                        cache: "default"
                    }
                );

                fetch(request);
            },

        },
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .messages {
        width: 500px;
    }
    .messages td, th { text-align:left; }
    .messageArea { width: 500px; margin:5px; }
</style>