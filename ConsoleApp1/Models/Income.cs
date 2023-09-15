using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Income
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Income_Date { get; set; }
        public int Category_Id { get; set; }

        public Income() { }

        public Income(decimal amount, DateTime date)
        {
            Amount = amount;
            Income_Date = date;
        }

        public Income(decimal amount, int category_Id)
        {
            Amount = amount;
            Category_Id = category_Id;
        }

        public Income(string description, decimal amount, int category_Id)
        {
            Description = description;
            Amount = amount;
            Category_Id = category_Id;
        }

        public Income(string description, decimal amount, DateTime date, int category_Id)
        {
            Description = description;
            Amount = amount;
            Income_Date = date;
            Category_Id = category_Id;
        }

        public Income(int id, string description, decimal amount, DateTime date, int category_Id)
        {
            Id = id;
            Description = description;
            Amount = amount;
            Income_Date = date;
            Category_Id = category_Id;
        }

        public override string ToString()
        {
            return $" Id : {Id}, \n" +
                $" Description : {Description}, \n" +
                $" Amount : {Amount}, \n" +
                $" Income Date : {Income_Date}, \n" +
                $" Category Id : {Category_Id}";
        }
    }
}
