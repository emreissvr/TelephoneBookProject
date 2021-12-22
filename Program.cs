using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace TelephoneBook
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> persons = new List<Person>();
            persons.Add(new Person("Emre","İssever","123"));
            persons.Add(new Person("Jason","Statham","456"));
            persons.Add(new Person("John","Wick","789"));






            PersonOperations personOperations = new PersonOperations(persons);

            while(true)
            {

                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) => ");
                Console.WriteLine("********************************************");
                
                System.Console.WriteLine("(1) Yeni Numara Kaydetmek");
                System.Console.WriteLine("(2) Varolan Numarayı Silmek");
                System.Console.WriteLine("(3) Varolan Numarayı Güncellemek");
                System.Console.WriteLine("(4) Rehberi Listelemek");
                System.Console.WriteLine("(5) Rehberde Arama Yapmak");
                System.Console.WriteLine("(6) Programı kapat");
                
                try
                {

                    int operatioNumber = Convert.ToInt16(Console.ReadLine());

                    if( operatioNumber < 1 || operatioNumber > 6)
                    {
                        System.Console.WriteLine("\n Lütfen 1-6 arasında değer giriniz ");
                        continue;
                    }
                    else if( operatioNumber == 6 )
                    {

                        System.Console.WriteLine("Program kapatılıyor...");
                        Thread.Sleep(2000);
                        System.Console.WriteLine("Program kapatıldı.");
                        break;

                    }

                    Console.Clear();

                    switch(operatioNumber)
                    {
                        case 1:
                        {
                            System.Console.WriteLine("Lütfen isim giriniz                   :");
                            string name = Console.ReadLine();
                            System.Console.WriteLine("Lütfen Soyisim giriniz                :");
                            string surname = Console.ReadLine();
                            System.Console.WriteLine("Lütfen Telefon numarası giriniz       :");
                            string phoneNumber = Console.ReadLine();

                            Person tempPerson = new Person(name,surname,phoneNumber);

                            persons.Add(tempPerson);

                            System.Console.WriteLine("Kayıt işleminiz gerçekleşmiştir.");
                            break;


                        }

                        case 2:
                        {
                            while(true)
                            {
                                System.Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                                string deleteNumber = Console.ReadLine();
                                int index = -1;

                                if(personOperations.isThereANumber(deleteNumber,out index))
                                {
                                    System.Console.WriteLine("Yapılan işlemi onaylıyor musunuz? (y/n)");
                                    System.Console.WriteLine("Seçiminiz : ");
                                    string operation = Console.ReadLine();
                                    if(operation == "y")
                                    {
                                        personOperations.DeleteNumber(index);
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Aradığınız kişi bulunamadı. Lütfen tekrar deneyiniz.");
                                    Console.WriteLine(" ==> İşlemi sonlandırmak için : (1)");
                                    Console.WriteLine(" ==> Yeniden denemek için : (2)");
                                    Console.WriteLine("Seçiminiz : ");
                                    int newOperation = Convert.ToInt16(Console.ReadLine());
                                    if(newOperation == 1)
                                    {
                                        break;
                                    }

                                }
                            }
                            break;
                        }

                        case 3:
                        {
                            while(true)
                            {
                                System.Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
                                string given = Console.ReadLine();
                                int index  = -1;

                                if(personOperations.isThereANumber(given, out index))
                                {
                                    System.Console.WriteLine();
                                    string newPhoneNumber = Console.ReadLine();
                                    personOperations.UpdateNumber(index,newPhoneNumber);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberi bulunamadı. Lütfen tekrar deneyiniz.");
                                    Console.WriteLine(" ==> Güncellemeyi sonlandırmak için: (1)");
                                    Console.WriteLine(" ==> Yeniden denemek için: (2)");

                                    Console.Write("Seçiminiz:");
                                    int newSelection = Convert.ToInt16(Console.ReadLine());
                                    if (newSelection == 1)
                                    {
                                        break;
                                    }
                                }
                            }
                            break;
                        }

                        case 4:
                        {
                            Console.WriteLine("Hangi düzende sıralamak istediğinizi seçiniz.");
                            Console.WriteLine(" ==> A-Z için: (1)");
                            Console.WriteLine(" ==> Z-A için: (2)");
                            Console.Write("Seçiminiz:");
                            int SortSelection = Convert.ToInt16(Console.ReadLine());

                            if (SortSelection == 1)
                            {
                                   personOperations.ListOfGuide(SortOrder.increase);
                            }
                            else
                            {
                                  personOperations.ListOfGuide(SortOrder.decrease);
                            }

                            break;
                        }
                        case 5:
                        {
                            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                            Console.WriteLine(" ==> İsim veya soyisime göre arama yapmak için: (1)");
                            Console.WriteLine(" ==> Telefon numarasına göre arama yapmak için: (2)");

                            Console.Write("Seçiminiz:");
                            int newSelection = Convert.ToInt16(Console.ReadLine());

                            if (newSelection == 1)
                            {
                                Console.Write("İsim veya soyisim giriniz:");
                                string wantedNameAndSurname = Console.ReadLine();
                                personOperations.nameSurnameIsContain(wantedNameAndSurname);
                            }
                            else
                            {
                                Console.Write("Telefon giriniz:");
                                string wantedPhone = Console.ReadLine();
                                personOperations.nameSurnameIsContain(wantedPhone);
                            }

                            break;
                        }
                    }
             
                Console.WriteLine("\nYeni işlem için bir tuşa basınız");
                Console.ReadKey();
                Console.Clear();
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Hatalı giriş yapıldı!\n");
                }
            }
                Console.ReadKey();
            }   
    }

    class Person
    {
        public string _name;
        public string _surname;
        public string _phoneNumber;

        public Person(string name ,string surname,string phoneNumber)
        {
            this._name = name;
            this._surname = surname;
            this._phoneNumber = phoneNumber;
        }
    }

    public enum SortOrder
        {
            increase,
            decrease
        }



    class PersonOperations
    {
         List<Person> Persons = new List<Person>();


        public PersonOperations(List<Person> Persons)
        {
            this.Persons = Persons;
        }


        void ShowPersons(Person person)
        {
            Console.WriteLine("İsim             : " + person._name);
            Console.WriteLine("Soyisim          : " + person._surname);
            Console.WriteLine("Telefon numarası : " + person._phoneNumber);
            Console.WriteLine();
        }


        

        public void PhoneNumberIsContain(string given)
        {
            
            Console.WriteLine();

            bool isThereARecord = false;

            for(int i = 0; i < Persons.Count; i++)
            {
                if(given == Persons[i]._phoneNumber)
                {
                    ShowPersons(Persons[i]);
                    isThereARecord = true;
                }
            }
            if(!isThereARecord)
            {
                ProcessResult("Aradığınız kişi sistemde bulunamamıştır.");
            }
        }


        public void nameSurnameIsContain(string given)
            {
            
            Console.WriteLine();

            bool isThereARecord = false;

            for(int i = 0; i < Persons.Count; i++)
            {
                if(given == Persons[i]._phoneNumber)
                {
                    ShowPersons(Persons[i]);
                    isThereARecord = true;
                }
            }
            if(!isThereARecord)
            {
                ProcessResult("Aradığınız kişi sistemde bulunamamıştır.");
            }
        }

       
        public bool isThereANumber(string given, out int index)
        {
            for(int i = 0; i < Persons.Count; i++)
            {
                if(given == Persons[i]._name || given == Persons[i]._surname)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return true;
        }

        public void DeleteNumber(int index)
        {
             Persons.RemoveAt(index);
             ProcessResult("Silme İşlemi Başarıyla Gerçekleşti.");
        }


        public void UpdateNumber(int index,string newPhoneNumber)
        {
            Persons[index]._phoneNumber = newPhoneNumber;
            ProcessResult("Güncelleme İşlemi Başarıyla Gerçekleşti.");
        }


        public void ListOfGuide(SortOrder selectSort)
        {
            Persons.Sort((u1, u2) => u1._name.CompareTo(u2._name));//isime göre sırala

            if (selectSort == SortOrder.decrease)//eğer azalan isteniyorsa listeyi ters çevir
            {
                Persons.Reverse();
            }
           
            Console.WriteLine();
            for (int i = 0; i < Persons.Count; i++)
            {
                ShowPersons(Persons[i]);
            }
        }


        void ProcessResult(string processResult)
        {
            Console.WriteLine(processResult);
        }


    }





}
