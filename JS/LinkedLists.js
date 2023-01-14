class Node {
    constructor(value) {
        this.next = null;
        this.prev = null;
        this.value = value;
    }
}

class SentinalLinkedList {
    constructor(...values) {
        this.head = new Node(null);
        this.tail = new Node(null);
        this.head.next = this.tail;
        this.tail.prev = this.head;
        values.forEach(val => this.insertNode(this.tail.prev, val));
    }
    
    addToBack(...values) {
        values.forEach(v => this.insertNode(this.tail.prev, v));
    }

    addToFront(...values) {
        let lastNode = this.head;
        values.forEach(val => lastNode = this.insertNode(lastNode, val));
    }

    insertBefore(searchValue, ...values) {        
        let foundNode = this.searchNode(searchValue);        
        if (foundNode) {
            foundNode = foundNode.prev;
            values.forEach(val => {               
                foundNode = this.insertNode(foundNode, val)
            });        
        }
    }
     
    insertAfter(searchValue, ...values) {
        let foundNode = this.searchNode(searchValue);
        if (foundNode) {
            values.forEach(val => foundNode = this.insertNode(foundNode, val));
        }
    }

    searchNode(val) {
        for (let current = this.head.next; current != this.tail; current = current.next) {
            if (current.value == val) {
                return current;
            }
        } 
        return null;
    }

    insertNode(node, value) {
        const newNode = new Node(value);
        newNode.prev = node;
        newNode.next = node.next;
        newNode.prev.next = newNode.next.prev = newNode;
        return newNode;
    }

    removeNode(node) {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }

    removeNodes(...values) {
        const deletedValues = [];
        let traversed = 0;
        for (let current = this.head.next; current != this.tail && values.length > 0; current = current.next) {
            traversed++;
            if (values.includes(current.value)) {
                values = values.filter(val => val != current.value);
                deletedValues.push(current.value);
                current = current.prev;
                this.removeNode(current.next);
            }
        }
        console.log('traversal count: ', traversed);
        return deletedValues;
    }

    printForward() {
        console.log("Printing Forward");
        for (let current = this.head.next; current != this.tail; current = current.next) {
            console.log(current.value);
        }
    }
    printBackward() {
        console.log("Printing Backward");
        for (let current = this.tail.prev; current != this.head; current = current.prev) {
            console.log(current.value);
        }
    }

}

const sList = new SentinalLinkedList(4,5,6);
sList.addToFront(1,3);
sList.addToBack(7, 9);
sList.insertBefore(3, 2);
sList.insertAfter(7, 8);
console.log("Removed nodes", sList.removeNodes(4, 5, 6));
sList.printForward();
sList.printBackward();