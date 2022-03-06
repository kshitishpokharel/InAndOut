using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        public string ExpenseName { get; set; }
        public float ExpenseAmount { get; set; }
    }
}
