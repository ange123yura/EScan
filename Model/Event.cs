using Firebase.Database.Query;
using static EScan.Includes.GlobalVariables;

namespace EScan.Model
{
    internal class Event
    {
        public string EventCode { get; set; }
        public string EventName { get; set; }
        public string EventStart { get; set; }
        public string EventEnd{ get; set; }
        public string EventDate { get; set; }
        public string FullName { get; set; }
        public string BarcodeId { get; set; }
        public int TimeOut { get; set; }
        public string ID { get; set; }
        public async Task<bool> AddEvent(string frname, string lsname, string uname, string pword, string pwords)
        {
            var user = new Event()
            {
                EventCode = frname,
                EventName = lsname,
                EventStart = pword,
                EventEnd = pwords,
                EventDate = uname
            };
            await client.Child("Event").PostAsync(user);
            return true;
        }
        public async Task<bool> EditUserAd(string frname, string lsname, string uname, string pword, string stat, string flename)
        {

            var user = new User()
            {
                Firstname = frname,
                Lastname = lsname,
                Username = uname,
                Password = pword,
            };
            await client.Child($"User/{userkey}").PatchAsync(user);
            return true;
        }
        public async Task<bool> GetEvent(string _uname)
        {
            try
            {
                var evaluateUsername = (await client.Child("Event")
                .OnceAsync<Event>()).FirstOrDefault(a =>
                a.Object.EventCode == _uname);


                if (evaluateUsername == null)
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
        public async Task<List<Event>> GetEvents()
        {
            return (await client
                .Child("Event")
                .OnceAsync<Event>()).Select(item => new Event
                {

                    EventCode = item.Object.EventCode,
                    EventName = item.Object.EventName,
                    EventStart = item.Object.EventStart,
                    EventEnd = item.Object.EventEnd,
                    EventDate = item.Object.EventDate

                }).ToList();
        }
        public async Task<List<Event>> GetEventss()
        {
            return (await client
                .Child($"Event/{_ek}/Attendance/")
                .OnceAsync<Event>()).Select(item => new Event
                {

                    EventCode = item.Object.EventCode,
                    EventName = item.Object.EventName,
                    EventStart = item.Object.EventStart,
                    EventEnd = item.Object.EventEnd,
                    EventDate = item.Object.EventDate,
                    ID = item.Object.ID,
                    TimeOut = item.Object.TimeOut,
                    BarcodeId = item.Object.BarcodeId,
                    FullName = item.Object.FullName

                }).ToList();
        }

        public async Task<String> GetStatus(string _user)
        {
            var evaluateID = (await client.Child("Event")
            .OnceAsync<Event>()).FirstOrDefault
            (a => a.Object.EventCode == _user);
            if (evaluateID != null)
            {

                _ec = evaluateID.Object.EventCode;
                _en = evaluateID.Object.EventName;
                _es = evaluateID.Object.EventStart;
                _ee = evaluateID.Object.EventEnd;
                _ed = evaluateID.Object.EventDate;
                _ek = evaluateID.Key;

                return evaluateID.Key;
            }
            return null;
        }

        public async Task<bool> DeleteEvent(string user)
        {
            try
            {

                var getuserkey = (await client
                    .Child("Event")
                    .OnceAsync<Event>()).FirstOrDefault
                    (a => a.Object.EventCode == user);
                if (getuserkey != null)
                {
                    await client
                        .Child("Event")
                    .Child(getuserkey.Key)
                        .DeleteAsync();
                    client.Dispose();

                    return true;
                }

                client.Dispose();
                return false;
            }
            catch
            {
                client.Dispose();
                return false;
            }
        }
        public async Task<bool> GetUser(string _uname, string _pword)
        {
            try
            {
                var evaluateUsername = (await client.Child("User")
                .OnceAsync<User>()).FirstOrDefault(b =>
                b.Object.Username == _uname && b.Object.Password == _pword);


                if (evaluateUsername != null)
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

        public async Task<bool> EditUser(string frname, string lsname, string uname, string pword)
        {
            var user = new User()
            {
                Firstname = frname,
                Lastname = lsname,
                Username = uname,
                Password = pword,
            };
            await GetStatus(uname);
            await client.Child($"User/{userkey}").PatchAsync(user);

            return true;
        }
        public async Task<List<User>> GetAllUsers()
        {

            return (await client
            .Child("User")
            .OnceAsync<User>()).Select(item => new User
            {
                Firstname = item.Object.Firstname,
                Lastname = item.Object.Lastname,
                Username = item.Object.Username,
            }).ToList();
        }

        public async Task<List<User>> FindUser(string fname)
        {
            var queryUsers = await GetAllUsers();
            await client
                .Child("User")
                .OnceAsync<User>();
            var searchTerms = fname.Split(' ');
            return queryUsers.Where(a => searchTerms.Any(term => a.Firstname.ToLower().Contains(term.ToLower()) || a.Username.ToLower().Contains(term.ToLower()) || a.Lastname.ToLower().Contains(term.ToLower())

            )).ToList();

        }
    }
}

