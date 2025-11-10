namespace simulacro.Application.Dto;

public class ProductsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cuantity { get; set; }
    public double price { get; set; } 
    public string topy { get; set; }
    public DateTime CreateProduct { get; set; }
    
}

// create

public class ProductCreateDto
{
    public string Name { get; set; }
    public int Cuantity { get; set; }
    public double price { get; set; }
    public string topy { get; set; }
}

// update

public class ProductUpdateDto
{
    public string Name { get; set; }
    public int Cuantity { get; set; }
    public double price { get; set; }
    public string topy { get; set; }
}