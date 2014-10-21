using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EYEServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEYEService" in both code and config file together.
    [ServiceContract]
    public interface IEYEService
    {
        [OperationContract]
        bool validateUserLogin(String email, String password);

        [OperationContract]
        String getUserRole(String email);

        [OperationContract]
        int getUserId(String email);

        [OperationContract]
        bool validateUserEmail(String email);

        [OperationContract]
        bool addNewUser(User newUser);

        [OperationContract]
        bool deleteUser(int userID);

        [OperationContract]
        bool modifyUser(User newUser);

        [OperationContract]
        List<User> getUsers();

        [OperationContract]
        bool addNewAddress(Address newAddress);

        [OperationContract]
        bool deleteAddress(int addressID);

        [OperationContract]
        bool modifyAddress(Address newAddress);

        [OperationContract]
        List<Address> getAddresses();

        [OperationContract]
        int getAddressId(String addressLine1, String addressLine2, String city, String state, int zipCode);

        [OperationContract]
        bool addNewState(State newState);

        [OperationContract]
        bool deleteState(int stateID);

        [OperationContract]
        bool modifyState(State newState);

        [OperationContract]
        List<State> getStates();

               [OperationContract]
        int getStateId(String stateCode);

        [OperationContract]
        bool addNewHealthCareProvider(HealthCareProvider newHealthCareProvider);

        [OperationContract]
        bool deleteHealthCareProvider(int healthCareProviderID);

        [OperationContract]
        bool modifyHealthCareProvider(HealthCareProvider newHealthCareProvider);

        [OperationContract]
        List<HealthCareProvider> getHealthCareProviders();

        [OperationContract]
        int getFamilyId(int userId);

        [OperationContract]
        Family getFamilyDetails(int userId);

        [OperationContract]
        bool addNewFamily(Family newFamily);

        [OperationContract]
        User getUserdetails(int loginId);

        [OperationContract]
        bool deleteFamily(int familyID);

        [OperationContract]
        bool modifyFamily(Family newFamily);

        [OperationContract]
        List<Family> getFamilies();

        [OperationContract]
        bool addNewPatient(Patient newPatient);

        [OperationContract]
        bool deletePatient(int patientID);

        [OperationContract]
        bool modifyPatient(Patient newPatient);

        [OperationContract]
        List<Patient> getPatient();

        [OperationContract]
        bool addNewFamily_Patient(Family_Patient newFamilyPatient);

        [OperationContract]
        bool deleteFamily_Patient(int familyPatientID);

        [OperationContract]
        bool modifyFamily_Patient(Family_Patient newPatient);

        [OperationContract]
        List<Family_Patient> getFamily_Patients();

        [OperationContract]
        int getSchoolId(String schoolName);

        [OperationContract]
        bool addNewSchool(School newSchool);

        [OperationContract]
        bool deleteSchool(int schoolID);

        [OperationContract]
        bool modifySchool(School newSchool);

        [OperationContract]
        List<School> getSchools();

        [OperationContract]
        bool addNewEthnicity(Ethnicity newEthnicity);

        [OperationContract]
        bool deleteEthnicity(int ethnicityID);

        [OperationContract]
        bool modifyEthnicity(Ethnicity newEthnicity);

        [OperationContract]
        List<Ethnicity> getEthnicities();

        [OperationContract]
        List<String> getStateCode();

        [OperationContract]
        List<Patient> getPatientsForProvider(int providerId);

        [OperationContract]
        List<User> getFamilyForPatient(int patientId);

        [OperationContract]
        List<ScreeningTest> getPatientTreatmentRecord(int patientId);

    }
}
