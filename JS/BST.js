class Node {
    constructor(value) {
        this.right = null;
        this.value = value;
        this.left = null;
    }
}

class BST {
    constructor() {
        this.root = null;
        this.level = 0;        
    }

    #addNode(node, value) {
        if (node == null) {
            return new Node(value);
        }

        if (value > node.value) {
            node.right = this.#addNode(node.right, value);
        } else {
            node.left = this.#addNode(node.left, value);
        }
        return node;
    }

    add(value) {
        this.root = this.#addNode(this.root, value);
    }

    #printNode(node) {
        if (node) {
            this.#printNode(node.left);
            console.log(node.value);
            this.#printNode(node.right);
        }
    }

    //~ To PRINT SORTED order of tree nodes
    #inOrder(node) {
        if (!node) return;
        this.#inOrder(node.left);
        console.log(node.value);
        this.#inOrder(node.right);
    }

    //~ To SAVE tree and load back in same order
    #preOrder(node) {
        if (!node) return;
        console.log(node.value);
        this.#preOrder(node.left);
        this.#preOrder(node.right);
    }

    //~ To DELETE tree 
    #postOrder(node) {
        if (!node) return;
        this.#postOrder(node.left);
        this.#postOrder(node.right);
        console.log(node.value);
    }

    #printInternal(node) {
        if (!node) return;
        this.level++;
        this.#printInternal(node.right);
        console.log(" ".repeat(this.level * 4), node.value);
        this.#printInternal(node.left);
        this.level--;        
    }

    printInOrder() {
        this.#inOrder(this.root);
    }

    printPostOrder() {
        this.#postOrder(this.root);
    }

    printPreOrder() {
        this.#preOrder(this.root);
    }

    print() {
        this.#printNode();
    }
    
    printTree() {
        this.#printInternal(this.root);
    }

    #saveTreeInternal(node, localStore) {
        if (!node) return;    
        localStore.push(node.value);
        this.#saveTreeInternal(node.left, localStore);
        this.#saveTreeInternal(node.right, localStore);
    }

    saveTree() {
        const localStore = [];
        this.#saveTreeInternal(this.root, localStore);
        return localStore;
    }

    #removeInternal(node) {
        if (!node) return;
        this.#removeInternal(node.left);
        this.#removeInternal(node.right);
        node.right = null;
        node.left = null;        
    }

    removeTree() {
        this.#removeInternal(this.root);
        this.root = null;
    }

    #removeNode(node, value) {
        if (node == null) return null;
        if (value > node.value) {
            node.right = this.#removeNode(node.right, value);
        } else if (value < node.value) {
            node.left = this.#removeNode(node.left, value);
        }
        else {
            if (node.left == null && node.right == null) {
                return null;
            }
            if (node.left != null && node.right == null) {
                return node.left;
            }
            if (node.left == null && node.right != null) {
                return node.right;
            } 

            //% Find the predecessor - Step left once, and go right, right
            //~ Find the successor - Step right once, and go left, left
            let successor = node.right; 
            while (successor.left != null)
                successor = successor.left;
            node.value = successor.value;
            node.right = this.#removeNode(node.right, successor.value);
        }
        return node;
    }

    remove(value) {
        this.root = this.#removeNode(this.root, value);
    }
}

const bst = new BST();
bst.add(400);
bst.add(100);
bst.add(50);
bst.add(75);
bst.add(80);
bst.add(30);
bst.add(25);
bst.add(450);
bst.add(420);
bst.add(430);
bst.add(500);

bst.printTree();

// console.log("In Order");
// bst.printInOrder();
// console.log("Pre Order");
// bst.printPreOrder();
// console.log("Post Order");
// bst.printPostOrder();

// const treeValues = bst.saveTree();

// bst.removeTree();

// console.log("After Delete");

// bst.printTree();

// treeValues.forEach(v => bst.add(v));

// console.log("Recreated");

// bst.printTree();

console.log("Delete")

bst.remove(400);

bst.printTree();

