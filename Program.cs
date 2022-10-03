using System;
using System.ComponentModel.DataAnnotations;

namespace ValidateWithDataAnnotations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var item = new Item();
            item.ItemId = 1;
            item.ShortDesc = "short item description";
            item.GLCode ="GLA_0000";
            item.CreateDate = DateTime.Now;

            

            List<ValidationResult>? errs = item.IsItemValid(item);
            if(errs != null)
            {
                item.ShowErrors(errs);
                return;
            }

            InsertIntoTable(item);

        }

        private static void InsertIntoTable(Item item)
        {
            Console.WriteLine($"Item : {{ \"ItemId\" : {item.ItemId}, \"ShortDesc\" : \"{item.ShortDesc}\" }}");
           
        }
    }
}
