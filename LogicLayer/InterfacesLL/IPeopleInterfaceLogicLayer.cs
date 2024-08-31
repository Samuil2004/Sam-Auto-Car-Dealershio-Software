using Classes;
using Microsoft.Data.SqlClient;
namespace LogicLayer.InterfacesLL
{
    public interface IPeopleInterfaceLogicLayer
    {
        bool IsEmailAvailable(string email);
        Person? CheckForUserDesktop(string givenUsername, string givenPassword);
        Person? CheckForUserWeb(string givenUsername, string givenPassword);
        int CreatePerson(Person p, string password, string secretQuestion, string answer);
        void UpdatePerson(int personId, string email, string phoneNumber, string password, string secretQuestion, string answer);
        void DeletePerson(int person_id);
        Person FindPerson(string Identifier, List<Person> givenList);
        void PromoteCustomer(int person_id);
        //List<Vehicle> GetCustomerBookmarkedVehicles(int personId);
        //List<Vehicle> GetCustomerSavedVehicles(int person_id);
        void BookmarkVehicle(int person_id, int vehicle_id);
        void UnBookmarkVehicle(int person_id, int vehicle_id);
        Person? GetUserByUsername(string givenEmail);
        Dictionary<int, string> ReadSecretQuestions();
        Person? CheckUserSecretQuestionForForgottenPassword(string email, string secretQuestion, string secretAnswer);
        Person? GetUserById(int personId);
        List<Person> GetPeopleForSelectedPage(string role, int pageNum, string filteringCriteria);
    }
}
