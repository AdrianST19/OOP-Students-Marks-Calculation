using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLFile
{
    public class Elev : Persoana
    {

        private static int nota1, nota2, nota3, nota4, nota5, nota6, nota7, nota8;
        private int total;
        private double media;
        private int[] note = new int[8];
        public readonly int numarMaterii = 8; //readonly
        private string? status=null;
        NivelulStudiilor? studii; // includere de clasa, continuarea se afla mai jos

        public Elev(string nume, int nota1, int nota2, int nota3, int nota4, int nota5, int nota6, int nota7, int nota8) : base(nume)
        {
            this.note[0] = nota1;
            this.note[1] = nota2;
            this.note[2] = nota3;
            this.note[3] = nota4;
            this.note[4] = nota5;
            this.note[5] = nota6;
            this.note[6] = nota7;
            this.note[7] = nota8;
            this.total = nota1 + nota2 + nota3 + nota4 + nota5 + nota6 + nota7 + nota8;
            this.media = total / 8;
        }

        public Elev(string nume, double media) : base(nume)
        {
            this.total = note.Sum(); ;//constructor de copiere
            this.media = total / 8;
        }

        public int TotalulPunctelor() //getter total puncte
        {
            return this.total;
        }

        public double MediaObtinuta() //getter medie obtinuta
        {
            return this.media;
        }

        public string AfisareNote() //getter note obtinute
        {
            string notele = "Notele obtinute sunt: ";
            foreach (int i in this.note) notele += i.ToString() + " "; // conversie int to string
            return notele;
        }

        public string AfisareNume() //getter afisare nume
        {
            return base.ToString();
        }

        public int NumarMaterii() //getter numar materii
        {
            return numarMaterii;
        }

        public double MarireMedie(double puncte) //setter marire medie
        {
            puncte += this.media;
            return puncte;
        }

        public int NotaMin()
        {
            return note.Min();
        }
        public int NotaMax()
        {
            return note.Max();
        }

        public string AfisareStatus()
        {
            Boolean promovare = true;
            foreach (int i in this.note)
            {
                if (i < 5)
                {
                    promovare = false;
                    break;
                }
            }
            status = (promovare == true && this.media >= 5) ? "Promovat" : "Corigent";
            return status;
        }

        public override string ToString() // supraincarcare
        {
            return $"Elevul {NUME} a obtinut media {media}."; //, {base.ToString()}
        }

        public string NivelStudii() // polimorfism
        {
            this.studii = new NivelulStudiilor();   //Includere de clasa
            studii.NivelStudii = "Liceale"; //setter nivel de studii
            string stdi = studii.NivelStudii;
            return stdi;
        }
        public string NivelStudii(int claseTerminate) // polimorfism
        {
            if (claseTerminate <= 8) return "Scoala Generala";
            if (claseTerminate <= 12 && claseTerminate > 8) return "Studii Liceale";
            if (claseTerminate > 12) return "Studii Universitare";
            else return "Fara studii";

        }
    }
}
