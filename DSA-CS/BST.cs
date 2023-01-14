class Node<T> where T : IComparable
{
    public Node<T> left { get; set; }
    public Node<T> right { get; set; }
    public T value { get; set; }
    public Node(T value, Node<T> right = null, Node<T> left = null)
    {
        this.value = value;
        this.right = right;
        this.left = left;
    }
}

class BST<T> where T : IComparable {
    private Node<T> root;
    private int level;
    public BST() {
        this.root = null;
        this.level = 0;        
    }

    private Node<T> addNode(Node<T> node, T value) {
        if (node == null) {
            return new Node<T>(value);
        }

        if (value.CompareTo(node.value) > 0 ) {
            node.right = addNode(node.right, value);
        } else {
            node.left = addNode(node.left, value);
        }
        return node;
    }

    public void add(T value) {
        this.root = addNode(this.root, value);
    }

    private void printNode(Node<T> node) {
        if (null != node ) {
            this.printNode(node.left);
            Console.WriteLine(node.value);
            this.printNode(node.right);
        }
    }

    //~ To PRINT SORTED order of tree nodes
    private void inOrder(Node<T> node) {
        if (null == node) return;
        inOrder(node.left);
        Console.WriteLine(node.value);
        inOrder(node.right);
    }

    //~ To SAVE tree and load back in same order
    private void preOrder(Node<T> node) {
        if (null == node) return;
        Console.WriteLine(node.value);
        preOrder(node.left);
        preOrder(node.right);
    }

    //~ To DELETE tree 
    private void postOrder(Node<T> node) {
        if (null == node) return;
        postOrder(node.left);
        postOrder(node.right);
        Console.WriteLine(node.value);
    }

    private void printInternal(Node<T> node) {
        if (null == node) return;
        level++;
        printInternal(node.right);
        Console.WriteLine(new string(' ', level*4), node.value);
        printInternal(node.left);
        level--;        
    }

    public void printInOrder() {
        inOrder(this.root);
    }

    public void printPostOrder() {
        postOrder(this.root);
    }

    public void printPreOrder() {
        preOrder(this.root);
    }

    public void print() {
        printNode(this.root);
    }
    
    public void printTree() {
        printInternal(root);
    }

    private void saveTreeInternal(Node<T> node, IList<T> localStore) {
        if (null == node) return;    
        localStore.Add(node.value);
        saveTreeInternal(node.left, localStore);
        saveTreeInternal(node.right, localStore);
    }

    public IList<T> saveTree() {
        var localStore = new List<T>();
        this.saveTreeInternal(this.root, localStore);
        return localStore;
    }

    private void removeInternal(Node<T> node) {
        if (null == node) return;
        removeInternal(node.left);
        removeInternal(node.right);
        node.right = null;
        node.left = null;        
    }

    public void removeTree() {
        this.removeInternal(this.root);
        this.root = null;
    }

    public Node<T> removeNode(Node<T> node, T value) {
        if (node == null) return null;
        if (value.CompareTo(node.value) > 0) {
            node.right = this.removeNode(node.right, value);
        } else if (value.CompareTo(node.value) < 0 ) {
            node.left = this.removeNode(node.left, value);
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
            var successor = node.right; 
            while (successor.left != null)
                successor = successor.left;
            node.value = successor.value;
            node.right = this.removeNode(node.right, successor.value);
        }
        return node;
    }

    public void remove(T value) {
        this.root = this.removeNode(this.root, value);
    }
}