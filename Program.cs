/*
Challenge 1. Given a jagged array of integers (two dimensions).
Find the common elements in the nested arrays.
Example: int[][] arr = { new int[] {1, 2}, new int[] {2, 1, 5}}
Expected result: int[] {1,2} since 1 and 2 are both available in sub arrays.
*/

int[] CommonItems(int[][] jaggedArray)
{
    var result = new List<int>();
    foreach (var item1 in jaggedArray[0])
    {
        foreach (var item2 in jaggedArray[1])
        {
            if(item1 == item2)
            {
                result.Add(item1);
            }
        }
    }
    return result.ToArray();
}
int[][] arr1 = { new int[] { 1, 2 }, new int[] { 2, 1, 5 } };
int[] arr1Common = CommonItems(arr1);
/* write method to print arr1Common */
Console.Write("Common items: {");
for (int i = 0; i < arr1Common.Length; i++)
{
	Console.Write("{0}", arr1Common[i]);
	if (i < arr1Common.Length - 1)
	{
		Console.Write(", ");
	}
}
Console.Write("}\n");


/* 
Challenge 2. Inverse the elements of a jagged array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[]{2, 1}, new int[]{3, 2, 1}}
*/
void InverseJagged(int[][] jaggedArray)
{
    for (int i = 0; i < jaggedArray.Length; i++)
    {
        Array.Reverse(jaggedArray[i]);
    }
}
int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
InverseJagged(arr2);
/* write method to print arr2 */
Console.Write("Reversed jagged array: {");
for (int i = 0; i < arr2.Length; i++)
{
    Console.Write("{");
	for (int j = 0; j < arr2[i].Length; j++)
	{
		Console.Write("{0}", arr2[i][j]);
		if (j < arr2[i].Length - 1)
		{
			Console.Write(", ");
		}
	}
    Console.Write("}");
	if (i < arr2.Length - 1)
	{
		Console.Write(", ");
	}
}
Console.Write("}\n");

/* 
Challenge 3.Find the difference between 2 consecutive elements of an array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[] {-1}, new int[]{-1, -1}}
 */
void CalculateDiff(int[][] jaggedArray)
{
    for (int i = 0; i < jaggedArray.Length; i++)
    {
        for (int j = 0; j < jaggedArray[i].Length - 1; j++)
        {
            jaggedArray[i][j] = jaggedArray[i][j] - jaggedArray[i][j + 1];
        }
        Array.Resize(ref jaggedArray[i], jaggedArray[i].Length - 1);
    }
}
int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
CalculateDiff(arr3);
/* write method to print arr3 */
Console.Write("Difference between 2 consecutive elements of an array: {");
for (int i = 0; i < arr3.Length; i++)
{
    Console.Write("{");
	for (int j = 0; j < arr3[i].Length; j++)
	{
		Console.Write("{0}", arr3[i][j]);
		if (j < arr3[i].Length - 1)
		{
			Console.Write(", ");
		}
	}
    Console.Write("}");
	if (i < arr3.Length - 1)
	{
		Console.Write(", ");
	}
}
Console.Write("}\n");


/* 
Challenge 4. Inverse column/row of a rectangular array.
For example, given: int[,] arr = {{1,2,3}, {4,5,6}}
Expected result: {{1,4},{2,5},{3,6}}
 */
int[,] InverseRec(int[,] recArray)
{
    int[,] resultArray = new int[recArray.GetLength(1), recArray.GetLength(0)];
    for (int i = 0; i < resultArray.GetLength(0); i++)
    {
        for (int j = 0; j < resultArray.GetLength(1); j++)
        {
            resultArray[i, j] = recArray[j, i];
        }
    }
    return resultArray;
}
int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
int[,] arr4Inverse = InverseRec(arr4);
/* write method to print arr4Inverse */
Console.Write("Inverse column/row of a rectangular array: {");
for (int i = 0; i < arr4Inverse.GetLength(0); i++)
{
    Console.Write("{");
    for (int j = 0; j < arr4Inverse.GetLength(1); j++)
    {
        Console.Write("{0}", arr4Inverse[i, j]);
        if (j < arr4Inverse.GetLength(1) - 1)
		{
			Console.Write(", ");
		}
    }
    Console.Write("}");
    if (i < arr4Inverse.GetLength(0) - 1)
	{
		Console.Write(", ");
	}
}
Console.Write("}\n");

/* 
Challenge 5. Write a function that accepts a variable number of params of any of these types: 
string, number. 
- For strings, join them in a sentence. 
- For numbers then sum them up. 
- Finally print everything out. 
Example: Demo("hello", 1, 2, "world") 
Expected result: hello world; 3 */
void Demo(params object[] input)
{
    int sum = 0;
    string sentence = "";
    foreach (var item in input)
    {
        if (item is string)
        {
            sentence += item + " ";
        }
        else if (item is int)
        {
            sum += (int) item;
        }
    }
    sentence = sentence.Trim();
    Console.WriteLine("{0}; {1}", sentence, sum);
}
Demo("hello", 1, 2, "world"); //should print out "hello world; 3"
Demo("My", 2, 3, "daughter", true, "is");//should print put "My daughter is; 5"


