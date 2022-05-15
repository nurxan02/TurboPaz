using System;
using System.Linq;
using TurboPaz.Enums;
using TurboPaz.Models;
using TurboPazLib;
using TurboPazLib.Enums;

namespace TurboPaz
{
    [Obsolete]
    internal class Program
    {
        static void Main(string[] args)
        {
            #region File Locations

            const string modelsfileup = @"models.dat";
            const string brandsfileup = @"brands.dat";

            #endregion

            #region Utilits initialize

            Utilits.Init("TurboPaz v9.9");

            #endregion

            #region Load from file for Models

            var modelprop = Utilits.LoadFromFile<Model[]>(modelsfileup);
            Model[] models = null;
            if (modelprop == null)
                models = new Model[0];
            else
            {
                models = (Model[])modelprop;
                int max = models.Max(b => b.Id);
                Model.SetCounter(max);
            }

            #endregion

            #region Load from file for Brands

            var brandprop = Utilits.LoadFromFile<Brand[]>(brandsfileup);
            Brand[] brands = null;
            if (brandprop == null)
                brands = new Brand[0];
            else
            {
                brands = (Brand[])brandprop;
                int max = brands.Max(b => b.Id);
                Brand.SetCounter(max);
            }

            #endregion

            #region Variables
            int id;
            int len;
            #endregion

        l1:
            #region Switch Case started 
            PrintMenu();
            MenuStateEnum m = Utilits.ReadMenu("Plase select a menu:");
            switch (m)
            {
                #region Model All
                case MenuStateEnum.ModelAll:
                    Console.Clear();
                    Console.WriteLine("List of All Models:");
                    foreach (var model in models)
                    {
                        var brand = brands.FirstOrDefault(a => a.Id == model.BrandId);
                        Console.WriteLine(model.ToString(brand));
                    }
                    goto l1;
                #endregion
                #region Brand All
                case MenuStateEnum.BrandAll:
                    Console.Clear();
                    ShowAllBrands(brands);
                    goto l1;
                #endregion
                #region Model by ID
                case MenuStateEnum.ModelById:

                    id = Utilits.ReadInt("Model code : ", 0);

                    if (id == 0)
                    {
                        goto case MenuStateEnum.ModelAll;
                    }

                    var search = new Model(id);
                    int index = Array.IndexOf(models, search);

                    if (index != -1)
                    {
                        search = models[index];
                        Console.Clear();
                        Utilits.PrintWarning($"Finded: {search}");
                        goto l1;
                    }
                    Utilits.PrintError("Model does not exist!");
                    goto case MenuStateEnum.ModelById;
                #endregion
                #region Model Add
                case MenuStateEnum.ModelAdd:

                    ShowAllBrands(brands);
                    int brandId;
                    string color="";
                l2:
                    brandId = Utilits.ReadInt("Write Brand id: ", minValue: 1);

                    var selectedBrand = new Brand(brandId);

                    if (Array.IndexOf(brands, selectedBrand) == -1)
                    {
                        Utilits.PrintError("Select List of All");
                        goto l2;
                    }

                    len = models.Length;
                    Array.Resize(ref models, len + 1);
                    models[len] = new Model();
                    models[len].BrandId = brandId;
                    models[len].Name = Utilits.ReadString("Model's name: ", true);
                    models[len].Engine = Utilits.ReadDouble("Engine liter: ", 0.1,20);
                    models[len].Price = Utilits.ReadInt("Price of model: ", 1000);
                    models[len].Year = Utilits.ReadIntYear("First Car is invented 1886 please add True year friend :)\nYear of model: ", 1886,3000);

                    PrintGearBoxTypes();
                    GearBoxEnum c = Utilits.ReadGearBoxType("Select any Gearbox type on this list: ");
                    models[len].GearBox = c.ToString();

                    PrintBanTypes();
                    BanModelEnum b = Utilits.ReadBanType("Select any ban type on this list: ");
                    models[len].BanType = b.ToString();
                    l10:
                    color =  Utilits.ReadString("Cars Color: ", true);
                    bool containsInt = color.Any(char.IsDigit);
                    if (containsInt!=true)
                    {
                        models[len].Color = color;
                    }
                    else
                    {
                        Utilits.PrintError("False Color Type please insert again!");
                        goto l10;
                    }
                    PrintGasTypes();
                    GasTypeEnum g = Utilits.ReadGasType("Select any Gas type on this list:");
                    models[len].GasType = g.ToString();
                    Console.Clear();
                    goto case MenuStateEnum.ModelAll;
                #endregion
                #region Model Edit
                case MenuStateEnum.ModelEdit:
                    id = Utilits.ReadInt("Model Code: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStateEnum.ModelAll;
                    }

                    var searchbyedit = new Model(id);

                    int indexbyedit = Array.IndexOf(models, searchbyedit);

                    if (indexbyedit != -1)
                    {
                        search = models[indexbyedit];
                        Console.Clear();
                        Utilits.PrintWarning($"Finded as model: {search}");

                        string namebyedit = Utilits.ReadString(" Set name of this model: ");

                        if (!string.IsNullOrWhiteSpace(namebyedit))
                        {
                            search.Name = namebyedit;
                        }
                        ShowAllBrands(brands);
                        int brandidforedit;
                    l3:
                        brandidforedit = Utilits.ReadInt("Insert brand id is this model : ", minvalue: 1);

                        var selectedbrandforedit = new Brand(brandidforedit);

                        if (Array.IndexOf(brands, selectedbrandforedit) == -1)
                        {
                            Utilits.PrintError("Select on list please!");
                            goto l3;
                        }
                        search.BrandId = brandidforedit;

                        search.Engine = Utilits.ReadDouble("Engine liter of this model : ", 0.1,20);
                        search.Price = Utilits.ReadInt("Set price of this model : ", 0);
                        search.Year = Utilits.ReadIntYear("First Car is invented 1886 please add True year friend :)\nYear of model: ", 1886,3000);

                        l11:
                        string color2 = Utilits.ReadString("Cars Color: ", true);
                        bool containsIntEdit = color2.Any(char.IsDigit);
                        if (containsIntEdit != true)
                        {
                            search.Color = color2;
                        }
                        else
                        {
                            Utilits.PrintError("False Color Type please insert again!");
                            goto l11;
                        }

                        PrintGearBoxTypes();
                        GearBoxEnum x = Utilits.ReadGearBoxType("Select any Gearbox type on this list: ");
                        search.GearBox = x.ToString();

                        PrintBanTypes();
                        BanModelEnum z = Utilits.ReadBanType("Select any ban type on this list: ");
                        search.BanType = z.ToString();

                        PrintGasTypes();
                        GasTypeEnum y = Utilits.ReadGasType("Select any Gas type on this list:");
                        search.GasType = y.ToString();

                        goto case MenuStateEnum.BrandAll;
                    }


                    Utilits.PrintError("I can not find searched model!!!");
                    goto case MenuStateEnum.ModelEdit;
                #endregion
                #region Model Remove
                case MenuStateEnum.ModelRemove:
                    id = Utilits.ReadInt("Model code: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStateEnum.ModelAll;
                    }

                    var searchbyremove = new Model(id);

                    int indexbyremove = Array.IndexOf(models, searchbyremove);

                    if (indexbyremove == -1)
                    {
                        Utilits.PrintError("I can not find searched model!!");
                        goto case MenuStateEnum.ModelRemove;
                    }


                    for (int i = indexbyremove; i < models.Length - 1; i++)
                    {
                        models[i] = models[i + 1];
                    }
                    Array.Resize(ref models, models.Length - 1);

                    goto case MenuStateEnum.ModelAll;
                #endregion
                #region Brand by ID
                case MenuStateEnum.BrandById:
                    id = Utilits.ReadInt("brand code: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStateEnum.BrandAll;
                    }

                    var searchbrand = new Brand(id);

                    int indexbrand = Array.IndexOf(brands, searchbrand);

                    if (indexbrand != -1)
                    {
                        searchbrand = brands[indexbrand];
                        Console.Clear();
                        Utilits.PrintWarning($"Finded for brand: {searchbrand}");
                        goto l1;
                    }


                    Utilits.PrintError("Brand no found!");
                    goto case MenuStateEnum.BrandById;
                #endregion
                #region Brand Add
                case MenuStateEnum.BrandAdd:
                    string Name = Utilits.ReadString("Brand Name is : ", true);
                    for (int i = 0; i < brands.Length; i++)
                    {
                        if (brands[i].Name.ToUpper() == Name.ToUpper())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Brand Name Already exist\nPlease add again");
                            Console.ResetColor();
                            goto case MenuStateEnum.BrandAdd;
                        }
                    }
                    Brand brandd = new Brand();
                    brandd.Name = Name;
                    Array.Resize(ref brands, brands.Length + 1);
                    brands[brands.Length-1] = brandd;
                    Console.Clear();
                    goto case MenuStateEnum.BrandAll;
                #endregion
                #region Brand Edit
                case MenuStateEnum.BrandEdit:
                    id = Utilits.ReadInt("Brand code : ", 0);

                    if (id == 0)
                    {
                        goto case MenuStateEnum.BrandAll;
                    }

                    var searchbrandbyedit = new Brand(id);

                    int indexbrandbyedit = Array.IndexOf(brands, searchbrandbyedit);

                    if (indexbrandbyedit != -1)
                    {
                        searchbrandbyedit = brands[indexbrandbyedit];
                        Console.Clear();
                        Utilits.PrintWarning($"Finded: {searchbrandbyedit}");
                        l9:
                        string namebyedit = Utilits.ReadString("Brand Name is : ", true);
                        for (int i = 0; i < brands.Length; i++)
                        {
                            if (brands[i].Name.ToUpper() == namebyedit.ToUpper())
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Brand Name Already exist\nPlease add again");
                                Console.ResetColor();
                                goto l9;
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(namebyedit))
                        {
                            searchbrandbyedit.Name = namebyedit;
                        }
                        Brand branddd = new Brand();
                        branddd.Name = namebyedit;
                        goto case MenuStateEnum.BrandAll;
                    }


                    Utilits.PrintError("I can not find Brand to search!!");
                    goto case MenuStateEnum.BrandEdit;
                #endregion
                #region Brand Remove
                case MenuStateEnum.BrandRemove:
                    id = Utilits.ReadInt("Brand code: ", 0);

                    if (id == 0)
                    {
                        goto case MenuStateEnum.BrandAll;
                    }

                    var searchbradbyremove = new Brand(id);

                    int indexbrandbyremove = Array.IndexOf(brands, searchbradbyremove);

                    if (indexbrandbyremove == -1)
                    {
                        Utilits.PrintError("I can not find this brand!!");
                        goto case MenuStateEnum.BrandRemove;
                    }

                    for (int i = indexbrandbyremove; i < brands.Length - 1; i++)
                    {
                        brands[i] = brands[i + 1];
                    }
                    Array.Resize(ref brands, brands.Length - 1);
                    goto case MenuStateEnum.BrandAll;
                #endregion
                #region Save Changes
                case MenuStateEnum.SaveChanges:
                    Utilits.SaveToFile(modelsfileup, models);
                    Utilits.SaveToFile(brandsfileup, brands);

                    Console.Clear();
                    Console.WriteLine("All changes save at .dat file on Program location!");
                    goto l1;
                #endregion
                #region Exit
                case MenuStateEnum.Exit:
                    Utilits.PrintError("For exit tap again ENTER key please!");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Environment.Exit(0);
                    }
                    Console.Clear();
                    goto l1;

