# TurboPaz
Automobile Salon Management Console app

## Screenshot from Console

<div align="center">
   <img src="https://user-images.githubusercontent.com/90649844/171020043-ac7ee1bc-2e64-4900-9996-dbe829abbaf4.png" alt="Console Screenshot" width="auto" height="200px">
  </div>

## My Project properties

How can i download my project ?

```bash
git clone [--template=<template-directory>]
	  [-l] [-s] [--no-hardlinks] [-q] [-n] [--bare] [--mirror]
	  [-o <name>] [-b <name>] [-u <upload-pack>] [--reference <repository>]
	  [--dissociate] [--separate-git-dir <git-dir>]
	  [--depth <depth>] [--[no-]single-branch] [--no-tags]
	  [--recurse-submodules[=<pathspec>]] [--[no-]shallow-submodules]
	  [--[no-]remote-submodules] [--jobs <n>] [--sparse] [--[no-]reject-shallow]
	  [--filter=<filter> [--also-filter-submodules]] [--] <repository>
	  [<directory>]
```

## Model Class view

```cshap
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TurboPaz.Models
{
    [Serializable]
    public class Model : IEquatable<Model>
    {
        #region Properties of Model
        public int Id { get; private set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public double Price { get; set; }
        public string GasType { get; set; }
        public double Engine { get; set; }
        public string Color { get; set; }
        public string BanType { get; set; }
        public string  GearBox { get; set; }
        static int counter = 0;
        #endregion

        public Model()
        {
            counter++;
            Id = counter;
        }
        public Model(int id)
        {
            this.Id = id;
        }

        public static void SetCounter(int counter)
        {
            Model.counter = counter;
            counter++;

        }

        public bool Equals(Model oth)
        {
            return Id == oth.Id;
        }

        public override string ToString()
        {
            string line = "------------------------------------------------------------------------------------------------------";
            return $"{line}\nID:{Id}#\nModel Name is: {Name.ToUpper()}\nModel gas type is: {GasType.ToUpper()}\nModel Ban Type is: {BanType.ToUpper()}\nThis Model GearBox Type is :{GearBox}\nThis Model Price is : {Price}{Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol}\nThis Model Engine : {Engine}\nThis Model Color is: {Color.ToUpper()}\n{line}";
        }
        #region Thinking about this it is uncompeleted
        //public string ToString(Brand brand)
        //{
        //    string data = (brand == null) ? null : $"{brand.Id} Brand name is : {brand.Name.ToUpper()}";

        //    return $"{Id}#--->{data},  Model name is:  {Name.ToUpper()} ,This Model Ban Type is : {BanType.ToUpper()}  ,This Model GearBox Type is :{GearBox.ToUpper()}, This Model Color is {Color.ToUpper()}, This model Gas type is: {GasType.ToUpper()} , Price is : {Price:0.00}{Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol} ";
        //}
        #endregion
    }
}
```

## Contributing
Pull requests are welcome.

Please make sure to update tests as appropriate.

## License
[MIT](https://github.com/nurxan02/)

## CopyRights
Nurkhan Masimzade
#### If you want to contact with me: [**Click Here**](https://bio.link/nurxanmasimzade/)

