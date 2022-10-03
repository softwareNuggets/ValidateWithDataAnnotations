using System;
using System.ComponentModel.DataAnnotations;

namespace ValidateWithDataAnnotations
{
    public class Item
    {

        [Required]
        public int ItemId { get; set; }

        [Required]
        public string ShortDesc { get; set; }



        

        [Required(ErrorMessage ="Please enter a value for the General Ledger Code [GLCode]")]

        [MinLength(3)]
        [MaxLength(5)]
        public string GLCode { get; set; }



        [Required]
        public DateTime CreateDate { get; set; }


        public List<ValidationResult>? IsItemValid(Item item)
        {
            var errorMessage = new List<ValidationResult>();

            var context = new ValidationContext(item);

            bool rv = Validator.TryValidateObject(item, context, errorMessage,true);
            if(rv == false)
            {
                return errorMessage;
            }

            return null;
        }

        public void ShowErrors(List<ValidationResult> errors)
        {
            foreach(var error in errors)
            {
                Console.WriteLine($"error: {error}");
            }
        }
    }
}