                default:
                    break;
                    #endregion
            }
            #endregion
            #region Useless
            //static bool EqualToStrs(string a, string b)
            //{
            //    if (a == b)
            //    {
            //        return true;
            //    }
            //    return false;

            //}
            #endregion

            #region Print Menu Method
            static void PrintMenu()
            {
                Utilits.PrintWarning("|************************  TurboPaz  ************************|");
                foreach (var item in Enum.GetValues(typeof(MenuStateEnum)))
                {
                    Utilits.PrintWarning($"{((byte)item).ToString().PadLeft(25)}) {item}");
                }
                Utilits.PrintWarning("|************************************************************|");
            }

            static void PrintGasTypes()
            {
                foreach (var item in Enum.GetValues(typeof(GasTypeEnum)))
                {
                    Utilits.PrintWarning($"|----{((byte)item).ToString().PadLeft(2)}) {item}----|");
                }
            }

            static void PrintBanTypes()
            {
                foreach (var item in Enum.GetValues(typeof(BanModelEnum)))
                {
                    Utilits.PrintWarning($"|----{((byte)item).ToString().PadLeft(2)}) {item}----|");
                }
            }

            static void PrintGearBoxTypes()
            {
                foreach (var item in Enum.GetValues(typeof(GearBoxEnum)))
                {
                    Utilits.PrintWarning($"|----{((byte)item).ToString().PadLeft(2)}) {item}----|");
                }
            }

            #endregion
            #region Show All Brands 
            static void ShowAllBrands(Brand[] brands)
            {
                Console.WriteLine("List of Brands:");
                foreach (var brand in brands)
                {
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine(brand);
                    Console.WriteLine("-------------------------------------------------------------------------");

                }
            }
            #endregion
        }
    }
}
