# Grid Product Calculator

## Answers

1. How many different combinations are there of three adjacent numbers in the same
direction (up, down, left, right or diagonally) in the 10 x 10 grid?

**Answer: 574**

2. What is the greatest product of three adjacent numbers in the same direction (up,
down, left, right or diagonally) in the 10 x 10 grid?

**Answer: 667755**

## Solution outline

Adjacent integers can be in 8 directions:
- Up
- Down
- Left
- Right
- Diagonal Right Up
- Diagonal Right Down
- Diagonal Left Up
- Diagonal Left Down

Adjacent Integers are collected by 2 visitors:
- Product Visitor: calculates the maximum product of all the adjacent integers
- Distinct 3 Adjacent Integers: produces a distinct list of all 3 adjacent integers

A 'Grid' traverses the raw data and provides a window of adjacent integers at each step

## Code Structure:

- GridProductCalculator: implements IGridProductCalculator and is the main entry point. It combines the grid and visitors to answer test questions
- GridProductCalculatorTest: The first 2 tests are set-up to answer the test questions
	
## Know Limitations/Areas of improvement
- No logging 
- All processing happens on a single thread. The traversal of the grid can be done in multiple threads however it would require the visitors to be updated to be thread safe
- Distinct3AdjacentGridVisitor assumes the adjacent integers count will be 3. This could be extended to accept n adjacent integers however this wasn't a requirement so left for now.

## Original Solution
My original solution was to have the adjacent integers defined as enumerators so that you could use LINQ to compose the queries and PLINQ to run in parallel. When testing this with a 10000 * 10000 grid I noticed the memory usage just kept increasing so decided to take an alternative approach (i.e. the current approach). If I were to spend more time on this I would have explored this approach more because I like the fact you can compose complex queries in a clear concise way:

### Product of numbers

```csharp

var maximumProduct = new UpAdjacentGridIntegers(numberOfAdjacentIntegers)
		    .Concat(new RightAdjacentGridIntegers(numberOfAdjacentIntegers))
		    .Concat(new RightUpAdjacentGridIntegers(numberOfAdjacentIntegers))
		    .Concat(new RightDownAdjacentGridIntegers(numberOfAdjacentIntegers))
                    .AsParallel()
                    .Select(Product)
                    .Max();
		    
// where Product is something like
private static long Product(int[] adjacentIntegers)
{
    long product = 1;
    foreach (var value in adjacentIntegers)
    {
	product *= value;
    }

    return product;
}
```



### Distinct 3

```csharp

var distinctCount = new UpAdjacentGridIntegers(numberOfAdjacentIntegers)
		    .Concat(new DownAdjacentGridIntegers(numberOfAdjacentIntegers))
		    .Concat(new LeftAdjacentGridIntegers(numberOfAdjacentIntegers))
		    .Concat(new RightAdjacentGridIntegers(numberOfAdjacentIntegers))
		    .Concat(new RightUpAdjacentGridIntegers(numberOfAdjacentIntegers))
		    .Concat(new RightDownAdjacentGridIntegers(numberOfAdjacentIntegers))
		    .Concat(new LeftUpAdjacentGridIntegers(numberOfAdjacentIntegers))
		    .Concat(new LeftDownAdjacentGridIntegers(numberOfAdjacentIntegers))
                    .AsParallel()
                    .Select(a => new { Value1 = a[0], Value2 = a[1], Value3 = a[2] })
                    .Distinct()
                    .Count();
```

		    
		    
		    


