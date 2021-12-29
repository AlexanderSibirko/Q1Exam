void OutputMessage(string Message) //метод выдачи сообщений от метода (для консольного варианта исполнения)
{
    Console.WriteLine(Message);
}

int RandomMinMax(int minValue, int maxValue)
{
    return new Random().Next(minValue, maxValue);
}

int[] RandomArray(int elementCount, int minValue, int maxValue)
{
    int[] resultArray = new int[elementCount];
    for (int i = 0; i < elementCount; i++)
    {
        resultArray[i] = RandomMinMax(minValue,maxValue);
    }
    return resultArray;
}

int[] CreatingArray()
{
    OutputMessage($"Вводите исходные целые числа (от {int.MinValue} до {int.MaxValue}) по одному, когда введёте все числа напишите команду \"End\" или напишите \"Random\" для случайной генерации");
    int[] resultArray = new int[10];
    int i = 0;
    while (true) //запрашиваем числа по одному
    {
        string UserString = string.Empty;
        UserString = Console.ReadLine();
        if (UserString.ToLower() == "end") break;
        
        if (UserString.ToLower() == "random") 
        {
            int elementCount = RandomMinMax(5,10);
            int minElementValue = RandomMinMax(-100,0);
            int maxElementValue = RandomMinMax(0,100);
            Array.Resize(ref resultArray, elementCount);
            resultArray = RandomArray(elementCount,minElementValue,maxElementValue); 
            return resultArray;
        }
        
        if (int.TryParse(UserString, out int num))
        {
            resultArray[i] = num;
            i++;
            if (i == resultArray.Length) Array.Resize(ref resultArray, i + 10);
        }
        else
        {
            OutputMessage("Вы ввели не целое число или оно слишком большое");
        }
    }
    Array.Resize(ref resultArray, i);
    return resultArray;
}

int[] LeveOnlyEvenNumbersInArray(int[] numbersArray)
{
    int arrayLen = numbersArray.Length;
    int[] resultArray = new int[arrayLen];
    int j = 0;
    if (numbersArray != null || arrayLen != 0)
    {
        for (int i = 0; i < arrayLen; i++)
        {
            if (numbersArray[i] % 2 == 0)
            {
                resultArray[j] = numbersArray[i];
                j++;
            }
        }
    }
    Array.Resize(ref resultArray, j);
    return resultArray;
}

int[] numbersArray = CreatingArray();

//проверка результатов
OutputMessage(string.Join(',',numbersArray)); //отображаем исходный массив
OutputMessage(string.Join(',',LeveOnlyEvenNumbersInArray(numbersArray))); //отображаем получившийся массив


// Тестовые модули
RunTests();

void RunTests()
{
    Test1();
    Test2();
    Test3();
    Test4();
}

void Test1()
{
    int[] numArray = new int[] { 1, 2, 3, 4 };
    int[] expectedArray = new int[] { 2, 4 };
    int[] resultArray = LeveOnlyEvenNumbersInArray(numArray);

    for (int i = 0; i < expectedArray.Length; i++)
    {
        if (expectedArray[i] != resultArray[i])
        {
            OutputMessage("not passed Test1");
            return;
        }
    }
    OutputMessage("passed Test1");
}

void Test2()
{
    int[] numArray = new int[] { 1, 3, 4, 5,7, 1, 3};
    int[] expectedArray = new int[] { 4 };
    int[] resultArray = LeveOnlyEvenNumbersInArray(numArray);

    for (int i = 0; i < expectedArray.Length; i++)
    {
        if (expectedArray[i] != resultArray[i])
        {
            OutputMessage("not passed Test2");
            return;
        }
    }
    OutputMessage("passed Test2");
}

void Test3()
{
    int[] numArray = new int[] { 2, -4, 6};
    int[] expectedArray = new int[] { 2, -4, 6 };
    int[] resultArray = LeveOnlyEvenNumbersInArray(numArray);

    for (int i = 0; i < expectedArray.Length; i++)
    {
        if (expectedArray[i] != resultArray[i])
        {
            OutputMessage("not passed Test3");
            return;
        }
    }
    OutputMessage("passed Test3");
}

void Test4()
{
    int[] numArray = new int[] { 1, 3, 7 };
    int[] expectedArray = new int[] {};
    int[] resultArray = LeveOnlyEvenNumbersInArray(numArray);

    for (int i = 0; i < expectedArray.Length; i++)
    {
        if (expectedArray[i] != resultArray[i])
        {
            OutputMessage("not passed Test4");
            return;
        }
    }
    OutputMessage("passed Test4");
}