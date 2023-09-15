using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Expense_Date { get; set; }
        public int Category_Id { get; set; }

        public Expense() { }

        public Expense(decimal amount, DateTime date)
        {
            Amount = amount;
            Expense_Date = date;
        }

        public Expense(decimal amount, int category_Id)
        {
            Amount = amount;
            Category_Id = category_Id;
        }

        public Expense(string description, decimal amount, int category_Id)
        {
            Description = description;
            Amount = amount;
            Category_Id = category_Id;
        }

        public Expense(string description, decimal amount, DateTime date, int category_Id)
        {
            Description = description;
            Amount = amount;
            Expense_Date = date;
            Category_Id = category_Id;
        }

        public Expense(int id, string description, decimal amount, DateTime date, int category_Id)
        {
            Id = id;
            Description = description;
            Amount = amount;
            Expense_Date = date;
            Category_Id = category_Id;
        }

        public override string ToString()
        {
            return $" Id : {Id}, \n" +
                $" Description : {Description}, \n" +
                $" Amount : {Amount}, \n" +
                $" Expense Date : {Expense_Date}, \n" +
                $" Category Id : {Category_Id}";
        }
    }
}