/* Challenge 6. Write a function to swap 2 objects but only if they are of the same type 
and if they’re string, lengths have to be more than 5. 
If they’re numbers, they have to be more than 18. */
void SwapTwo(object input1, object input2)
{
    Console.WriteLine("Original inputs: {0} & {1}", input1, input2);
    if (input1.GetType() != input2.GetType())
    {
        Console.WriteLine("Input objects are not the same type");
    }
    else if (input1 is string string1 && input2 is string string2) 
    {
        if (string1.Length < 5 || string2.Length < 5)
        {
            Console.WriteLine("Strings\' length should be more than 5");
        }
        else
        {
            string temp = string1;
            string1 = string2;
            string2 = temp;
            Console.WriteLine("Strings are now swapped: {0} & {1}", string1, string2);
        }
    }
    else if (input1 is int int1 && input2 is int int2)
    {
        if (int1 < 18 || int2 < 18)
        {
            Console.WriteLine("Numbers should be more than 18");
        }
        else 
        {
            int temp = int1;
            int1 = int2;
            int2 = temp;
            Console.WriteLine("Numbers are now swapped: {0} & {1}", int1, int2);
        }
    }
}
SwapTwo("hello", "world");
SwapTwo("test", "input");
SwapTwo(20, 30);
SwapTwo(10, 5);
SwapTwo("hello", 10);
/* Challenge 7. Write a function that does the guessing game. 
The function will think of a random integer number (lets say within 100) 
and ask the user to input a guess. 
It’ll repeat the asking until the user puts the correct answer. */
void GuessingGame()
{
    Random random = new Random();
    bool playing = true;
    int guess;
    int number;
    int tries;
    Console.WriteLine("Guess a number between 1 and 100: ");
    while (playing)
    {
        tries = 0;
        guess = 0;
        number = random.Next(1, 101);
        while (guess != number)
        {
            guess = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your guess: " + guess);
            if (guess < number)
            {
                Console.WriteLine("Your guess is too low");
            }
            else if (guess > number)
            {
                Console.WriteLine("Your guess is too high");
            }
            // guess = Convert.ToInt32(Console.ReadLine());
            tries++;
        }
        Console.WriteLine("Your guess is correct, the number is " + number);
        Console.WriteLine("You win in {0} tries", tries);
    }
}
GuessingGame();

/* Challenge 8. Provide class Product, OrderItem, Cart, which make a feature of a store
Complete the required features in OrderItem and Cart, so that the test codes are error-free */

var product1 = new Product(1, 30);
var product2 = new Product(2, 50);
var product3 = new Product(3, 40);
var product4 = new Product(4, 35);
var product5 = new Product(5, 75);

var orderItem1 = new OrderItem(product1, 2);
var orderItem2 = new OrderItem(product2, 1);
var orderItem3 = new OrderItem(product3, 3);
var orderItem4 = new OrderItem(product4, 2);
var orderItem5 = new OrderItem(product5, 5);
var orderItem6 = new OrderItem(product2, 2);

var cart = new Cart();
cart.AddToCart(orderItem1, orderItem2, orderItem3, orderItem4, orderItem5, orderItem6);

//get 1st item in cart
var firstItem = cart[0];
Console.WriteLine(firstItem);

//Get cart info
cart.GetCartInfo(out int totalPrice, out int totalQuantity);
Console.WriteLine("Total Quantity: {0}, Total Price: {1}", totalQuantity, totalPrice);

//get sub array from a range
var subCart = cart[1, 3];
// Console.WriteLine(subCart);
foreach (var item in subCart)
{
    Console.WriteLine(item);
}

class Product
{
    public int Id { get; set; }
    public int Price { get; set; }

    public Product(int id, int price)
    {
        this.Id = id;
        this.Price = price;
    }
}

class OrderItem : Product
{
    public int Quantity { get; set; }

    public OrderItem(Product product, int quantity) : base(product.Id, product.Price)
    {
        this.Quantity = quantity;
    }

    /* Override ToString() method so the item can be printed out conveniently with Id, Price, and Quantity */
    public override string ToString()
    {
        return $"Product id: {this.Id}, price: {this.Price}, quantity: {this.Quantity}";
    }
}

class Cart
{
    private List<OrderItem> _cart { get; set; } = new List<OrderItem>();

    /* Write indexer property to get nth item from _cart */
    public OrderItem this[int index]
    {
        get 
        {
            if (index >= 0 && index < _cart.Count)
            {
                return _cart[index];
            }
            else 
            {
                throw new IndexOutOfRangeException();
            }
        }
    }

    /* Write indexer property to get items of a range from _cart */
    public List<OrderItem> this[int start, int end]
    {
        get 
        {
            if (start >= 0 && end < _cart.Count)
            {
                int length = end - start + 1;
                return _cart.GetRange(start, length);
            }
            else 
            {
                throw new IndexOutOfRangeException();
            }
        }
    }

    public void AddToCart(params OrderItem[] items)
    {
        /* this method should check if each item exists --> increase value / or else, add item to cart */
        foreach (OrderItem item in items)
        {
            var existingItem = _cart.Find(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else 
            {
                _cart.Add(item);
            }
        }
    }
    /* Write another method called Index */
    public OrderItem Index(int index)
    {
        if (index >= 0 && index < _cart.Count)
        {
            return _cart[index];
        }
        else 
        {
            throw new IndexOutOfRangeException();
        }
    }

    /* Write another method called GetCartInfo(), which out put 2 values: 
    total price, total products in cart*/
    public void GetCartInfo(out int totalPrice, out int totalQuantity)
    {
        totalPrice = 0;
        totalQuantity = 0;
        for (int i = 0; i < _cart.Count; i++)
        {
            totalPrice += _cart[i].Price;
            totalQuantity += _cart[i].Quantity;
        }
    }

    /* Override ToString() method so Console.WriteLine(cart) can print
    id, unit price, unit quantity of each item*/
    public override string ToString()
    {
        string text = "";
        foreach (OrderItem item in _cart)
        {
            text += $"Item id: {item.Id}, price: {item.Price}, quantity: {item.Quantity}\n";
        }
        return text;
    }
}