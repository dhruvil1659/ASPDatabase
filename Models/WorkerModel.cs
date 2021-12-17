// Dhruvil Chaudhari (100802514)
// reference: Prof. Alaadin Addas
// https://durhamcollege.desire2learn.com/d2l/le/content/390094/viewContent/5208532/View


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPDatabase.Models
{
    public class WorkerModel
    {
        
        public int Id { get; set; }
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "You need to enter first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "You need to enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must specify the quantity of messages to be sent.")]
        [Range(typeof(int), "1", "15000", ErrorMessage = "The amount of messages must range from one to fifteen thousand.")]
        public int Messages { get; set; }


        public virtual decimal GetPay()
        {

            decimal employeePay = 0M;
            int[] MessagesSent = { 1, 1250, 2500, 3750, 5000 };
            decimal[] PricePaid = { 0.025M, 0.03M, 0.035M, 0.041M, 0.048M };

            for (int i = 1; i < MessagesSent.Length; i++)
            {
                if (Messages < MessagesSent[i] && Messages > MessagesSent[i - 1])
                {
                    employeePay = Messages * PricePaid[i - 1];
                }
                else
                {
                    employeePay = Messages * PricePaid[4];
                }
            }

            return employeePay;
        }
    }
}
