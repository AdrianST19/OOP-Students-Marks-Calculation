namespace DLLFile
{
    public class Persoana
    {
        public Persoana(string nUME)
        {
            NUME = nUME;
        }

        public string? NUME { get; private set; }


        public override string ToString() // supraincarcare
        {
            return base.ToString() + $", nume = {NUME}";
        }

    }
}