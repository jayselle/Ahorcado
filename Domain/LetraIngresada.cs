namespace Domain
{
    public class LetraIngresada
    {
        public int Id { get; set; }
        public string Letra { get; set; }
        public Juego Juego { get; set; }
    }
}