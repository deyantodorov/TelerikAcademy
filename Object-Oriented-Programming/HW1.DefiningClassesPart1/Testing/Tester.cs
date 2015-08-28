namespace Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MobilePhone;

    /// <summary>
    /// All tasks:
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/01.%20Defining%20Classes%20-%20Part%201/README.md
    /// </summary>
    public class Tester
    {
        private static void Main()
        {
            // Gsm and other class test
            Gsm firstPhone = new Gsm("HD2", "HTC", 300, new Person("Peshko", "Peshev"), new Battery("Rechargable", 12, 22, BatteryType.NiMH), new Display(6, 200000));
            Gsm secondPhone = new Gsm("1010", "Nokia", 400, new Person("Mincho", "Minchev"), new Battery("Rechargable", 12, 32, BatteryType.NiCd), new Display(4, 400000));
            Gsm thirdPhone = new Gsm("S4", "Samsung", 600, new Person("Slivko", "Slivkov"), new Battery("Rechargable", 12, 22, BatteryType.LiIon), new Display(7, 500000));
            Gsm fourthPhone = new Gsm("HTC HD2", "HTC", 1.0m, new Person("Az", "Sum"), new Battery("kdjfkdf", 1, 1, BatteryType.LiIon), new Display(1, 1));

            List<Gsm> phones = new List<Gsm>();
            phones.Add(firstPhone);
            phones.Add(secondPhone);
            phones.Add(thirdPhone);
            phones.Add(fourthPhone);

            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
            }

            Console.WriteLine(Gsm.IPhone4s);

            // Call History Tests
            firstPhone.AddCall(new Call(DateTime.Now, "123123", 123));
            Console.WriteLine("Calls: " + firstPhone.CallHistory.Count);

            firstPhone.ClearCallHistory();
            Console.WriteLine("Calls: " + firstPhone.CallHistory.Count);

            firstPhone.AddCall(new Call(DateTime.Now, "0888123123", 123));
            firstPhone.AddCall(new Call(DateTime.Now.AddSeconds(123), "0878333111", 321));
            firstPhone.AddCall(new Call(DateTime.Now.AddSeconds(321), "0878333111", 361));

            firstPhone.DisplayCallHistory();

            Console.WriteLine("{0:f2} BGN", firstPhone.CalcPricePerMinute(0.37m));

            firstPhone.RemoveLongestCallAndCalcPpm(0.37m);

            // Finally clear the call history and print it.
            firstPhone.ClearCallHistory();
            firstPhone.DisplayCallHistory();
        }
    }
}