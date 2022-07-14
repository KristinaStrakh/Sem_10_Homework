/*Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
так чтобы в одной группе все числа в группе друг на друга не делились? Найдите M при заданном N и 
получите одно из разбиений на группы N ≤ 10²⁰.
Например, для N = 50, M получается 6*/


int n = 50;
decimal[] number = new decimal[n];
OutputNumbersUpToN(number);
int countGroup = 1;

for (int i = 0; i < number.Length; i++) 
{

    if (number[i] != 0)
    {
        int index = 0;
        decimal[] num2 = new decimal[number.Length];
        for (int k = i; k < number.Length; k++) // проверяем, что не делиться на первое число. записываем в массив
        {
            if (number[k] % number[i] != 0 || number[k] / number[i] == 1) 
            {
                num2[index] = number[k];
                index++;
        
            }

        }
        for (int j = 1; j < num2.Length; j++)
        {
            for (int l = j + 1; l < num2.Length; l++)
            {
        
                if (num2[j] != 0 && num2[l] % num2[j] == 0) //проверяем в получившемся массиве, чтобы числа между собой не делились нацело и обнуляем цифру, кот. делится нацело
                {
                    num2[l] = 0;
                }
            }
        }
        for (int f = 0; f < number.Length; f++)
        {
            for (int m = 0; m < num2.Length; m++)
            {
                if (num2[m] == number[f]) // обнуляем из основного массива то, что записали в новый
                {
                    number[f] = 0;
                }
            }

        }
        Console.Write($"группа {countGroup++}: ");
        for (int k = 0; k < num2.Length; k++)
        {
            if (num2[k] != 0) // распечатываем не нулевые значения
            {
                Console.Write(num2[k] + " ");
            }
        }
        Console.WriteLine();
    }

}

void OutputNumbersUpToN(decimal[] a)
{
    for (int i = 0; i < a.Length; i++)
    {
        a[i] = i + 1;
    }
}
