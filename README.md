# Grid Product Calculator

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
