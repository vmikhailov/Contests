# Segment Tree Query Method Explanation

## Overview

The `Query` method in the segment tree implementation retrieves the sum of elements in a given range `[l, r]` efficiently in O(log n) time.

## The Code

```csharp
private int Query(int v, int tl, int tr, int l, int r)
{
    _queriesCount++;
    if (l > r)
    {
        return 0;
    }

    if (l == tl && r == tr)
    {
        return _tree[v];
    }

    var tm = (tl + tr) / 2;

    return Query(v * 2, tl, tm, l, Math.Min(r, tm))
           + Query(v * 2 + 1, tm + 1, tr, Math.Max(l, tm + 1), r);
}
```

## Parameters

- `v` - Current node index in the segment tree
- `tl`, `tr` - The range `[tl, tr]` that node `v` represents
- `l`, `r` - The query range `[l, r]` we want to sum

## How It Works

### Base Cases

1. **Empty range**: `if (l > r)` returns 0
   - This happens when the query range doesn't overlap with a subtree
   
2. **Perfect match**: `if (l == tl && r == tr)` returns `_tree[v]`
   - The query range exactly matches the node's range
   - Return the precomputed sum stored in this node

### Recursive Case

When the query range partially overlaps with the current node's range:

```csharp
var tm = (tl + tr) / 2;

return Query(v * 2, tl, tm, l, Math.Min(r, tm))
       + Query(v * 2 + 1, tm + 1, tr, Math.Max(l, tm + 1), r);
```

The node's range `[tl, tr]` is split at the midpoint `tm`:
- **Left child**: covers `[tl, tm]`
- **Right child**: covers `[tm + 1, tr]`

## Why Math.Min and Math.Max?

### Left Subtree: `Query(v * 2, tl, tm, l, Math.Min(r, tm))`

**Purpose**: Query the left child with the portion of `[l, r]` that overlaps `[tl, tm]`

- `Math.Min(r, tm)` ensures we don't query beyond the left subtree's range
- Examples:
  - If query range is `[2, 8]` and tm = 5: query left with `[2, min(8,5)] = [2, 5]`
  - If query range is `[2, 3]` and tm = 5: query left with `[2, min(3,5)] = [2, 3]`

### Right Subtree: `Query(v * 2 + 1, tm + 1, tr, Math.Max(l, tm + 1), r)`

**Purpose**: Query the right child with the portion of `[l, r]` that overlaps `[tm+1, tr]`

- `Math.Max(l, tm + 1)` ensures we don't query before the right subtree starts
- Examples:
  - If query range is `[2, 8]` and tm = 5: query right with `[max(2,6), 8] = [6, 8]`
  - If query range is `[7, 9]` and tm = 5: query right with `[max(7,6), 9] = [7, 9]`

## Visual Example

Given array: `[1, 2, 3, 4, 5, 6, 7, 8]`, query range `[2, 6]` (0-indexed, so elements 3,4,5,6,7)

```
Tree structure:
                    [0,7]=36
                    /      \
            [0,3]=10        [4,7]=26
            /    \          /     \
        [0,1]=3 [2,3]=7  [4,5]=11 [6,7]=15
        /  \    /  \     /  \     /   \
      [0] [1] [2] [3] [4] [5]  [6]  [7]
       1   2   3   4   5   6    7    8
```

**Query execution for [2, 6]:**

1. Start at root `[0,7]`, tm=3
   - Left: `Query([0,3], 2, min(6,3))` = `Query([0,3], 2, 3)`
   - Right: `Query([4,7], max(2,4), 6)` = `Query([4,7], 4, 6)`

2. Left subtree `[0,3]`, query `[2,3]`, tm=1
   - Left: `Query([0,1], 2, min(3,1))` = `Query([0,1], 2, 1)` → returns 0 (l > r)
   - Right: `Query([2,3], max(2,2), 3)` = `Query([2,3], 2, 3)` → exact match, returns 7

3. Right subtree `[4,7]`, query `[4,6]`, tm=5
   - Left: `Query([4,5], 4, min(6,5))` = `Query([4,5], 4, 5)` → exact match, returns 11
   - Right: `Query([6,7], max(4,6), 6)` = `Query([6,7], 6, 6)`, tm=6
     - Left: `Query([6,6], 6, 6)` → exact match, returns 7
     - Right: empty range, returns 0

**Final result**: 0 + 7 + 11 + 7 + 0 = 25 ✓ (sum of 3+4+5+6+7)

## Key Insight

The `Math.Min` and `Math.Max` operations **automatically clip** the query range to fit within each subtree's boundaries, avoiding the need for explicit conditional checks. This makes the code more concise but potentially less obvious.

Both approaches (with Math.Min/Max or with explicit if-else) have the same O(log n) complexity, but the explicit version can be slightly more efficient as it avoids unnecessary recursive calls when the query range is entirely in one subtree.

## Alternative: Explicit Conditionals

The same logic can be written without Math.Min/Max:

```csharp
if (r <= tm)
{
    // Entire query range is in left subtree
    return Query(v * 2, tl, tm, l, r);
}
else if (l > tm)
{
    // Entire query range is in right subtree
    return Query(v * 2 + 1, tm + 1, tr, l, r);
}
else
{
    // Query range spans both subtrees
    return Query(v * 2, tl, tm, l, tm)
           + Query(v * 2 + 1, tm + 1, tr, tm + 1, r);
}
```

This version is more explicit and slightly more efficient (avoids recursive calls when range is in one subtree), but mathematically equivalent to the Math.Min/Max version.

