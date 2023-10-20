using Microsoft.Win32;

namespace L2___Lesson_11___LINQ_and_Lambda
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region TASKS
            //TASK 1
            //List<int> namberiai = new List<int>();
            //namberiai.Add(4); namberiai.Add(-8); namberiai.Add(15); namberiai.Add(-23); namberiai.Add(42);
            //var namberiaiLINQ = namberiai.Select(number => number * number);
            ////Console.WriteLine($"TASK1: {namberiaiLINQ.Select(dalykas => dalykas.ToString)}");
            ////words.ToList().ForEach(word => Console.WriteLine(word));
            //Console.WriteLine("Task 1: ");
            //namberiaiLINQ.ToList().ForEach(word => Console.WriteLine(word)); //paverciam i lista ir tada kiekviena elementa spausdinam atskirai


            ////TASK 2
            //var namberiaiOnlyPositive = namberiai.Where(number => number > 0).ToList();//kam konvertuoti i lista?
            //Console.WriteLine("Task 2: ");
            //namberiaiOnlyPositive.ToList().ForEach(word => Console.WriteLine(word));

            ////TASK 3
            //var namberiaiOnlyPositiveSmallerT10 = namberiai.Where((number) => number > 0 && number < 10);
            //Console.WriteLine("Task 3: ");
            //namberiaiOnlyPositiveSmallerT10.ToList().ForEach(word => Console.WriteLine(word));

            ////TASK 4 
            //var namberiaiOrderedAscend = namberiai.OrderBy(number => number).ToList();//kam konvertuoti i lista?
            //var namberiaiOrderedDescend = namberiai.OrderByDescending(number => number).ToList();//kam konvertuoti i lista?
            //Console.WriteLine("Task 4: ");
            //namberiaiOrderedAscend.ToList().ForEach(word => Console.WriteLine(word));
            //namberiaiOrderedDescend.ToList().ForEach(word => Console.WriteLine(word));

            ////TASK 5
            //int largestNumber = namberiai.Max();
            //Console.WriteLine("The largest number is: " + largestNumber);


            //TASK 6
            List<Person> ppls = new List<Person>();
            ppls.Add(new Person("Goku", 45));
            ppls.Add(new Person("Vegeta", 48));
            ppls.Add(new Person("Gohan", 20));
            ppls.Add(new Person("Piccolo", 35));
            ppls.Add(new Person("Goten", 10));
            ppls.Add(new Person("Trunks", 11));
            ppls.Add(new Person("Krillin", 40));
            ppls.Add(new Person("Bulma", 38));
            ppls.Add(new Person("Chi-Chi", 43));
            ppls.Add(new Person("Majin Buu", 5));
            ppls.Add(new Person("Dende", 16));
            ppls.Add(new Person("Mr. Satan", 42));
            ppls.Add(new Person("Tien", 35));
            ppls.Add(new Person("Yamcha", 41));
            ppls.Add(new Person("Chiaotzu", 34));
            ppls.Add(new Person("Videl", 19));
            ppls.Add(new Person("Android 18", 31));
            ppls.Add(new Person("Android 17", 32));
            ppls.Add(new Person("Master Roshi", 300));
            ppls.Add(new Person("Korin", 800));

            var namesOnly = ppls.Select(person => person.Name);
            namesOnly.ToList().ForEach(word => Console.WriteLine(word));

            var agesOnly = ppls.Select(person => person.Age);// age list

            agesOnly = agesOnly.OrderByDescending(word => word).ToList();//pati ji keiciam


            //var agesOnlySorted = agesOnly.OrderByDescending(word => word).ToList(); //priskiriame kintamajam 


            agesOnly.ToList().ForEach(word => Console.WriteLine(word));
            Console.WriteLine(" -------- Sorted list: --------");
            //agesOnlySorted.ToList().ForEach(word => Console.WriteLine(word));

            var peopleOlderthan40SortedByName = ppls.Where(person => person.Age > 40).OrderBy(person => person.Name).ToList();
            peopleOlderthan40SortedByName.ForEach(person => Console.WriteLine($"{person.Name},{person.Age}"));


            #endregion

            Console.WriteLine("================================================================================");

            #region THEORY


            Func<int, int> multiplyByfive = (num) => num * 5;
            //fukncija<tipas, tipas> kintamojoPavadinimas = (parametras kuri paima yra integeris) => returnina integeri
            //Func priima du generic tipus (pirma paima, kita paduoda) (kas paskutinis tipas, ta RETURN)


            int result = multiplyByfive(7);
            Console.WriteLine(result);
            //simple one liners
            Func<int, int> multiplyByfive3 = (num) => num * 5;
            Func<int, int, int> multiply2 = (int num1, int num2) => num1 * num2;

            //-------------

            Func<int, int> multiplyByfive2 = (num) =>
            {
                return num * 5;
            };




            Func<int, int, int> multiply = (int num1, int num2) =>
            {
                Console.WriteLine($"printing {num1} by {num2}");
                return num1 * num2;
            };


            Console.WriteLine(multiply(3, 7));

            Func<bool, string, DateTime, decimal> differentParameterTypesFunc = (arg1, arg2, arg3) =>
            {
                Console.WriteLine(arg1);
                Console.WriteLine(arg2);
                Console.WriteLine(arg3);
                return 1.78m;
            };

            Console.WriteLine(differentParameterTypesFunc(false, "stringai", DateTime.Now));


            //grazina viena, bet nieko nepriima
            Func<string> funcWithoutParameters = () =>
            {
                return "return from func with no parameters";
            };
            Console.WriteLine(funcWithoutParameters());

            //IF lambda
            Func<int, bool> isIntHigherThan10 = (number) => number > 10;
            int numberToCheck = 11;

            if (isIntHigherThan10(numberToCheck))
            {
                Console.WriteLine("higher than 10");
            }
            else
            {
                Console.WriteLine("lower than 10");
            }



            Func<int, int, int> filterNumber = (number1, number2) =>
            {
                if (number1 > number2)
                {
                    return number1;
                }
                else
                {
                    return number2;
                }

            };

            Console.WriteLine(filterNumber(5, 15));


            //ELVIS operator - lambda if
            Func<int, int, int> filterNumberBetter = (number1, number2) => number1 > number2 ? number1 : number2;

            //kas uz klaustuko - ieinam i IFa
            //kas uz : ELSE

            // ====================================================== LINQ  ====================================================== 
            //duoti masyva, kazka pasidaryti su juo. prafiltravimui/modifikavimui
            Func<string, string> selector = (str) => str.ToUpper();
            string[] words = new string[] { "orange", "apple", "Article", "elephant" };

            List<string> upperWords = new List<string>();
            foreach (string word in words)
            {
                upperWords.Add(selector(word));
            }


            var upperWordsWithLinq = words.Select(selector);
            //foreachina per kiekviena elementa ir daro Func operacija(selector)

            var upperWordsWithLinq2 = words.Select((str) => str.ToUpper());//imame/selectinam kiekviena zodi, UpperCasinam ji
                                                                           //Func<string,string>

            //IEnumerable yra kazkas panasaus i lista


            var wordsLenghts = words.Select(word => word.Length);//kiekvieno zodzio ilgis//Func<string,int>
            var areWordsLongerthan5 = words.Select((word) => word.Length > 5);


            //Where
            var wordsLongerthanFive = words.Where(str => str.Length > 5);

            //OrderBy
            var orderedWords = words.OrderBy(word => word); //rikiuojam pagal ji pati - pagal abecele
            var orderedWordsByLength = words.OrderBy(word => word.Length); //rikiojam pagal ilgi

            //single or default
            var singleOrDefaultWordwith8Symbols = words.SingleOrDefault(word => word.Length == 8); //- gauname VIENA elementa pagal salyga,
                                                                                                   //negali buti daugiau, kitaip  - error
                                                                                                   //jeigu nera tokio  - null

            //single
            var singleWordwith8Symbols = words.SingleOrDefault(word => word.Length == 8);//cia jei nebus nei vieno arba keli, tai bus ERROR, o ne null


            //count
            var wordsCount = words.Count();//suskaiciuojam kiek elementu yra
            var wordsCountlongerthan5 = words.Count(word => word.Length > 5);//skaicuojama kiek elementu yra 5 raidziu dydzio

            //ForEach
            //sitas galioja tik listams, ne masyvam. Voidinis. nieko nereturn.
            //masyva konvertuojam i list su (ToList())
            words.ToList().ForEach(word => Console.WriteLine(word));

            #endregion
            //end of main
        }

    }
}