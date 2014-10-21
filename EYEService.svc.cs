using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EYEServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EYEService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EYEService.svc or EYEService.svc.cs at the Solution Explorer and start debugging.
    public class EYEService : IEYEService
    {
        EYEDataClassesDataContext data = new EYEDataClassesDataContext();

        public bool validateUserLogin(String email, String password)
        {
            try
            {
                User aUser = (from user in data.Users
                                    where user.Email == email && user.Password == password
                                    select user).Single();
                if (aUser.Email.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public User getUserdetails(int loginId)
        {
            return (from user in data.Users where user.UserId == loginId select user).Single();
        }

        public String getUserRole(String email)
        {
            try
            {
                User aUser = (from user in data.Users
                              where user.Email == email
                              select user).Single();
                
                return aUser.Role;
                
            }
            catch
            {
                return null;
            }
        }

        public int getUserId(String email)
        {
            try
            {
                User aUser = (from user in data.Users
                              where user.Email == email
                              select user).Single();

                return aUser.UserId;

            }
            catch
            {
                return -1;
            }
        }


        public bool validateUserEmail( String email)
        {
            try
            {
                User userExisted = (from user in data.Users
                                    where user.Email == email
                                    select user).Single(); 
                if(userExisted.Email.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
                
        }

        public bool addNewUser(User newUser)
        {
            try
            {
                    data.Users.InsertOnSubmit(newUser);
                    data.SubmitChanges();
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteUser(int userID)
        {
            try
            {
                User userToDelete = (from user in data.Users
                                         where user.UserId == userID
                                         select user).Single();
                data.Users.DeleteOnSubmit(userToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyUser(User newUser)
        {
            try
            {
                User userToModify = (from user in data.Users
                                     where user.UserId == newUser.UserId
                                     select user).Single();
                userToModify.FirstName = newUser.FirstName;
                userToModify.MiddleName = newUser.MiddleName;
                userToModify.LastName = newUser.LastName;
                userToModify.Email = newUser.Email;
                userToModify.Role = newUser.Role;
                userToModify.Phone = newUser.Phone;
                userToModify.Password = newUser.Password;
                userToModify.Address = newUser.Address;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<User> getUsers()
        {
            try
            {
                return (from user in data.Users
                        select user).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool addNewAddress(Address newAddress)
        {
            try
            {
                data.Addresses.InsertOnSubmit(newAddress);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteAddress(int addressID)
        {
            try
            {
                Address addressToDelete = (from address in data.Addresses
                                           where address.AddressId == addressID
                                           select address).Single();
                data.Addresses.DeleteOnSubmit(addressToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyAddress(Address newAddress)
        {
            try
            {
                Address addressToModify = (from address in data.Addresses
                                        where address.AddressId == newAddress.AddressId
                                        select address).Single();

                addressToModify.AddressLine1 = newAddress.AddressLine1;
                addressToModify.AddressLine2 = newAddress.AddressLine2;
                addressToModify.City = newAddress.City;
                addressToModify.ZipCode = newAddress.ZipCode;
                addressToModify.State = newAddress.State;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Address> getAddresses()
        {
            try
            {
                return (from address in data.Addresses
                        select address).ToList();
            }
            catch
            {
                return null;
            }
        }

        public int getAddressId(String addressLine1, String addressLine2, String city, String stateCode, int zipCode )
        {
            try
            {
                Address _address = (from address in data.Addresses join state in data.States on address.State_fk equals state.StateId 
                                    where address.AddressLine1 == addressLine1 && address.AddressLine2 == addressLine2 && address.City == city && address.ZipCode == zipCode && state.StateCode == stateCode
                                    select address).Single();

                return _address.AddressId;

            }
            catch
            {
                return -1;
            }

        }

        public bool addNewState(State newState)
        {
            try
            {
                data.States.InsertOnSubmit(newState);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteState(int stateID)
        {
            try
            {
                State stateToDelete = (from state in data.States
                                           where state.StateId == stateID
                                           select state).Single();
                data.States.DeleteOnSubmit(stateToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyState(State newState)
        {
            try
            {
                State stateToModify = (from state in data.States
                                           where state.StateId == newState.StateId
                                           select state).Single();

                stateToModify.StateCode = newState.StateCode;
                stateToModify.StateName = newState.StateName;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<State> getStates()
        {
            try
            {
                return (from state in data.States
                        select state).ToList();
            }
            catch
            {
                return null;
            }
        }

        public int getStateId(String stateCode)
        {
            try
            {
                State aState = (from state in data.States
                              where state.StateCode == stateCode
                              select state).Single();

                return aState.StateId;

            }
            catch
            {
                return -1;
            }
        }

        public bool addNewHealthCareProvider(HealthCareProvider newHealthCareProvider)
        {
            try
            {
                data.HealthCareProviders.InsertOnSubmit(newHealthCareProvider);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteHealthCareProvider(int healthCareProviderID)
        {
            try
            {
                HealthCareProvider healthCareProviderToDelete = (from healthCareProvider in data.HealthCareProviders
                                                                 where healthCareProvider.HealthCareProviderId == healthCareProviderID
                                                                 select healthCareProvider).Single();
                data.HealthCareProviders.DeleteOnSubmit(healthCareProviderToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyHealthCareProvider(HealthCareProvider newHealthCareProvider)
        {
            try
            {
                HealthCareProvider healthCareProviderToModify = (from healthCareProvider in data.HealthCareProviders
                                                                 where healthCareProvider.HealthCareProviderId == newHealthCareProvider.HealthCareProviderId
                                                                 select healthCareProvider).Single();

                healthCareProviderToModify.PracticeName = newHealthCareProvider.PracticeName;
                healthCareProviderToModify.RoleInPractice = newHealthCareProvider.RoleInPractice;
                healthCareProviderToModify.ClinicName = newHealthCareProvider.ClinicName;
                healthCareProviderToModify.Gender = newHealthCareProvider.Gender;
                newHealthCareProvider.User = newHealthCareProvider.User;

                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<HealthCareProvider> getHealthCareProviders()
        {
            try
            {
                return (from healthCareProvider in data.HealthCareProviders
                        select healthCareProvider).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<String> getStateCode()
        {
            try
            {
                return (from state in data.States select state.StateCode).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Ethnicity> getEthnicities()
        {
            try
            {
                return (from ethnicity in data.Ethnicities
                        select ethnicity).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool addNewEthnicity(Ethnicity newEthnicity)
        {
            try
            {
                data.Ethnicities.InsertOnSubmit(newEthnicity);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteEthnicity(int ethnicityId)
        {
            try
            {
                Ethnicity ethnicityToDelete = (from ethnicity in data.Ethnicities
                                               where ethnicity.EthnicityId == ethnicityId
                                               select ethnicity).Single();
                data.Ethnicities.DeleteOnSubmit(ethnicityToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyEthnicity(Ethnicity newEthnicity)
        {
            try
            {
                Ethnicity ethnicityToModify = (from ethnicity in data.Ethnicities
                                               where ethnicity.EthnicityId == newEthnicity.EthnicityId
                                               select ethnicity).Single();

                ethnicityToModify.EthnicityName = newEthnicity.EthnicityName;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyFamily_Patient(Family_Patient newFamilyPatient)
        {
            try
            {
                Family_Patient familyToModify = (from familyPatient in data.Family_Patients
                                                 where familyPatient.FamilyPatientId == newFamilyPatient.FamilyPatientId
                                                 select familyPatient).Single();
                // More statements here
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Family_Patient> getFamily_Patients()
        {
            try
            {
                return (from familyPatient in data.Family_Patients
                        select familyPatient).ToList();
            }
            catch
            {
                return null;
            }
        }

        public int getSchoolId(string schoolName)
        {
            return ((from school in data.Schools
                     where school.SchoolName == schoolName
                     select school.SchoolId).Single());
        }
        public bool addNewSchool(School newSchool)
        {
            try
            {
                data.Schools.InsertOnSubmit(newSchool);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteSchool(int schoolID)
        {
            try
            {
                School schoolToDelete = (from school in data.Schools
                                         where school.SchoolId == schoolID
                                         select school).Single();
                data.Schools.DeleteOnSubmit(schoolToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifySchool(School newSchool)
        {
            try
            {
                School schoolToModify = (from school in data.Schools
                                         where school.SchoolId == newSchool.SchoolId
                                         select school).Single();

                schoolToModify.SchoolName = newSchool.SchoolName;
                schoolToModify.Contact = newSchool.Contact;
                schoolToModify.Address = newSchool.Address;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<School> getSchools()
        {
            try
            {
                return (from school in data.Schools
                        select school).ToList();
            }
            catch
            {
                return null;
            }
        }

        public int getFamilyId(int userId)
        {
            return (from family in data.Families
                    join user in data.Users on family.UserId_fk equals user.UserId
                    where user.UserId == userId
                    select family.FamilyId).Single();
        }

        public Family getFamilyDetails(int userId)
        {
            return (from family in data.Families where family.UserId_fk == userId select family).Single();
        }
        public bool addNewFamily(Family newFamily)
        {
            try
            {
                data.Families.InsertOnSubmit(newFamily);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteFamily(int familyID)
        {
            try
            {
                Family familyToDelete = (from family in data.Families
                                         where family.FamilyId == familyID
                                         select family).Single();
                data.Families.DeleteOnSubmit(familyToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyFamily(Family newFamily)
        {
            try
            {
                Family familyToModify = (from family in data.Families
                                         where family.FamilyId == newFamily.FamilyId
                                         select family).Single();

                familyToModify.OtherContact = newFamily.OtherContact;
                // More statements here
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Family> getFamilies()
        {
            try
            {
                return (from family in data.Families
                        select family).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool addNewPatient(Patient newPatient)
        {
            try
            {
                data.Patients.InsertOnSubmit(newPatient);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deletePatient(int patientID)
        {
            try
            {
                Patient patientToDelete = (from patient in data.Patients
                                           where patient.PatientId == patientID
                                           select patient).Single();
                data.Patients.DeleteOnSubmit(patientToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyPatient(Patient newPatient)
        {
            try
            {
                Patient patientToModify = (from patient in data.Patients
                                           where patient.PatientId == newPatient.PatientId
                                           select patient).Single();

                patientToModify.FirstName = newPatient.FirstName;
                // More statements here
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Patient> getPatient()
        {
            try
            {
                return (from patient in data.Patients
                        select patient).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool addNewFamily_Patient(Family_Patient newFamilyPatient)
        {
            try
            {
                data.Family_Patients.InsertOnSubmit(newFamilyPatient);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteFamily_Patient(int familyPatientId)
        {
            try
            {
                Family_Patient familyPatientToDelete = (from family_Patient in data.Family_Patients
                                                        where family_Patient.FamilyPatientId == familyPatientId
                                                        select family_Patient).Single();
                data.Family_Patients.DeleteOnSubmit(familyPatientToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the patients for the selected provider id.
        /// </summary>
        /// <param name="providerId">provider id</param>
        /// <returns>list of patients</returns>
        public List<Patient> getPatientsForProvider(int providerId)
        {
            try
            {
               var patientIds = (from provider_patients in data.Provider_Patients
                                     where provider_patients.ProviderId == providerId
                                     select provider_patients.PatientId);

               List<Patient> list = new List<Patient>();
               foreach (var id in patientIds)
               {
                   var patientList = (from patients in data.Patients
                                      where patients.PatientId == id
                                      select patients);

                   list.AddRange(patientList);
               }

               return list;
                                        
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// Gets family details for the selected patient id
        /// </summary>
        /// <param name="patientId">patient id</param>
        /// <returns>list of family users</returns>
        public List<User> getFamilyForPatient(int patientId)
        {
            try
            {
                var familyIds = from family_patient in data.Family_Patients
                                where family_patient.PatientId_fk == patientId
                                select family_patient.FamilyId_fk;

                List<int?> userIds = new List<int?>();
                foreach (var id in familyIds)
                {
                    int? ids = (from family in data.Families
                                   where family.FamilyId == id
                                   select family.UserId_fk).First();

                    userIds.Add(ids);
                }

                List<User> users = new List<User>();
                foreach (var userId in userIds)
                {
                    var familyUsers = (from user in data.Users
                                where user.UserId == userId
                                select user);

                    users.AddRange(familyUsers);
                }

                return users;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets treatment record for the selected patient
        /// </summary>
        /// <param name="patientId">patient id</param>
        /// <returns>returns list of records</returns>
        public List<ScreeningTest> getPatientTreatmentRecord(int patientId)
        {
            try
            {
                var screenIds = from treatRecord in data.TreatmentRecords
                                where treatRecord.PatientId_fk == patientId
                                select treatRecord.ScreeningTestId_fk;

                List<ScreeningTest> list = new List<ScreeningTest>();

                foreach(var id in screenIds)
                {
                    var records = from tests in data.ScreeningTests
                                  where tests.TestId == id
                                  select tests;

                    list.AddRange(records);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}

