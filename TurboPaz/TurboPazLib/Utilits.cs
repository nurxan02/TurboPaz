using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TurboPaz.Enums;
using TurboPazLib.Enums;

namespace TurboPazLib
{
    public class Utilits
    {
        #region Readstring
        public static string ReadString(string caption, bool required = false)
        {
        l1:

            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            string value = Console.ReadLine();
            Console.ResetColor();
            if (required && string.IsNullOrWhiteSpace(value))
            {
                PrintError("You must insert value this line!");
                goto l1;
            }

            return value;
        }
        #endregion
        #region ReadInt
        public static int ReadInt(string caption, int minvalue = 1,int minValue=0)
        {
        l1:
            Console.Write(caption);

            string value = Console.ReadLine();

            if (!int.TryParse(value, out int number))
            {
                PrintError("Please insert true value");
                goto l1;
            }
            else if (number < minvalue)
            {
                PrintError($"Minimum value must be: {minvalue}");
                goto l1;
            }            

            return number;
        }
        #endregion
        #region ReadIntYear
        public static int ReadIntYear(string caption, int minValue = 0, int maxValue = 0)
        {
        l1:
            Console.Write(caption);
            string value = Console.ReadLine();
            if (!int.TryParse(value, out int number))
            {
                PrintError("Please insert true value");
                goto l1;
            }
            else if (number < minValue)
            {
                PrintError($"Minimum value must be: {minValue}");
                goto l1;
            }
            else if (number > maxValue)
            {
                PrintError($"Max value must be:  {maxValue}");
                goto l1;
            }
            return number;
        }
        #endregion
        #region ReadDouble
        public static double ReadDouble(string caption, double minvalue = 0, double maxvalue=0 )
        {
        l1:
            Console.WriteLine(caption);
            string value = Console.ReadLine();
            double number;

            if (!double.TryParse(value, out number))
            {
                PrintError("Pleace insert true value");
                goto l1;
            }
            else if (number < minvalue)
            {
                PrintError($"Minimum value must be: {minvalue} ");
                goto l1;
            }
            else if (number > maxvalue)
            {
                PrintError($"Max value must be: {maxvalue} ");
                goto l1;
            }
            return number;
        }
        #endregion
        #region Menustate ReadMenu
        public static MenuStateEnum ReadMenu(string caption)
        {
        l1:
            Console.WriteLine(caption);

            string value = Console.ReadLine();
            bool res;
            int a;
            res = int.TryParse(value, out a);

            if (res == true)
            {
                int valueinted = int.Parse(value);

                if (valueinted <= 12)
                {
                    bool success = Enum.IsDefined(typeof(MenuStateEnum), value);

                    if (success)
                    {
                        PrintError("Is does not exist this menu!");
                        goto l1;
                    }
                    else if (!Enum.TryParse(value, out MenuStateEnum menu))
                    {
                        PrintError("Is does not exist this menu, you mast insert index of this menu!");
                        goto l1;
                    }
                }
                else
                {
                    PrintError("Please insert valid number!!");
                    goto l1;
                }
            }
            else
            {
                PrintError("Please insert Number!!");
                goto l1;
            }
            return (MenuStateEnum)Enum.Parse(typeof(MenuStateEnum), value);
        }
        #endregion
        #region Read Gas Type
        public static GasTypeEnum ReadGasType(string caption)
        {
        l1:
            Console.WriteLine(caption);

            string value = Console.ReadLine();
            bool res;
            int a;
            res = int.TryParse(value, out a);
            if (res == true)
            {
                int valueinted = int.Parse(value);

                if (valueinted < 5)
                {
                    bool success = Enum.IsDefined(typeof(GasTypeEnum), value);

                    if (success)
                    {
                        PrintError("I Can not find this type of Gas!!!");
                        goto l1;
                    }
                    if (!Enum.TryParse(value, out GasTypeEnum gas))
                    {
                        PrintError("I can not Find typed menu, Because All Gas types has searched by id I mean index !!!");
                        goto l1;
                    }

                }
                else
                {
                    PrintError("Please insert valid number!!");
                    goto l1;
                }
            }
            else
            {
                PrintError("Please insert Number!!");
                goto l1;
            }

            return (GasTypeEnum)Enum.Parse(typeof(GasTypeEnum), value);
        }
        #endregion
        #region Read Gear Box
        public static GearBoxEnum ReadGearBoxType(string caption)
        {
        l1:
            Console.WriteLine(caption);

            string value = Console.ReadLine();
            bool res;
            int a;
            res = int.TryParse(value, out a);
            if (res == true)
            {
                int valueinted = int.Parse(value);

                if (valueinted < 3)
                {
                    bool success = Enum.IsDefined(typeof(GearBoxEnum), value);

                    if (success)
                    {
                        PrintError("I Can not find this type of GearBox!!!");
                        goto l1;
                    }
                    if (!Enum.TryParse(value, out GearBoxEnum gear))
                    {
                        PrintError("I can not Find typed menu, Because All GearBox types has searched by id I mean index !!!");
                        goto l1;
                    }

                }
                else
                {
                    PrintError("Please insert valid number!!");
                    goto l1;
                }
            }
            else
            {
                PrintError("Please insert Number!!");
                goto l1;
            }

            return (GearBoxEnum)Enum.Parse(typeof(GearBoxEnum), value);
        }
        #endregion
        #region Read Ban Type
        public static BanModelEnum ReadBanType(string caption)
        {
        l1:
            Console.WriteLine(caption);

            string value = Console.ReadLine();
            bool res;
            int a;
            res = int.TryParse(value, out a);
            if (res == true)
            {
                int valueinted = int.Parse(value);

                if (valueinted < 9)
                {
                    bool success = Enum.IsDefined(typeof(BanModelEnum), value);

                    if (success)
                    {
                        PrintError("I Can not find this type of Ban!!!");
                        goto l1;
                    }
                    if (!Enum.TryParse(value, out BanModelEnum ban))
                    {
                        PrintError("I can not Find typed menu, Because All Gas types has searched by id I mean index !!!");
                        goto l1;
                    }

                }
                else
                {
                    PrintError("Please insert valid number!!");
                    goto l1;
                }
            }
            else
            {
                PrintError("Please insert Number!!");
                goto l1;
            }

            return (BanModelEnum)Enum.Parse(typeof(BanModelEnum), value);
        }
        #endregion
        #region Print Error
        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        #endregion
        #region Print Warning
        public static void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        #endregion
        #region Init
        public static void Init(string message)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "TurboPaz v9.9";

            CultureInfo ci = new CultureInfo("az-Latn-Az");
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            ci.DateTimeFormat.LongDatePattern = "dd.MM.yyyy";
            ci.DateTimeFormat.ShortTimePattern = "HH:mm";
            ci.DateTimeFormat.LongTimePattern = "HH:mm:ss";

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
        #endregion
        #region Save To Files
        [Obsolete]
        public static void SaveToFile<T>(string filname, T graphData)
        {
            using (var fs = new FileStream(filname, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, graphData);
            }
        }
        #endregion
        #region Load From File 
        [Obsolete]
        public static T LoadFromFile<T>(string filname)
        {
            if (!File.Exists(filname))
            {
                return default(T);
            }
            using (var fs = new FileStream(filname, FileMode.Open, FileAccess.Read))
            {

                BinaryFormatter bf = new BinaryFormatter();
                var graph = bf.Deserialize(fs);
                if (graph is T)
                {
                    return (T)graph;

                }

                return default(T);
            }

        }
        #endregion
    }
}
