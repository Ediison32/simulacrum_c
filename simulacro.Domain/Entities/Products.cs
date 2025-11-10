using System.Runtime.InteropServices.JavaScript;

namespace simulacro.Application.Models;

public class Products
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cuantity { get; set; }
    public double price { get; set; } 
    
    public string topy { get; set; }
    
    
    public DateTime CreateProduct { get; set; }
    public DateTime UpdateProduct { get; set; }
    
}