using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//BARIŞ CAN KURT 161106109001 BİLGİSAYAR MÜHENDİSLİĞİ İŞLETİM SİSTEMLERİ PROJE

namespace ConsoleApp2
{
    class Program
    {
        public struct islem
        {
            public int sure;
            public int oncelik;
            public string isim;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Kac İslem Yapmak İstediginizi Girin:\n");
            string iSayisi = Console.ReadLine();
            int islemSayisi = Convert.ToInt16(iSayisi);
            if(islemSayisi>6 || islemSayisi<=0)
            {
                Console.WriteLine("Hatali islem sayisi girisi.");
                Console.ReadLine();
                return;
            }
            islem[] dizi = new islem[islemSayisi];
            islem[] dizi2 = new islem[islemSayisi];
            islem[] dizi3 = new islem[islemSayisi];
            int[] sureler = new int[25];
            Console.Clear();
            for(int i= 0; i<islemSayisi; i++)
            {
                Console.WriteLine("İslem İsmini Giriniz\n");
                string ismi1 = Console.ReadLine();
                dizi[i].isim = ismi1;
                Console.WriteLine("İslem Suresini Giriniz\n");
                string a = Console.ReadLine();
                Console.WriteLine("İslem Onceligini Giriniz\n");
                string b = Console.ReadLine();                
                dizi[i].sure = Convert.ToInt16(a);
                dizi[i].oncelik = Convert.ToInt16(b);
            }
            Console.Clear();
            /*for(int i = 0; i < islemSayisi; i++)
            {
                Console.WriteLine(dizi[i].isim);
            }*/
            int dongu = 0;
            while (dongu==0)
            {
                int sayac = 0;
                foreach (var item in dizi)
                {
                    dizi2[sayac] = item;
                    dizi3[sayac] = item;
                    sayac++;
                }

                Console.WriteLine("Bu islemleri hangi metod ile siralamak istiyorsunuz?\n1-FCFS(First Come First Served)\n2-SJF(Shortest Job First)\n3-PS(Priority Scheduling)\n");
                string m = Console.ReadLine();

                int metod = Convert.ToInt16(m);
                switch (metod)
                {
                    case 1:



                        for (int i = 0; i < islemSayisi; i++)
                        {
                            Console.WriteLine(dizi2[i].isim + " islemi " + dizi2[i].sure + " saniyede tamamlandi ve " + "oncelik degeri " + dizi2[i].oncelik + ".");
                        }
                        for (int i = 0; i < islemSayisi * 2 * 9; i++)
                        {
                            Console.Write("-");
                        }
                        Console.WriteLine();
                        for (int i = 0; i < islemSayisi; i++)
                        {
                            for (int j = 0; j < dizi2[i].sure; j++)
                            {
                                Console.Write("   ");
                            }
                            Console.Write("|" + dizi2[i].isim + "|");
                        }
                        Console.WriteLine();
                        for (int i = 0; i < dizi2[0].sure; i++)
                        {
                            Console.Write("   ");
                        }

                        Console.Write("|" + dizi2[0].sure + "|");
                        for (int i = 1; i < islemSayisi; i++)
                        {
                            for (int j = 0; j < dizi2[i].sure; j++)
                            {
                                Console.Write("   ");
                            }
                            Console.Write("|");
                            Console.Write((dizi2[i].sure + dizi2[i - 1].sure));
                            dizi2[i].sure = dizi2[i].sure + dizi2[i - 1].sure;
                            Console.Write("|");
                        }
                        Console.WriteLine();
                        for (int i = 0; i < islemSayisi * 2 * 9; i++)
                        {
                            Console.Write("-");
                        }



                        Console.ReadLine();
                        for (int i = 0; i < islemSayisi; i++)
                        {
                            Process ty = new Process();
                            ty.StartInfo.FileName = "calistirilan.exe";

                            ty.StartInfo.Arguments = dizi[i].isim + " " + dizi[i].sure;
                            ty.Start();

                            ty.WaitForExit(dizi[i].sure * 1000);
                        }

                        break;
                    case 2:


                        for (int i = 0; i < dizi2.Length - 1; i++)
                        {
                            for (int j = i; j < dizi2.Length; j++)
                            {
                                if (dizi2[i].sure > dizi2[j].sure)
                                {
                                    var gecici = dizi2[j];
                                    dizi2[j] = dizi2[i];
                                    dizi2[i] = gecici;
                                }
                            }
                        }
                        for (int i = 0; i < islemSayisi; i++)
                        {
                            Console.WriteLine(dizi2[i].isim + " islemi " + dizi2[i].sure + " saniyede tamamlandi ve " + "oncelik degeri " + dizi2[i].oncelik + ".");
                        }
                        Console.ReadLine();

                        for (int i = 0; i < islemSayisi * 2 * 9; i++)
                        {
                            Console.Write("-");
                        }
                        Console.WriteLine();
                        for (int i = 0; i < islemSayisi; i++)
                        {
                            for (int j = 0; j < dizi2[i].sure; j++)
                            {
                                Console.Write("   ");
                            }
                            Console.Write("|" + dizi2[i].isim + "|");
                        }

                        for (int i = 0; i < dizi3.Length - 1; i++)
                        {
                            for (int j = i; j < dizi3.Length; j++)
                            {
                                if (dizi3[i].sure > dizi3[j].sure)
                                {
                                    var gecici = dizi3[j];
                                    dizi3[j] = dizi3[i];
                                    dizi3[i] = gecici;
                                }
                            }
                        }



                        Console.WriteLine();
                        for (int i = 0; i < dizi2[0].sure; i++)
                        {
                            Console.Write("   ");
                        }
                        
                        Console.Write("|" + dizi2[0].sure + "|");
                        for (int i = 1; i < islemSayisi; i++)
                        {
                            for (int j = 0; j < dizi3[i].sure; j++)
                            {
                                Console.Write("   ");
                            }
                            Console.Write("|");
                            Console.Write((dizi3[i].sure + dizi3[i - 1].sure));
                            dizi3[i].sure = dizi3[i].sure + dizi3[i - 1].sure;
                            Console.Write("|");
                        }
                        Console.WriteLine();
                        for (int i = 0; i < islemSayisi * 2 * 9; i++)
                        {
                            Console.Write("-");
                        }
                        Console.ReadLine();

                        

                        for (int i = 0; i < islemSayisi; i++)
                        {
                            Process ty = new Process();
                            ty.StartInfo.FileName = "calistirilan.exe";

                            ty.StartInfo.Arguments = dizi2[i].isim + " " + dizi2[i].sure;
                            ty.Start();

                            ty.WaitForExit(dizi2[i].sure * 1000);
                        }
                        break;
                    case 3:

                        for (int i = 0; i < dizi2.Length - 1; i++)
                        {
                            for (int j = i; j < dizi2.Length; j++)
                            {
                                
                                if (dizi2[i].oncelik > dizi2[j].oncelik)
                                {
                                    var gecici = dizi2[j];
                                    dizi2[j] = dizi2[i];
                                    dizi2[i] = gecici;
                                }
                            }
                        }


                        for (int i = 0; i < islemSayisi; i++)
                        {
                            Console.WriteLine(dizi2[i].isim + " islemi " + dizi2[i].sure + " saniyede tamamlandi ve " + "oncelik degeri " + dizi2[i].oncelik + ".");
                        }
                        Console.ReadLine();
                        for (int i = 0; i < islemSayisi * 2 * 9; i++)
                        {
                            Console.Write("-");
                        }
                        Console.WriteLine();
                        
                        for (int i = 0; i < islemSayisi; i++)
                        {
                           
                            for (int j = 0; j < dizi2[i].sure; j++)
                            {
                                Console.Write("   ");
                            }
                            Console.Write("|" + dizi2[i].isim + "|");
                        }
                        for (int i = 0; i < dizi3.Length - 1; i++)
                        {
                            for (int j = i; j < dizi3.Length; j++)
                            {

                                if (dizi3[i].oncelik > dizi3[j].oncelik)
                                {
                                    var gecici = dizi3[j];
                                    dizi3[j] = dizi3[i];
                                    dizi3[i] = gecici;
                                }
                            }
                        }
                        Console.WriteLine();
                        for (int i = 0; i < dizi2[0].sure; i++)
                        {
                            Console.Write("   ");
                        }

                        Console.Write("|" + dizi2[0].sure + "|");
                        for (int i = 1; i < islemSayisi; i++)
                        {
                            for (int j = 0; j < dizi3[i].sure; j++)
                            {
                                Console.Write("   ");
                            }
                            Console.Write("|");
                            Console.Write((dizi3[i].sure + dizi3[i - 1].sure));
                            dizi3[i].sure = dizi3[i].sure + dizi3[i - 1].sure;
                            Console.Write("|");
                        }
                        Console.WriteLine();
                        for (int i = 0; i < islemSayisi * 2 * 9; i++)
                        {
                            Console.Write("-");
                        }




                        Console.ReadLine();
                        
                        for (int i = 0; i < islemSayisi; i++)
                        {
                            Process ty = new Process();
                            ty.StartInfo.FileName = "calistirilan.exe";

                            ty.StartInfo.Arguments = dizi2[i].isim + " " + dizi2[i].sure;
                            ty.Start();

                            ty.WaitForExit(dizi2[i].sure * 1000);
                        }
                        break;
                }
                Console.WriteLine("İsleme devam etmek istemiyorsaniz h tusuna basip enterlayiniz. Devam etmek istiyorsaniz e yazip enterlayiniz.");
                for(int h=0;h<100;h++)
                {
                    string bc;
                    bc = Console.ReadLine();

                    if (bc[0] == 'e')
                    {
                        dongu = 0;
                        Console.Clear();
                        break;
                    }
                    else if (bc[0] == 'h')
                    {
                        dongu++;
                        break;
                    }
                 

                }






            }

        }
    }
}
