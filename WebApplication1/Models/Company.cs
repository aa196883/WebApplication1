﻿namespace WebApplication1.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int NumberOfEmployees { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
