namespace Domain;

public class Preco
{
    public long Id { get; set; }
    public DateTime InicioVigencia { get; set; }
    public DateTime FimVigencia { get; set; }
    public decimal HoraInicial { get; set; }
    public decimal HoraAdicional { get; set; }
}
