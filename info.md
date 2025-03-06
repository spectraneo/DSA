# Big-O Notation Cheat Sheet

## 1️⃣ O(1) - Constant Time (Fastest)
- **Time does not change with input size.**
- Example: Accessing an array element by index.
```csharp
int firstElement = arr[0];
```
- ✅ **Best case scenario, but rare.**

---

## 2️⃣ O(log n) - Logarithmic Time
- **Each step reduces the problem size exponentially.**
- Example: **Binary Search**
```csharp
while (low <= high) {
    int mid = (low + high) / 2;
    if (arr[mid] == target) return mid;
    else if (arr[mid] < target) low = mid + 1;
    else high = mid - 1;
}
```
- **Why fast?** Cuts the problem size in **half** every step.
- **Common in:** Binary Search, Binary Trees, and Efficient Searching.

---

## 3️⃣ O(n) - Linear Time
- **Looping through all elements once.**
- Example: **Finding max in an array**
```csharp
int max = arr[0];
for (int i = 1; i < arr.Length; i++) {
    if (arr[i] > max) max = arr[i];
}
```
- **Why slower than O(log n)?** Every element is checked.

---

## 4️⃣ O(n log n) - Linearithmic Time
- **Better than O(n²), but worse than O(n).**
- Example: **Merge Sort, QuickSort**
```csharp
Array.Sort(arr); // Uses QuickSort (O(n log n))
```
- **Why log n part?** Sorting **divides** the problem into halves, and each half takes O(n) time.

---

## 5️⃣ O(n²) - Quadratic Time (Slow for Large n)
- **Nested loops → Each element interacts with every other element.**
- Example: **Bubble Sort**
```csharp
for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
        if (arr[j] > arr[j+1]) Swap(arr, j, j+1);
    }
}
```
- **Why slow?** If `n = 1000`, you do **1,000,000** operations.

---

## 6️⃣ O(2ⁿ) - Exponential Time (Very Slow)
- **Growth is **double** for every extra input.**
- Example: **Fibonacci Recursive Solution**
```csharp
int Fibonacci(int n) {
    if (n <= 1) return n;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
```
- **Why horrible?** If `n = 50`, the function takes **trillions** of steps.

---

## 7️⃣ O(n!) - Factorial Time (Worst Case)
- **Grows worse than exponential!**
- Example: **Traveling Salesman Problem (TSP)**
    - Checking all **permutations** of `n` cities to find the shortest path.
- **Why insane?** If `n = 20`, this is **2.4 quintillion operations** (unusable).

---

## 8️⃣ O(n³) - Cubic Time
- **Found in complex brute-force problems and matrix operations.**
- Example: **Floyd-Warshall Algorithm** (All-pairs shortest path in graphs).

---

## 9️⃣ O(√n) - Square Root Time
- **Used in optimized brute-force methods.**
- Example: **Checking if a number is prime (Trial division up to √n).**

---

## 🔟 O(log log n) - Double Logarithmic Time
- **Even faster than O(log n), used in advanced math-based algorithms.**
- Example: **Certain sieve algorithms for primes.**

---

## **Final Ranking (Fastest → Slowest)**  
✅ **Fast**  
- **O(1) → Constant**
- **O(log n) → Logarithmic**  
- **O(log log n) → Double Logarithmic**  

⚠️ **Moderate**  
- **O(n) → Linear**  
- **O(√n) → Square Root**  
- **O(n log n) → Linearithmic**  

⛔ **Slow**  
- **O(n²) → Quadratic**
- **O(n³) → Cubic**
- **O(2ⁿ) → Exponential**
- **O(n!) → Factorial (Worst)**  

---

## **Optimization Goal**
The **faster the complexity**, the better your program scales.  
Always try to **reduce O(n²) to O(n log n) or O(n)**.