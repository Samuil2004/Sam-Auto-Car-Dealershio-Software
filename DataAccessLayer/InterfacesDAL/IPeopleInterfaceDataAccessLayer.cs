using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Logic_layer;
using Microsoft.Data.SqlClient;
namespace DataAccessLayer.InterfacesDAL
{
    public interface IPeopleInterfaceDataManagerDataAccessLayer
    {
        bool IsEmailAvailable(string email);
        int CreatePerson(Person p, string salt, string hash, int secretQuestionId, string secretQuestionAnswer);
        Tuple<string, string> ReadSaltAndHash(string email);
        void UpdatePerson(int personId, string email, string phoneNumber, string hash, string salt, int secretQuestionId, string secretQuestionAnswer);
        void DeletePerson(int person_id);
        void PromoteCustomer(int person_id);
        void BookmarkVehicle(int person_id, int vehicle_id);
        void UnBookmarkVehicle(int person_id, int vehicle_id);
        Dictionary<int, string> ReadSecretQuestions();
        Tuple<string, string> ReadPersonSecretQuestion(string email);
        List<Person> ReadPeopleForPage(string role, int pageNum, string filteringCriteria);
        Person ReadPerson(int personId, string email, SqlConnection? connection);
    }
}
