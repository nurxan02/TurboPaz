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
        public int Year { get; set; }
        public Brand Brand { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.AddHours(4);
        
        static int counter = 0;
        #endregion

        public Model(Brand brand)
        {
            this.Brand = brand;
        }
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
            return $"{line}\nID:{Id} #\nModel Name is: {Name.ToUpper()}\nModel gas type is: {GasType.ToUpper()}\nModel Year is: {Year} \nModel Ban Type is: {BanType.ToUpper()}\nThis Model GearBox Type is :{GearBox}\nThis Model Price is : {Price}{Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol}\nThis Model Engine : {Engine} lt\nThis Model Color is: {Color.ToUpper()}\nAdded Date this Model: {Date}\n{line}";
        }
        #region Thinking about on this, it is useless :)
        public string ToString(Brand brand)
        {

            string data = (brand == null) ? null : $"{brand.Name.ToUpper()}";
            string line = "------------------------------------------------------------------------------------------------------";
            return $"{line}\nID:{Id} #\nBrand name is : {data}\nModel Name is: {Name.ToUpper()}\nModel gas type is: {GasType.ToUpper()}\nModel Year is: {Year} \nModel Ban Type is: {BanType.ToUpper()}\nThis Model GearBox Type is :{GearBox}\nThis Model Price is : {Price}{Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol}\nThis Model Engine : {Engine} lt\nThis Model Color is: {Color.ToUpper()}\nAdded Date this Model: {Date}\n{line}";
        }
        #endregion
    }
}
