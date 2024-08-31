using Classes;
using DataAccessLayer.CustomExceptions;
using DataAccessLayer.InterfacesDAL;
using Logic_layer;
using Logic_layer.Payment_Strategies;
using LogicLayer;
using Microsoft.Data.SqlClient;

namespace TestingTool.TestDB
{
    [TestClass]
    public class TestDBPeople : IPeopleInterfaceDataManagerDataAccessLayer
    {
        private TestDBVehicle testDBVehicle = new TestDBVehicle();
        private List<Person> people;
        private Dictionary<int, int> bookmarks;
        private Dictionary<int, string> secretQuestions;
        private Dictionary<string, Tuple<int, string>> secretQuestionsHolder;
        private Dictionary<string, Tuple<string, string>> hashSaltHolder;


        public TestDBPeople()
        {
            people = new List<Person>();
            CustomerBoughtVehicles cutomerBoughtVehicles1 = new CustomerBoughtVehicles(new List<Receipt>() { new Receipt(testDBVehicle.ReadVehicle(27, null), new BankTransferPaymentStrategy(), DateTime.Today, 9898) });
            CustomerFavoriteVehicles customerFavoriteVehicles1 = new CustomerFavoriteVehicles(new List<Vehicle>() { testDBVehicle.ReadVehicle(1, null), testDBVehicle.ReadVehicle(2, null), testDBVehicle.ReadVehicle(3, null), testDBVehicle.ReadVehicle(4, null), testDBVehicle.ReadVehicle(5, null), testDBVehicle.ReadVehicle(6, null), testDBVehicle.ReadVehicle(7, null), testDBVehicle.ReadVehicle(8, null), testDBVehicle.ReadVehicle(9, null), testDBVehicle.ReadVehicle(10, null) });
            CustomerSavedVehicles customerSavedVehicles1 = new CustomerSavedVehicles(new List<Vehicle>() { testDBVehicle.ReadVehicle(25, null) });
            people.Add(new Customer(1, "Michael", "Jackson", "m.jackson@gmail.com", "098765465", true, cutomerBoughtVehicles1, customerFavoriteVehicles1, customerSavedVehicles1));

            CustomerBoughtVehicles cutomerBoughtVehicles2 = new CustomerBoughtVehicles(new List<Receipt>() { });
            CustomerFavoriteVehicles customerFavoriteVehicles2 = new CustomerFavoriteVehicles(new List<Vehicle>() { testDBVehicle.ReadVehicle(2, null), testDBVehicle.ReadVehicle(3, null), testDBVehicle.ReadVehicle(4, null), testDBVehicle.ReadVehicle(5, null), testDBVehicle.ReadVehicle(11, null), testDBVehicle.ReadVehicle(12, null), testDBVehicle.ReadVehicle(14, null) });
            CustomerSavedVehicles customerSavedVehicles2 = new CustomerSavedVehicles(new List<Vehicle>());
            people.Add(new Customer(2, "Elvis", "Presley", "elvis.presley@example.com", "123456789", true, cutomerBoughtVehicles2, customerFavoriteVehicles2, customerSavedVehicles2));

            CustomerBoughtVehicles cutomerBoughtVehicles3 = new CustomerBoughtVehicles(new List<Receipt>() { });
            CustomerFavoriteVehicles customerFavoriteVehicles3 = new CustomerFavoriteVehicles(new List<Vehicle>() { testDBVehicle.ReadVehicle(9, null), testDBVehicle.ReadVehicle(10, null), testDBVehicle.ReadVehicle(18, null), testDBVehicle.ReadVehicle(20, null), testDBVehicle.ReadVehicle(17, null), testDBVehicle.ReadVehicle(19, null) });
            CustomerSavedVehicles customerSavedVehicles3 = new CustomerSavedVehicles(new List<Vehicle>());
            people.Add(new Customer(3, "Freddie", "Mercury", "freddie.mercury@example.com", "987654321", true, cutomerBoughtVehicles3, customerFavoriteVehicles3, customerSavedVehicles3));

            CustomerBoughtVehicles cutomerBoughtVehicles4 = new CustomerBoughtVehicles(new List<Receipt>() { });
            CustomerFavoriteVehicles customerFavoriteVehicles4 = new CustomerFavoriteVehicles(new List<Vehicle>() { testDBVehicle.ReadVehicle(2, null), testDBVehicle.ReadVehicle(15, null), testDBVehicle.ReadVehicle(16, null), testDBVehicle.ReadVehicle(21, null), testDBVehicle.ReadVehicle(22, null), testDBVehicle.ReadVehicle(23, null), testDBVehicle.ReadVehicle(24, null) });
            CustomerSavedVehicles customerSavedVehicles4 = new CustomerSavedVehicles(new List<Vehicle>());
            people.Add(new Customer(4, "Whitney", "Houston", "whitney.houston@example.com", "234567890", true, cutomerBoughtVehicles4, customerFavoriteVehicles4, customerSavedVehicles4));

            CustomerBoughtVehicles cutomerBoughtVehicles5 = new CustomerBoughtVehicles(new List<Receipt>() { });
            CustomerFavoriteVehicles customerFavoriteVehicles5 = new CustomerFavoriteVehicles(new List<Vehicle>());
            CustomerSavedVehicles customerSavedVehicles5 = new CustomerSavedVehicles(new List<Vehicle>());
            people.Add(new Customer(5, "Aretha", "Franklin", "aretha.franklin@example.com", "345678901", true, cutomerBoughtVehicles5, customerFavoriteVehicles5, customerSavedVehicles5));

            bookmarks = new Dictionary<int, int>();
            secretQuestions = new Dictionary<int, string>();
            secretQuestions.Add(1, "What is the name of your first pet?");
            secretQuestions.Add(2, "What city was your mother born in?");
            secretQuestions.Add(3, "What is the name of the mother of your mother?");
            secretQuestionsHolder = new Dictionary<string, Tuple<int, string>>();
            secretQuestionsHolder.Add("m.jackson@gmail.com", Tuple.Create(1, "Jerry"));
            secretQuestionsHolder.Add("elvis.presley@example.com", Tuple.Create(1, "Rockie"));
            secretQuestionsHolder.Add("freddie.mercury@example.com", Tuple.Create(1, "Jackie"));
            secretQuestionsHolder.Add("whitney.houston@example.com", Tuple.Create(1, "Merry"));
            secretQuestionsHolder.Add("aretha.franklin@example.com", Tuple.Create(1, "Rockie"));
            hashSaltHolder = new Dictionary<string, Tuple<string, string>>();

        }

