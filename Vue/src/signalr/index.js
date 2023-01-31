import { HubConnectionBuilder } from '@microsoft/signalr';

class MessageHub {
    constructor() {
        this.client = new HubConnectionBuilder()
            .withUrl("https://localhost:7138/messageHub")
            .build();
    }

    start() {
        this.client.start();
    }
}

export default new MessageHub();