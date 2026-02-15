//*****************************************************************************
//** 77. Combinations                                               leetcode **
//*****************************************************************************
//** From one to n we choose with careful sight,
//** k deep we build each branch in ordered light;
//** We prune the tree when leaves grow thin and small,
//** Till everything blooms with every set, we catch them all.
//*****************************************************************************
/**
 * Return an array of arrays of size *returnSize.
 * The sizes of the arrays are returned as *returnColumnSizes array.
 * Note: Both returned array and *columnSizes array must be malloced, assume caller calls free().
 */
static void backtrack(
    int n,
    int k,
    int start,
    int depth,
    int* current,
    int** result,
    int* returnSize
)
{
    int i;
    int remaining_needed;

    if (depth == k)
    {
        result[*returnSize] = (int*)malloc(sizeof(int) * k);

        for (i = 0; i < k; i++)
        {
            result[*returnSize][i] = current[i];
        }

        (*returnSize)++;
        return;
    }

    remaining_needed = k - depth;

    for (i = start; i <= n - remaining_needed + 1; i++)
    {
        current[depth] = i;
        backtrack(n, k, i + 1, depth + 1, current, result, returnSize);
    }
}

int** combine(int n, int k, int* returnSize, int** returnColumnSizes)
{
    int** retval;
    int* current;
    int maxComb;
    int i;

    *returnSize = 0;

    /* Maximum combinations when n <= 20 is C(20,10) = 184756 */
    maxComb = 184756;

    retval = (int**)malloc(sizeof(int*) * maxComb);
    current = (int*)malloc(sizeof(int) * k);

    backtrack(n, k, 1, 0, current, retval, returnSize);

    *returnColumnSizes = (int*)malloc(sizeof(int) * (*returnSize));

    for (i = 0; i < *returnSize; i++)
    {
        (*returnColumnSizes)[i] = k;
    }

    free(current);

    return retval;
}