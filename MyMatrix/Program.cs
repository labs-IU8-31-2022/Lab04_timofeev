using Microsoft.VisualBasic;

class MyMatrix
{
    int[,] _matrix;
    private int _m;
    private int _n;

    public MyMatrix(int m, int n)
    {
        if (m == 0 || n == 0)
        {
            Console.WriteLine("Неверно задано кол-во столбцов/строк");
            return;
        }

        _m = m;
        _n = n;
        _matrix = new int[_m, _n];
    }

    private void RandomMatrix()
    {
        Random rand = new();
        int first = Convert.ToInt32(Console.ReadLine());
        int second = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < _matrix.GetLength(0); ++i)
        {
            for (int j = 0; j < _matrix.GetLength(1); ++j)
            {
                _matrix[i, j] = rand.Next(first, second);
            }
        }
    }

    public void Print()
    {
        for (int i = 0; i < _matrix.GetLength(0); ++i, Console.WriteLine())
        {
            for (int j = 0; j < _matrix.GetLength(1); ++j)
            {
                Console.WriteLine($"{this[i, j]}  ");
            }
        }
    }

    public int this[int indexM, int indexN]
    {
        get => _matrix[indexM, indexN];
        set => _matrix[indexM, indexN] = value;
    }

    public static MyMatrix operator +(MyMatrix matr1, MyMatrix matr2)
    {
        if (matr1._m != matr2._m || matr1._n != matr2._n)
        {
            throw new Exception("Не совпадает кол-во столбцов/строк");
        }

        MyMatrix res = new(matr1._m, matr1._n);
        for (int i = 0; i < matr1._matrix.GetLength(0); ++i)
        {
            for (int j = 0; j < matr1._matrix.GetLength(1); ++j)
            {
                res[i, j] = matr1[i, j] + matr2[i, j];
            }
        }

        return res;
    }

    public static MyMatrix operator -(MyMatrix matr1, MyMatrix matr2)
    {
        if (matr1._m != matr2._m || matr1._n != matr2._n)
        {
            throw new Exception("Не совпадает кол-во столбцов/строк");
        }

        MyMatrix res = new(matr1._m, matr1._n);
        for (int i = 0; i < matr1._matrix.GetLength(0); ++i)
        {
            for (int j = 0; j < matr1._matrix.GetLength(1); ++j)
            {
                res[i, j] = matr1[i, j] - matr2[i, j];
            }
        }

        return res;
    }

    public static MyMatrix operator *(MyMatrix matr1, MyMatrix matr2)
    {
        if (matr1._n != matr2._m)
        {
            throw new Exception("Не совпадает кол-во столбцов в первой матрице и кол-во строк во второй");
        }

        MyMatrix res = new(matr1._m, matr2._n);
        for (int i = 0; i < matr1._matrix.GetLength(0); ++i)
        {
            for (int j = 0; j < matr2._matrix.GetLength(1); ++j)
            {
                for (int k = 0; k < matr2._matrix.GetLength(0); ++k)
                {
                    res[i, j] += matr1[i, k] + matr2[k, j];
                }
            }
        }

        return res;
    }

    public static MyMatrix operator *(MyMatrix matr1, int num)
    {
        MyMatrix res = new(matr1._m, matr1._n);
        for (int i = 0; i < matr1._matrix.GetLength(0); ++i)
        {
            for (int j = 0; j < matr1._matrix.GetLength(1); ++j)
            {
                res[i, j] = matr1[i, j] * num;
            }
        }

        return res;
    }

    public static MyMatrix operator /(MyMatrix matr1, int num)
    {
        if (num == 0)
        {
            throw new Exception("Деление на ноль");
        }

        MyMatrix res = new(matr1._m, matr1._n);
        for (int i = 0; i < matr1._matrix.GetLength(0); ++i)
        {
            for (int j = 0; j < matr1._matrix.GetLength(1); ++j)
            {
                res[i, j] = matr1[i, j] / num;
            }
        }

        return res;
    }
}