        public void BookmarkVehicle(int person_id, int vehicle_id)
        {
            bookmarks.Add(person_id, vehicle_id);
        }

        public int CreatePerson(Person p, string salt, string hash, int secretQuestionId, string secretQuestionAnswer)
        {
            foreach (Person person in people)
            {
                if (person.GetEmail.Equals(p.GetEmail))
                {
                    throw new DALException();
                }
            }
            people.Add(p);
            hashSaltHolder.Add(p.GetEmail, Tuple.Create(hash, salt));

            secretQuestionsHolder.Add(p.GetEmail, Tuple.Create(secretQuestionId, secretQuestionAnswer));
            return p.GetId;

        }

        public void DeletePerson(int person_id)
        {
            foreach (Person person in people)
            {
                if (person.GetId == person_id)
                {
                    people.Remove(person);
                    break;
                }
            }
        }


        public bool IsEmailAvailable(string email)
        {
            foreach (Person person in people)
            {
                if (person.GetEmail.Equals(email))
                {
                    return false;
                }
            }
            return true;
        }

        public void PromoteCustomer(int person_id)
        {
            throw new NotImplementedException();
        }

        public List<Person> ReadPeopleForPage(string role, int pageNum, string filteringCriteria)
        {
            List<Person> peopleForPage = new List<Person>();
            int startIndex = (pageNum - 1) * 10;
            int endIndex = pageNum * 10;

            if (string.IsNullOrEmpty(filteringCriteria))
            {
                for (int i = startIndex; i < people.Count(); i++)
                {
                    peopleForPage.Add(people[i]);
                }
            }
            else
            {
                List<Person> peopleMatchingFilteringCriteria = new List<Person>();
                foreach (Person person in people)
                {
                    if (person.GetIdentifyingInfo.Contains(filteringCriteria))
                    {
                        peopleMatchingFilteringCriteria.Add(ReadPerson(person.GetId, null, null));
                    }
                }
                if (peopleMatchingFilteringCriteria.Count() < endIndex)
                {
                    endIndex = peopleMatchingFilteringCriteria.Count();
                }
                for (int i = startIndex; i < endIndex; i++)
                {
                    peopleForPage.Add(peopleMatchingFilteringCriteria[i]);
                }
            }

            return peopleForPage;
        }

        public Person ReadPerson(int personId, string email, SqlConnection? connection)
        {
            if (string.IsNullOrEmpty(email))
            {
                foreach (Person person in people)
                {
                    if (person.GetId == personId)
                    {
                        return person;
                    }
                }
            }
            else if (!string.IsNullOrEmpty(email))
            {
                foreach (Person person in people)
                {
                    if (person.GetEmail == email)
                    {
                        return person;
                    }
                }
            }
            throw new UserNotFound();

        }

        public Tuple<string, string> ReadPersonSecretQuestion(string email)
        {
            return Tuple.Create(ReadSecretQuestions()[secretQuestionsHolder[email].Item1], secretQuestionsHolder[email].Item2);
        }

        public Tuple<string, string> ReadSaltAndHash(string email)
        {
            return hashSaltHolder[email];
        }

        public Dictionary<int, string> ReadSecretQuestions()
        {
            return secretQuestions;
        }

        public void UnBookmarkVehicle(int person_id, int vehicle_id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(int personId, string email, string phoneNumber, string hash, string salt, int secretQuestionId, string secretQuestionAnswer)
        {
            throw new NotImplementedException();
        }

    }
}