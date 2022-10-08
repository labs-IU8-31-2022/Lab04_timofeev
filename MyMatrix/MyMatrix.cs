MyMatrix m1 = new(3, 5);
MyMatrix m2 = new(3, 5);
MyMatrix m3 = new(2, 2);
MyMatrix m6 = new(5, 7);
m1.Print();
m2.Print();
m3.Print();
try
{
    var m4 = m1 + m2;
    m4.Print();
    m4 *= 2;
    m4.Print();
    m4 /= 2;
    m4.Print();
    var m5 = m1 - m2;
    m5.Print();
    var m7 = m1 * m6;
    m7.Print();
    var m8 = m1 * m2;
    m8.Print();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

class MyMatrix
{
    int[,] _matrix;
    private int _m;
    private int _n;
    private static int beginning;
    private static int ending;

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
        RandomMatrix();
    }

    private void RandomMatrix()
    {
        Random rand = new();
        if (beginning == 0 && ending == 0)
        {
            Console.WriteLine("Введите диапазон генерации чисел");
            beginning = Convert.ToInt32(Console.ReadLine());
            ending = Convert.ToInt32(Console.ReadLine());
        }

        for (int i = 0; i < _matrix.GetLength(0); ++i)
        {
            for (int j = 0; j < _matrix.GetLength(1); ++j)
            {
                _matrix[i, j] = rand.Next(beginning, ending);
            }
        }
    }

    public void Print()
    {
        for (int i = 0; i < _matrix.GetLength(0); ++i, Console.WriteLine())
        {
            for (int j = 0; j < _matrix.GetLength(1); ++j)
            {
                Console.Write("{0,3}", this[i, j]);
            }
        }
        Console.WriteLine();
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