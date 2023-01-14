function factorial(n) {
    console.log(`value of n : ${n}`);
    if (n <= 1)
        return n;
    return n * factorial(n - 1);
}

console.log(factorial(5));