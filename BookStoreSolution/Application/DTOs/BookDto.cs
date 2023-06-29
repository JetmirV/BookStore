namespace Application.DTOs;

#nullable disable
public class BookDto : Base
{
	public string Name { get; set; }
	public string Description { get; set; }
    public string Authors { get; set; }
    public decimal Price { get; set; }
	public string ImgUrl { get; set; }
	public string Code { get; set; }
	public int Quantity { get; set; }
}
