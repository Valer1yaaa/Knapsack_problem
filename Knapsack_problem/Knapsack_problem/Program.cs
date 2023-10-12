class Program
{
    static int Knapsack(int[] weight, int[] value, int capacity)
    {
        int n = weight.Length;
        int[,] dp = new int[n + 1, capacity + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= capacity; j++)
            {
                if (weight[i - 1] <= j)
                {
                    dp[i, j] = Math.Max(value[i - 1] + dp[i - 1, j - weight[i - 1]], dp[i - 1, j]);
                }
                else
                {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }
        return dp[n, capacity];
    }
    static void Main()
    {
        Console.WriteLine("Enter the weights of the items: ");
        int[] weight = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        Console.WriteLine("Enter the values of the items: ");
        int[] value = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        Console.WriteLine("Enter the capacity of the knapsack: ");
        int capacity = int.Parse(Console.ReadLine());

        int max_value = Knapsack(weight, value, capacity);
        Console.WriteLine("Maximum value of items in a Knapsack: " + max_value);
    }
}