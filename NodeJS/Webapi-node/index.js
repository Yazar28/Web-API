const express = require('express');
const { randomUUID } = require('crypto');
const app = express();
const PORT = 3000;

app.use(express.json());

// CLASES
class Node {
    constructor(value) {
        this.id = randomUUID();
        this.value = value;
        this.next = null;
    }
}

class LinkedList {
    constructor() {
        this.head = null;
    }

    add(value) {
        const newNode = new Node(value);
        if (this.head === null) {
            this.head = newNode;
        } else {
            let current = this.head;
            while (current.next !== null) {
                current = current.next;
            }
            current.next = newNode;
        }
        return newNode.id;
    }

    getAll() {
        const result = [];
        let current = this.head;
        while (current !== null) {
            result.push({ id: current.id, value: current.value });
            current = current.next;
        }
        return result;
    }

    remove(id) {
    if (this.head === null) return false;

    // Si el nodo a eliminar es el primero
    if (this.head.id === id) {
        this.head = this.head.next;
        return true;
    }

    let current = this.head;
    while (current.next !== null) {
        if (current.next.id === id) {
            current.next = current.next.next;
            return true;
        }
        current = current.next;
    }

    return false; // No se encontró
}
}

const linkedList = new LinkedList();

app.get('/', (req, res) => {
    res.send('Servidor funcionando ✅');
});

app.get('/linked-list', (req, res) => {
    res.json(linkedList.getAll());
});

app.post('/linked-list', (req, res) => {
    const { value } = req.body;

    if (typeof value === 'undefined') {
        return res.status(400).json({ error: 'Falta el campo "value"' });
    }

    const id = linkedList.add(value);
    res.status(201).json({ id });
});

app.delete('/linked-list/:id', (req, res) => {
    const { id } = req.params;
    const eliminado = linkedList.remove(id);

    if (eliminado) {
        res.json({ mensaje: `Nodo con id ${id} eliminado` });
    } else {
        res.status(404).json({ error: 'Nodo no encontrado' });
    }s
});

app.listen(PORT, () => {
    console.log(`Servidor escuchando en http://localhost:${PORT}`);
});